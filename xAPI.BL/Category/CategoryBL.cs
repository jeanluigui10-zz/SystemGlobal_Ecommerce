using System;
using System.Data;
using xAPI.Dao.Category;
using xAPI.Library.Base;

namespace xAPI.BL.Category
{
    public class CategoryBL
    {
        #region Singleton
        private static CategoryBL instance = null;
        public static CategoryBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryBL();
                return instance;
            }
        }
        #endregion

        public DataTable CategoryProduct_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = CategoryDao.Instance.CategoryProduct_GetList(ref entity);

            return dt;
        }

        public DataTable SubCategory_GetListBy_IdCategory(ref BaseEntity entity, Int32 IdCategory)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = CategoryDao.Instance.SubCategory_GetListBy_IdCategory(ref entity, IdCategory);

            return dt;
        }
    }
}
