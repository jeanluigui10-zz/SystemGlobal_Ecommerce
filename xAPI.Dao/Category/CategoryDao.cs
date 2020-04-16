using System;
using System.Data;
using System.Data.SqlClient;
using xAPI.Library.Base;
using xAPI.Library.Connection;

namespace xAPI.Dao.Category
{
    public class CategoryDao
    {
        #region Singleton
        private static CategoryDao instance = null;
        public static CategoryDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDao();
                return instance;
            }
        }
        #endregion

        public DataTable CategoryProduct_GetList(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("CategoryProduct_GetList_Sp", clsConnection.GetConnection())
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
