using System;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity.Payment;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Payment
{
    public class CredentialDao
    {
        #region Singleton
        private static CredentialDao instance = null;
        public static CredentialDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new CredentialDao();
                return instance;
            }
        }
        #endregion

        #region Methods
        public Credential Credential_GetInformation(ref BaseEntity objEntity)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Credential objCredential = new Credential();
            try
            {
                cmd = new SqlCommand("Credential_GetInformation_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objCredential = Credential_GetInfo(dr);
                }
            }
            catch (Exception ex)
            {
                objCredential = null;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  getting a AppResource by it's Id."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return objCredential;
        }

        private Credential Credential_GetInfo(SqlDataReader ObjDr)
        {
            Credential obj = new Credential
            {
                MerchantName = ObjDr.GetColumnValue<String>("MerchantName"),
                Public_Key = ObjDr.GetColumnValue<String>("Public_Key"),
                Secret_Key = ObjDr.GetColumnValue<String>("Secret_Key"),
                Currency = ObjDr.GetColumnValue<String>("Currency"),

            };
            return obj;
        }
        #endregion
    }
}
