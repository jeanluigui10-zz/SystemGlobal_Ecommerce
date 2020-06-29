using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Category;
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
        public static String SubCategory_GetListBy_IdCategory(Int32 IdCategory)
        {
            BaseEntity entity = new BaseEntity();
            List<srSubCategory> lst = new List<srSubCategory>();
            String subCategoryList = String.Empty;

            try
            {
                DataTable dt = CategoryBL.Instance.SubCategory_GetListBy_IdCategory(ref entity, IdCategory);
                if (entity.Errors.Count == 0)
                {
                    if (dt != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            lst.Add(new srSubCategory()
                            {
                                IdSubCategory = HttpUtility.UrlEncode(Encryption.Encrypt(item["IdSubCategory"].ToString())),
                                IdCategory = item["IdCategory"].ToString(),
                                SubCategoryName = item["SubCategoryName"].ToString()
                            });
                        }
                    }
                }

                if (entity.Errors.Count <= 0)
                {
                    if (lst != null)
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        subCategoryList = serializer.Serialize(lst);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return subCategoryList;
        }


    }
}