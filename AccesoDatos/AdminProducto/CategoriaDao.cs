using Libreria.AdminConexion;
using Libreria.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.AdminProducto
{
    public class CategoriaDao
    {
        #region Singleton
        private static CategoriaDao instance = null;
        public static CategoriaDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoriaDao();
                return instance;
            }
        }
        #endregion

        public DataTable Categoria_Lista(ref MetodoRespuesta objRespuesta)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Categoria_Lista_Sp", Conexion.ObtenerConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                objRespuesta.Errors.Add(new MetodoRespuesta.ListError(ex, "An error occurred  while loading data"));
            }
            finally
            {
                //Conexion.DisposeCommand(cmd);
            }
            return dt;
        }
    }
}
