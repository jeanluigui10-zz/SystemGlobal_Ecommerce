using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using xAPI.BL.Resource;
using xAPI.Entity;
using xAPI.Entity.Order;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class Review : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            if (BaseSession.SsOrderxCore != null && BaseSession.SsOrderxCore.ListOrderDetail != null && BaseSession.SsOrderxCore.ListOrderDetail.Count > 0) 
            {
                OrderHeader objOrder = BaseSession.SsOrderxCore;
                List<Object> lstDetail = new List<Object>();
                for (int i = 0; i < objOrder.ListOrderDetail.Count; i++)
                {
                    Object objProduct = new
                    {
                        ProductId = objOrder.ListOrderDetail[i].Product.Id,
                        ProductName = objOrder.ListOrderDetail[i].Product.Name,
                        Category = objOrder.ListOrderDetail[i].Product.Category,
                        UnitPrice = objOrder.ListOrderDetail[i].Product.UnitPrice,
                        NameResource = objOrder.ListOrderDetail[i].Product.NameResource
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
                    CustomerId = objOrder.Customer.CustomerId,
                    CustomerName = objOrder.Customer.FullName,
                    Detail = lstDetail
                };
                
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(OrderHeader);
                  hfData.Value = sJSON.ToString();

            }
        }
        public void Message(EnumAlertType type, string message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);
        }
    }
}