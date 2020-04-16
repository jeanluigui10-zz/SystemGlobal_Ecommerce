using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Category;
using xAPI.BL.Products;
using xAPI.BL.Resource;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
                LoadCategory();
            }
        }
        private void LoadCategory() {
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
                            Name = item["NAME"].ToString(),
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
                    hfCategory.Value = sJSON.ToString();
                }
            }
        }
        private void LoadData(Boolean ShowMessage = false)
        {
            BaseEntity entity = new BaseEntity();
            List<srProducts> lst = new List<srProducts>();

            DataTable dt = ProductBL.Instance.Products_GetList(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
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
                this.Message(EnumAlertType.Success, entity.Errors[0].MessageClient);
            }

            if (entity.Errors.Count <= 0)
            {
                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(lst);
                    hfProducts.Value = sJSON.ToString();
                }
            }
        }

        [WebMethod]
        public static String Products_ByCategory(String CategoryId)
        {
            BaseEntity entity = new BaseEntity();
            List<srProducts> lst = new List<srProducts>();
            String productList = String.Empty;
            Object objReturn = new Object();

            try
            {
                String CategId = Encryption.Decrypt(HttpUtility.UrlDecode(CategoryId));
                DataTable dt = ProductBL.Instance.Products_ByCategory(ref entity, Convert.ToInt32(CategId));
                if (entity.Errors.Count == 0)
                {
                    if (dt != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
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
                        objReturn = new
                        {
                            Result = "NoOk",
                            Msg = "Ocurrió un problema al cargar los productos."
                        };
                    }
                }
                else
                {
                    objReturn = new
                    {
                        Result = "NoOk",
                        Msg = "Ocurrió un problema al cargar los productos."
                    };
                }

                if (entity.Errors.Count <= 0)
                {
                    if (lst != null)
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        productList = serializer.Serialize(lst);
                    }
                }
            }
            catch (Exception ex)
            {
                objReturn = new
                {
                    Result = "NoOk",
                    Msg = "Ocurrió un problema al cargar los productos."
                };
            }
            return productList;
        }

        public void Message(EnumAlertType type, string message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);
        }
    }
}