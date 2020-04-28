using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.Entity.Order;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Load_Settings();
                LoadData();
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
        //                hfIsVisiableChatConfir.Value = item["ChatOnlineActive"].ToString();
        //            }
        //        }
        //    }
        //}
        private void LoadData()
        {
            if (BaseSession.SsOrderxCore != null && BaseSession.SsOrderxCore.ListOrderDetail != null && BaseSession.SsOrderxCore.ListOrderDetail.Count > 0)
            {
                OrderHeader objOrder = BaseSession.SsOrderxCore;
                lblAddressConfirm.InnerText = objOrder.Address.Address1.ToString();
                lblMessageConfirm.InnerText = objOrder.Customer.FirstName.ToString() +" "+ objOrder.Customer.LastNamePaternal.ToString() + " "+ objOrder.Customer.LastNameMaternal.ToString() + ", TU PEDIDO SE GENERO SATISFACTORIAMENTE!";
                List <Object> lstDetail = new List<Object>();
                for (int i = 0; i < objOrder.ListOrderDetail.Count; i++)
                {
                    Object objProduct = new
                    {
                        ProductId = objOrder.ListOrderDetail[i].Product.ID,
                        ProductName = objOrder.ListOrderDetail[i].Product.Name,
                        Category = objOrder.ListOrderDetail[i].Product.category.Name,
                        UnitPrice = objOrder.ListOrderDetail[i].Product.UnitPrice,
                        NameResource = objOrder.ListOrderDetail[i].Product.NameResource,
                        PriceOffer = objOrder.ListOrderDetail[i].Product.PriceOffer

                    };
                    Object Detail = new
                    {
                        Product = objProduct,
                        Quantity = objOrder.ListOrderDetail[i].Quantity,
                        TotalPrice = objOrder.ListOrderDetail[i].Totalprice,
                    };

                    lstDetail.Add(Detail);
                }

                Object OrderHeader = new
                {
                    Ordertotal = objOrder.Ordertotal,
                    SubTotal = objOrder.SubTotal,
                    DeliveryTotal = objOrder.DeliveryTotal,
                    CustomerId = objOrder.Customer.ID,
                    CustomerName = objOrder.Customer.FullName,
                    Detail = lstDetail
                };

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                String sJSON = serializer.Serialize(OrderHeader);
                hfData.Value = sJSON.ToString();

                LimpiarSession();
                this.Message(EnumAlertType.Success, "La orden se registro Correctamente!");
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        private void LimpiarSession()
        {
            BaseSession.Logout();
        }

        public void Message(EnumAlertType type, string message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);
        }

     
       
    }
}