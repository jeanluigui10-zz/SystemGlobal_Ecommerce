using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Libreria.AdminConexion
{
    public class Conexion
    {
        //public static void DisposeCommand(SqlCommand cmd)
        //{
        //    try
        //    {
        //        if (cmd != null)
        //        {
        //            if (cmd.Connection != null)
        //            {
        //                cmd.Connection.Close();
        //                cmd.Connection.Dispose();
        //            }
        //            cmd.Dispose();
        //        }
        //    }
        //    catch { } //don't blow up
        //}


        //public static SqlConnection GetConnection(String DbConnection)
        //{
        //    SqlConnection objConexion = new SqlConnection(DbConnection);

        //    objConexion.Open();
        //    return objConexion;
        //}
        public static SqlConnection ObtenerConexion(String cadenaConexionDb)
        {
            SqlConnection sqlConnection = new SqlConnection(cadenaConexionDb);

            sqlConnection.Open();
            return sqlConnection;
        }
        //public static SqlConnection GetConnection()
        //{
        //    String connString = "";

        //    if (ConfigurationManager.ConnectionStrings["systemweb_db"] != null)
        //    {
        //        connString = ConfigurationManager.ConnectionStrings["systemweb_db"].ConnectionString;
        //    }

        //    SqlConnection objConexion = new SqlConnection(connString);

        //    objConexion.Open();
        //    return objConexion;
        //}

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
