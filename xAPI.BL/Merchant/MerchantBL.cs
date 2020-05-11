using System;
using System.Data;
using xAPI.Dao.Merchant;
using xAPI.Library.Base;

namespace xAPI.BL.Merchant
{
    public class MerchantBL
    {
        #region Singleton
        private static MerchantBL instance = null;
        public static MerchantBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new MerchantBL();
                return instance;
            }
        }
        #endregion
        public DataTable MethodPayment_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = MerchantDao.Instance.MethodPayment_GetList(ref entity);

            return dt;
        }
    }
}
