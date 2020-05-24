using Dominio.Result.Producto;
using Libreria.AdminConexion;
using Libreria.Base;
using Libreria.General;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.AdminProducto
{
    public class CategoriaDao
    {
        #region Singleton
        private static CategoriaDao _instancia = null;
        public static CategoriaDao instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CategoriaDao();
                return _instancia;
            }
        }
        #endregion

        #region Metodos
        public CategoriaResultado SubCategoria_ObtenerLista_PorIdSubCategoria(ref MetodoRespuesta metodoRespuesta, Int32 IdSubCategoria)
        {
            CategoriaResultado categoriaResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("SubCategoria_Lista_ByIdSubCategoria_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@IdSubCategoria", IdSubCategoria);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        categoriaResultado = new CategoriaResultado();
                        while (sqlDataReader.Read())
                        {
                            categoriaResultado.DatosSubCategoriaDetalle.Add(new CategoriaDTO()
                            {
                                IdSubCategoria = Convert.ToInt16(sqlDataReader["IdSubCategoria"]),
                                IdSubCategoriaDetalle = Convert.ToInt16(sqlDataReader["IdSubCategoriaDetalle"]),
                                SubCategoriaDetalleNombre = Convert.ToString(sqlDataReader["SubCategoriaDetalleNombre"])
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, exception.Message);
                    throw exception;
                }
            }
            return categoriaResultado;
        }
        public CategoriaResultado SubCategoria_ObtenerLista_PorIdCategoria(ref MetodoRespuesta metodoRespuesta, Int16 IdCategoria)
        {
            CategoriaResultado categoriaResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("SubCategoria_Lista_ByIdCategoria_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@IdCategoria", IdCategoria);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        categoriaResultado = new CategoriaResultado();
                        while (sqlDataReader.Read())
                        {
                            categoriaResultado.DatosSubCategoria.Add(new CategoriaDTO()
                            {
                                IdCategoria = Convert.ToInt16(sqlDataReader["IdCategoria"]),
                                IdSubCategoria = Convert.ToInt16(sqlDataReader["IdSubCategoria"]),
                                IdSubCategoriaCifrado = Encriptador.Encriptar(Convert.ToString(sqlDataReader["IdSubCategoria"])),
                                SubCategoriaNombre = Convert.ToString(sqlDataReader["SubCategoriaNombre"])
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, exception.Message);
                    throw exception;
                }
            }
            return categoriaResultado;
        }
        public CategoriaResultado Categoria_ObtenerLista(ref MetodoRespuesta metodoRespuesta, Int32 IdComercio)
        {
            CategoriaResultado categoriaResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Categoria_Lista_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@IdComercio", IdComercio);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        categoriaResultado = new CategoriaResultado();
                        while (sqlDataReader.Read())
                        {
                            categoriaResultado.Datos.Add(new CategoriaDTO()
                            {
                                IdCategoria = Convert.ToInt16(sqlDataReader["IdCategoria"]),
                                IdCategoriaEncriptado = Encriptador.Encriptar(Convert.ToString(sqlDataReader["IdCategoria"])),
                                CategoriaNombre = Convert.ToString(sqlDataReader["CategoriaNombre"]),
                                RutaIcono = Convert.ToString(sqlDataReader["RutaIcono"]),
                                RutaBanner = Convert.ToString(sqlDataReader["RutaBanner"]),
                                RutaImagenDeslizante = Convert.ToString(sqlDataReader["RutaImagenDeslizante"]),

                            }); 
                        }
                    }
                }
                catch (Exception exception)
                {
                    metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, exception.Message);
                    throw exception;
                }
            }
            return categoriaResultado;
        }
        #endregion
    }
}
