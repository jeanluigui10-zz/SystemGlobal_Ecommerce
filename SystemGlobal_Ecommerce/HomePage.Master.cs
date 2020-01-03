using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Resource;
using xAPI.Entity.Order;
using xAPI.Library.Base;

namespace SystemGlobal_Ecommerce
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Settings();
            Load_Products();

            if (BaseSession.SsOrderxCore.Customer != null && BaseSession.SsOrderxCore.Customer.CustomerId > 0)
            {
                ucChat.SetUserId(BaseSession.SsOrderxCore.Customer.CustomerId);
                ucChat.SetUserFullName(BaseSession.SsOrderxCore.Customer.FirstName);
            }
            else
            {
                Int32 codigoAleatorio = new Random().Next(1000, 2000);
                ucChat.SetUserId(codigoAleatorio);
                ucChat.SetUserFullName("");
            }
                   
        }

        private void Load_Products()
        {
            OrderHeader orderHeader = BaseSession.SsOrderxCore;
            if (orderHeader != null && orderHeader.ListOrderDetail != null && orderHeader.ListOrderDetail.Count > 0)
            {
                List<Object> lstDetail = new List<Object>();
                for (int i = 0; i < orderHeader.ListOrderDetail.Count; i++)
                {
                    Object objProduct = new
                    {
                        ProductId = orderHeader.ListOrderDetail[i].Product.Id,
                        ProductName = orderHeader.ListOrderDetail[i].Product.Name,
                        Category = orderHeader.ListOrderDetail[i].Product.Category,
                        UnitPrice = orderHeader.ListOrderDetail[i].Product.UnitPrice,
                        NameResource = orderHeader.ListOrderDetail[i].Product.NameResource
                    };
                    Object Detail = new
                    {
                        Product = objProduct,
                        Quantity = orderHeader.ListOrderDetail[i].Quantity,
                        TotalPrice = orderHeader.ListOrderDetail[i].Totalprice,
                    };

                    lstDetail.Add(Detail);
                }

                Object OrderHeader = new
                {
                    Ordertotal = orderHeader.Ordertotal,
                    SubTotal = orderHeader.SubTotal,
                    IGV = orderHeader.IGV,
                    CustomerId = orderHeader.Customer.CustomerId,
                    CustomerName = orderHeader.Customer.FullName,
                    Detail = lstDetail
                };

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                String sJSON = serializer.Serialize(OrderHeader);

                hfDataListProduct.Value = sJSON.ToString();
            }
        }

        private void Load_Settings()
        {
            BaseEntity objBase = new BaseEntity();
            DataTable dt = ResourceBL.Instance.Settings_GetAll(ref objBase);
            if (objBase.Errors.Count == 0)
            {
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        hfIsVisiableChat.Value = item["ChatOnlineActive"].ToString();
                    }
                }
            }

        }
        protected void btnCloseSession_ServerClick(object sender, EventArgs e)
        {
            BaseSession.Logout();
            Response.Redirect("Index.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            BaseSession.Logout();
            Response.Redirect("~/Layout/Index.aspx", false);
        }
    }
}