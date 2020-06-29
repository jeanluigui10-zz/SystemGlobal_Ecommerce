using System.Data;
using xAPI.Dao.Setting;
using xAPI.Entity.Store;
using xAPI.Library.Base;

namespace xAPI.BL.Setting
{
    public class SettingBL
    {
        #region Singleton
        private static SettingBL instance = null;
        public static SettingBL Instance
        {
            get {
                if (instance == null)
                    instance = new SettingBL();
                return instance;
            }
        }
        #endregion

        #region Methods
        public Store Store_GetInformation(ref BaseEntity objEntity)
        {
            objEntity = new BaseEntity();
            Store objStore = null;
            objStore = SettingDao.Instance.Store_GetInformation(ref objEntity);
            return objStore;
        }
        #endregion
    }
}
