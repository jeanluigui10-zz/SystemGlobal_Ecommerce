using System;
using System.Data;
using xAPI.Dao.Product;
using xAPI.Entity.Product;
using xAPI.Library.Base;

namespace xAPI.BL.Product
{
    public class ProductBL
    {
        #region Singleton
        private static ProductBL instance = null;
        public static ProductBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductBL();
                return instance;
            }
        }
        #endregion

        public DataTable Products_GetList_ById(ref BaseEntity objEntity, Int32 ProductId)
        {
            objEntity = new BaseEntity();
            DataTable dt = null;
            dt = ProductDao.Instance.Products_GetList_ById(ref objEntity, ProductId);

            return dt;
        }
        public DataTable Products_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = ProductDao.Instance.Products_GetList(ref entity);

            return dt;
        }
        public DataTable Products_ByCategory(ref BaseEntity entity, Int32 CategoryId)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = ProductDao.Instance.Products_ByCategory(ref entity, CategoryId);

            return dt;
        }
        public DataTable Products_BySubCategory(ref BaseEntity entity, Int32 SubCategoryId)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = ProductDao.Instance.Products_BySubCategory(ref entity, SubCategoryId);

            return dt;
        }
        public DataTable Products_Search_ByName(ref BaseEntity entity, String name)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = ProductDao.Instance.Products_Search_ByName(ref entity, name);

            return dt;
        }
        public DataTable Product_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = ProductDao.Instance.Product_GetList(ref entity);

            return dt;
        }

        public Products Products_GetList_ById_Ecommerce(ref BaseEntity entity, Int32 Id)
        {
            entity = new BaseEntity();
            Products obj = null;
            if (Id > 0)
            {
                obj = ProductDao.Instance.Products_GetList_ById_Ecommerce(ref entity, Id);
            }
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));
            return obj;

        }
    }
}
