using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Category;
using xAPI.BL.Product;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.src.control
{
    public partial class WebMethodMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                String CategId = Encryption.Decrypt(CategoryId); //Encryption.Decrypt(HttpUtility.UrlDecode(CategoryId));
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
                                //SubCategoryName = item["SubCategoryName"].ToString(),
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
                            Msg = "Ocurrio un problema al cargar los productos."
                        };
                    }
                }
                else
                {
                    objReturn = new
                    {
                        Result = "NoOk",
                        Msg = "Ocurrio un problema al cargar los productos."
                    };
                }

                if (entity.Errors.Count <= 0 && lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    productList = serializer.Serialize(lst);
                }
            }
            catch (Exception ex)
            {
                objReturn = new
                {
                    Result = "NoOk",
                    Msg = "Ocurrio un problema al cargar los productos."
                };
            }
            return productList;
        }

    }
}