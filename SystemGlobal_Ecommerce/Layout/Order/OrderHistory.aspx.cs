using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Order;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.Layout.Order
{
    public partial class OrderHistory : System.Web.UI.Page
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
            BaseEntity objEntity = new BaseEntity();
            List<srOrderHistory> lst = new List<srOrderHistory>();
            Int32 customerId = BaseSession.SsOrderxCore.Customer == null ? 0 : BaseSession.SsOrderxCore.Customer.ID;

            DataTable dt = OrderBL.Instance.Order_GetHistory_ByCustomer(ref objEntity, customerId);
            if (objEntity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    Int32 count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        count++;
                        lst.Add(new srOrderHistory()
                        {
                            LegacyNumber = item["LegacyNumber"].ToString(),
                            OrderDate = Convert.ToString(Convert.ToDateTime(item["OrderDate"], CultureInfo.InvariantCulture).ToString("MM/dd/yyyy")),
                            OrderStatus = item["PaymentStatusName"].ToString(),
                            OrderProgress = item["OrderStatusName"].ToString(),
                            Total = item["Total"].ToString(),
                            IdOrderEncrypt = HttpUtility.UrlEncode(Encryption.Encrypt(item["OrderId"].ToString())),
                        });
                    }
                }
                else
                {
                    hfOrderHistory.Value = "";
                }
            }
            else
            {
                this.Message(EnumAlertType.Success, objEntity.Errors[0].MessageClient);
            }

            if (objEntity.Errors.Count <= 0 && lst != null)
            {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(lst);
                    hfOrderHistory.Value = sJSON.ToString();
            }
        }

        public void Message(EnumAlertType type, String message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);
        }
    }
}