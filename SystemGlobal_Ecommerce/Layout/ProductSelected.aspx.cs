using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Products;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class ProductSelected : System.Web.UI.Page
    {
        public int VsId
        {
            get { return ViewState["ID"] != null ? (int)ViewState["ID"] : default; }
            set { ViewState["ID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            SetQuery();
            SetData();
        }

        private void SetQuery()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["p"]))
            {
                String id = Encryption.Decrypt(Request.QueryString["p"]);
                if (!String.IsNullOrEmpty(id))
                {
                    VsId = Convert.ToInt32(id);
                }
                else
                {
                    GoBack();
                }
            }
        }
        public void GoBack()
        {
            Response.Redirect("ProductSelected.aspx");
        }

        private void SetData()
        {
            BaseEntity objEntity = new BaseEntity();
            List<srProducts> lst = new List<srProducts>();
            try
            {
                if (VsId > 0)
                {
                    DataTable dt = ProductBL.Instance.Products_GetList_ById(ref objEntity, VsId);
                    if (objEntity.Errors.Count == 0)
                    {
                        if (dt != null)
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                String idProduct = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString()));
                                lst.Add(new srProducts()
                                {
                                    Id = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString())),
                                    FileName = item["FILENAME"].ToString(),
                                    Name = item["NAME"].ToString(),
                                    UnitPrice = item["UnitPrice"].ToString(),
                                    DOCTYPE = item["DOCTYPE"].ToString(),
                                    Category = item["RESOURCE_CATEGORY_NAME"].ToString(),
                                    FileDescription = item["DESCRIPTION"].ToString(),
                                    NameResource = Config.Impremtawendomain + item["NAMERESOURCE"].ToString(),
                                    Status = item["STATUS"].ToString()
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
                        this.Message(EnumAlertType.Success, objEntity.Errors[0].MessageClient);
                    }

                    if (objEntity.Errors.Count <= 0)
                    {
                        if (lst != null)
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            String sJSON = serializer.Serialize(lst);
                            hfProduct.Value = sJSON.ToString();


                        }
                    }
                }
                else
                {
                    //SetControl();
                }
            }

            catch (Exception ex)
            {
                this.Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }

        public void Message(EnumAlertType type, string message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);

        }
    }
}