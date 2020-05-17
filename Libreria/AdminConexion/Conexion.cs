using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Libreria.AdminConexion
{
    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            String conexionString = "";

            if (ConfigurationManager.ConnectionStrings["systemweb_db"] != null)
            {
                conexionString = ConfigurationManager.ConnectionStrings["systemweb_db"].ConnectionString;
            }

            SqlConnection sqlConnection = new SqlConnection(conexionString);

            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
