using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Products;
using xAPI.Library.Base;

namespace xAPI.BL.Products
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
    }
}
