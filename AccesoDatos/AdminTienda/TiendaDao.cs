using Dominio.Entidades.Comercio;
using Libreria.AdminConexion;
using Libreria.Base;
using Libreria.General;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.AdminTienda
{
    public class TiendaDao
    {
        #region Singleton
        private static TiendaDao _instancia = null;
        public static TiendaDao Instancia
        {
            get
            {
                return _instancia == null ? new TiendaDao() : _instancia;
            }
        }

        #endregion Singleton


        #region Metodos

        public Tienda Obtener(String urlDominio)
        {
            Tienda tienda = null;

            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Comercio_Por_UrlDominio_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@urlDominio", urlDominio);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        tienda = new Tienda();
                        while (sqlDataReader.Read())
                        {
                            tienda.IdComercio = Convert.ToInt16(sqlDataReader["IdComercio"]);
                            tienda.ComercioNombre = Convert.ToString(sqlDataReader["ComercioNombre"]);
                            tienda.URL = Convert.ToString(sqlDataReader["UrlDominio"]);
                            tienda.Estado = Convert.ToBoolean(sqlDataReader["Estado"]);
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }

            return tienda;
        }


        public MetodoRespuesta Contactanos_Guardar_Mensaje(TiendaContacto tiendaContacto)
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Exito);
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Comercio_Contacto_Guardar_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@idComercio", tiendaContacto.Tienda.IdComercio);
                    sqlCommand.Parameters.AddWithValue("@nombre", tiendaContacto.Nombre);
                    sqlCommand.Parameters.AddWithValue("@email", tiendaContacto.Email);
                    sqlCommand.Parameters.AddWithValue("@asunto", tiendaContacto.Asunto);
                    sqlCommand.Parameters.AddWithValue("@mensaje", tiendaContacto.Mensaje);

                    Int32 filasAfectadas = sqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Exito);
                    }
                }
                catch (Exception exception)
                {
                    metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error);
                }
            }
            return metodoRespuesta;
        }



        #endregion Metodos

    }
}
