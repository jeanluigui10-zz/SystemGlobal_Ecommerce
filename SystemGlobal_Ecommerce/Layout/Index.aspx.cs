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
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;
namespace SystemGlobal_Ecommerce.Layout
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                LoadData();               
            }
        }
        private void LoadData(Boolean ShowMessage = false)
        {
            BaseEntity entity = new BaseEntity();
            List<srAppResource> lst = new List<srAppResource>();

            DataTable dt = ResourceBL.Instance.AppResource_GetByAplicationID(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    Int32 count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        count++;
                        String sId = Server.UrlEncode(Encryption.Encrypt(item["ID"].ToString()));
                        lst.Add(new srAppResource()
                        {
                            isCheckbox = "1",
                            Id = sId,
                            FileName = item["FILENAME"].ToString(),
                            DocType = item["DOCTYPE"].ToString(),
                            Category = item["RESOURCE_CATEGORY_NAME"].ToString(),
                            FileDescription = item["DESCRIPTION"].ToString(),
                            NameResource = item["NAMERESOURCE"].ToString(),
                            CreatedDate = Convert.ToDateTime(item["CREATEDDATE"]).ToString("MM/dd/yyyy"),
                            Status = Convert.ToInt16(item["STATUS"]) == (short)EnumStatus.Enabled ? "Enabled" : "Disabled",
                            Index = item["ID"].ToString()
                        });
                    }
                }
                else
                {
                    this.Message(EnumAlertType.Error, "An error occurred while loading data");
                }
            }
            else
            {
                this.Message(EnumAlertType.Success, entity.Errors[0].MessageClient);
            }

            if (entity.Errors.Count <= 0)
            {
                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(lst);
                    hfData.Value = sJSON.ToString();
                }
            }
        }
        public void Message(EnumAlertType type, string message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);
        }
    }
}