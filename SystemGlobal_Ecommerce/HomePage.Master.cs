using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Category;
using xAPI.BL.Resource;
using xAPI.Entity.Order;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (BaseSession.SsOrderxCore.Customer != null && BaseSession.SsOrderxCore.Customer.ID > 0)
            //{
            //    lblCuenta.Visible = true;
            //    lblCerrarSession.Visible = true;
            //    lblInicioSession.Visible = false;
            //    lblRegistrar.Visible = false;
            //    hfCustomerId.Value = HttpUtility.UrlEncode(Encryption.Encrypt(BaseSession.SsOrderxCore.Customer.ID.ToString()));
            //}
            //else
            //{
            //    lblInicioSession.Visible = true;
            //    lblRegistrar.Visible = true;
            //    lblCuenta.Visible = false;
            //    lblCerrarSession.Visible = false;
            //    hfCustomerId.Value = "";
            //}
            //Load_Settings();
            //Load_Products();
            //Load_Category();
            //if (BaseSession.SsOrderxCore.Customer != null && BaseSession.SsOrderxCore.Customer.CustomerId > 0)
            //{
            //    ucChat.SetUserId(BaseSession.SsOrderxCore.Customer.CustomerId);
            //    ucChat.SetUserFullName(BaseSession.SsOrderxCore.Customer.FirstName);
            //}
            //else
            //{
            //    Int32 codigoAleatorio = new Random().Next(1000, 2000);
            //    ucChat.SetUserId(codigoAleatorio);
            //    ucChat.SetUserFullName("");
            //}

        }
        private void Load_Category()
        {
            BaseEntity entity = new BaseEntity();
            List<srCategory> lst = new List<srCategory>();

            DataTable dt = CategoryBL.Instance.CategoryProduct_GetList(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        lst.Add(new srCategory()
                        {
                            Id = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString())),
                            Name = item["Name"].ToString(),
                        });
                    }
                }
               
            }
            if (entity.Errors.Count <= 0)
            {
                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(lst);
                    //hfDataListCategory.Value = sJSON.ToString();
                }
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
                        ProductId = orderHeader.ListOrderDetail[i].Product.ID,
                        ProductName = orderHeader.ListOrderDetail[i].Product.Name,
                        Category = orderHeader.ListOrderDetail[i].Product.category.Name,
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
                    DeliveryTotal = orderHeader.DeliveryTotal,
                    CustomerId = orderHeader.Customer == null ? 0 : orderHeader.Customer.ID,
                    CustomerName = orderHeader.Customer == null ? "" : orderHeader.Customer.FullName,
                    Detail = lstDetail
                };

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                String sJSON = serializer.Serialize(OrderHeader);

                //hfDataListProduct.Value = sJSON.ToString();
            }
        }
        //private void Load_Settings()
        //{
        //    BaseEntity objBase = new BaseEntity();
        //    DataTable dt = ResourceBL.Instance.Settings_GetAll(ref objBase);
        //    if (objBase.Errors.Count == 0)
        //    {
        //        if (dt != null)
        //        {
        //            foreach (DataRow item in dt.Rows)
        //            {
        //                hfIsVisiableChat.Value = item["ChatOnlineActive"].ToString();
        //            }
        //        }
        //    }
        //}
        protected void btnCloseSession_ServerClick(object sender, EventArgs e)
        {
            BaseSession.Logout();
            Response.Redirect("Index.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            BaseSession.Logout();
            Response.Redirect("~/Layout/Login.aspx", false);
        }
    }
}