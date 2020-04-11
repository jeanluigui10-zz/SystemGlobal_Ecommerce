using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Library.Base;
using xAPI.Library.Connection;

namespace xAPI.Dao.Products
{
    public class ProductDao
    {
        #region Singleton
        private static ProductDao instance = null;
        public static ProductDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDao();
                return instance;
            }
        }
        #endregion

        public DataTable Products_GetList_ById(ref BaseEntity objEntity, Int32 ProductId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Products_GetList_ById_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@productId", ProductId);
                cmd.CommandTimeout = 0;
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  while loading data"));

            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return dt;
        }

    }
}
