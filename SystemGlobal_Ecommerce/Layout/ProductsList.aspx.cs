using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Category;
using xAPI.BL.Product;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class ProductsList : System.Web.UI.Page
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
            LoadCategory();
            LoadProduct();
            SetQueryCategory();
        }
        private void SetQueryCategory()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["category"]))
            {
                String CategoryId = Request.QueryString["category"];
                hfQueryCategory.Value = CategoryId;
            }
            else
            {
                hfQueryCategory.Value = "";
            }
        }
        private void LoadCategory() 
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
         private void LoadProduct(Boolean ShowMessage = false)
         {
             BaseEntity entity = new BaseEntity();
             List<srProducts> lst = new List<srProducts>();

            DataTable dt = ProductBL.Instance.Product_GetList(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    Int32 count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        count++;
                        lst.Add(new srProducts()
                        {
                            isCheckbox = "1",
                            Id = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString())),
                            Name = item["Name"].ToString(),
                            Description = item["Description"].ToString(),
                            DocType = item["DocType"].ToString(),
                            Category = item["Resource_Category_Name"].ToString(),
                            Brand = item["BrandName"].ToString(),
                            NameResource = Config.Impremtawendomain + item["NameResource"].ToString(),
                            UnitPrice = Convert.ToDecimal(item["UnitPrice"]).ToString(),
                            Stock = Convert.ToInt32(item["Stock"]).ToString(),
                            PriceOffer = Convert.ToDecimal(item["PriceOffer"]).ToString(),
                            UniMed = item["UniMed"].ToString(),
                            Status = Convert.ToInt16(item["Status"]) == (short)EnumStatus.Enabled ? "Activo" : "Inactivo",
                            Index = count.ToString()
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
                                 FileName = item["FileName"].ToString(),
                                 Name = item["Name"].ToString(),
                                 UnitPrice = item["UnitPrice"].ToString(),
                                 DocType = item["DocType"].ToString(),
                                 Brand = item["BrandName"].ToString(),
                                 Category = item["Resource_Category_Name"].ToString(),
                                 Description = item["Description"].ToString(),
                                 Stock = Convert.ToInt32(item["Stock"]).ToString(),
                                 PriceOffer = Convert.ToDecimal(item["PriceOffer"]).ToString(),
                                 UniMed = item["UniMed"].ToString(),
                                 NameResource = Config.Impremtawendomain + item["NameResource"].ToString(),
                                 Status = item["Status"].ToString()
                             });
                         }
                     }
                     else
                     {
                         objReturn = new
                         {
                             Result = "NoOk",
                             Msg = "OcurriÃ³ un problema al cargar los productos."
                         };
                     }
                 }
                 else
                 {
                     objReturn = new
                     {
                         Result = "NoOk",
                         Msg = "OcurriÃ³ un problema al cargar los productos."
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
                     Msg = "OcurriÃ³ un problema al cargar los productos."
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