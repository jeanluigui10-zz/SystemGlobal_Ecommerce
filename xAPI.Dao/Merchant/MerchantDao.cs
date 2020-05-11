using System;
using System.Data;
using System.Data.SqlClient;
using xAPI.Library.Base;
using xAPI.Library.Connection;

namespace xAPI.Dao.Merchant
{
    public class MerchantDao
    {
        #region Singleton
        private static MerchantDao instance = null;
        public static MerchantDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new MerchantDao();
                return instance;
            }
        }
        #endregion

        public DataTable MethodPayment_GetList(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Merchant_List_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                Base.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  while loading data"));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return dt;
        }
    }
}
