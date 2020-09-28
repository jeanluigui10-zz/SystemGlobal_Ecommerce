using xAPI.Library.Base;
using xAPI.Entity.Payment;
using xAPI.Dao.Payment;

namespace xAPI.BL.Payment
{
    public class CredentialBL
    {
        #region Singleton
        private static CredentialBL instance = null;
        public static CredentialBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CredentialBL();
                return instance;
            }
        }
        #endregion

        #region Methods
        public Credential Credential_GetInformation(ref BaseEntity objEntity)
        {
            objEntity = new BaseEntity();
            Credential objCredential = null;
            objCredential = CredentialDao.Instance.Credential_GetInformation(ref objEntity);
            return objCredential;
        }
        #endregion

    }
}
