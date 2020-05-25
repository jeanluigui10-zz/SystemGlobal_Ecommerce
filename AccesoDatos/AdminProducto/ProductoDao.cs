using Dominio.Result;
using Dominio.Result.Producto;
using Libreria.AdminConexion;
using Libreria.Base;
using Libreria.General;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Dominio.Entidades.SucursalProducto;

namespace AccesoDatos.AdminProducto
{
    public class ProductoDao
    {
        #region Singleton
        private static ProductoDao _instancia = null;
        public static ProductoDao Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ProductoDao();
                }
                return _instancia;
            }
        }
        #endregion Singleton


        #region Metodos Mostrar Data
        public ProductoResultado ListaProdctosPorComercio(Int32 comercioId, ref MetodoRespuesta respuesta)
        {
            ProductoResultado productoResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Producto_Lista_Porcomercio_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@Comercio", comercioId);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        productoResultado = new ProductoResultado();
                        while (sqlDataReader.Read())
                        {
                            productoResultado.Datos.Add(new ProductoResultadoDTO()
                            {
                                IdProductoCifrado = HttpUtility.UrlEncode(Encriptador.Encriptar(Convert.ToString(sqlDataReader["Idproducto"]))),
                                Sku = Convert.ToString(sqlDataReader["Sku"]),
                                ProductoNombre = Convert.ToString(sqlDataReader["Productonombre"]),
                                ProductoDescripcion = Convert.ToString(sqlDataReader["Productodescripcion"]),
                                Simbolo = Convert.ToString(sqlDataReader["Simbolo"]),
                                Precio = Convert.ToDecimal(sqlDataReader["Precio"]),
                                PrecioOferta = Convert.ToDecimal(sqlDataReader["PrecioOferta"]),
                                Esoferta = Convert.ToBoolean(sqlDataReader["EsOferta"]),
                                CategoriaNombre = Convert.ToString(sqlDataReader["Categorianombre"]),
                                NombreRecurso = "http://elcanastonxcorporate.tk" + Convert.ToString(sqlDataReader["NombreRecurso"]),
                                MarcaNombre = Convert.ToString(sqlDataReader["Marcanombre"]),
                                UnidadMinima = Convert.ToInt32(sqlDataReader["Unidadminima"]),
                                UnidadMaxima = Convert.ToInt32(sqlDataReader["Unidadmaxima"]),
                                Estado = Convert.ToBoolean(sqlDataReader["Estado"]),

                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    respuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, exception.Message);
                }
            }
            return productoResultado;
        }
        public ProductoResultado ListaProdctosPor_Comercio_Categoria(Int32 IdComercio, Int32 IdCategoria, ref MetodoRespuesta metodoRespuesta)
        {
            ProductoResultado productoResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Producto_ListaPor_Comercio_Categoria_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@IdComercio", IdComercio);
                    sqlCommand.Parameters.AddWithValue("@IdCategoria", IdCategoria);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        productoResultado = new ProductoResultado();
                        while (sqlDataReader.Read())
                        {
                            productoResultado.Datos.Add(new ProductoResultadoDTO()
                            {
                                IdProducto = Convert.ToInt32(sqlDataReader["IdProducto"]),
                                IdCategoria = Convert.ToInt32(sqlDataReader["IdCategoria"]),
                                Sku = Convert.ToString(sqlDataReader["Sku"]),
                                ProductoNombre = Convert.ToString(sqlDataReader["ProductoNombre"]),
                                ProductoDescripcion = Convert.ToString(sqlDataReader["ProductoDescripcion"]),
                                ProductoDescripcionLarga = Convert.ToString(sqlDataReader["ProductoDescripcionLarga"]),
                                Simbolo = Convert.ToString(sqlDataReader["Simbolo"]),
                                Precio = Convert.ToDecimal(sqlDataReader["Precio"]),
                                PrecioOferta = Convert.ToDecimal(sqlDataReader["PrecioOferta"]),
                                Esoferta = Convert.ToBoolean(sqlDataReader["EsOferta"]),
                                CategoriaNombre = Convert.ToString(sqlDataReader["CategoriaNombre"]),
                                NombreRecurso = "http://elcanastonxcorporate.tk" + Convert.ToString(sqlDataReader["NombreRecurso"]),
                                MarcaNombre = Convert.ToString(sqlDataReader["MarcaNombre"]),
                                UnidadMinima = Convert.ToInt32(sqlDataReader["UnidadMinima"]),
                                UnidadMaxima = Convert.ToInt32(sqlDataReader["UnidadMaxima"]),
                                Estado = Convert.ToBoolean(sqlDataReader["Estado"]),

                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, exception.Message);
                }
            }
            return productoResultado;
        }
        public ProductoResultado ObtenerPrductoPorId(Int32 productId, ref MetodoRespuesta respuesta)
        {
            ProductoResultado productoResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Producto_PorId_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@Productid", productId);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        productoResultado = new ProductoResultado();
                        while (sqlDataReader.Read())
                        {
                            productoResultado.Datos.Add(new ProductoResultadoDTO()
                            {
                                IdProducto = Convert.ToInt32(sqlDataReader["Idproducto"]),
                                Sku = Convert.ToString(sqlDataReader["Sku"]),
                                ProductoNombre = Convert.ToString(sqlDataReader["Productonombre"]),
                                ProductoDescripcion = Convert.ToString(sqlDataReader["Productodescripcion"]),
                                ProductoDescripcionLarga = Convert.ToString(sqlDataReader["ProductodescripcionLarga"]),
                                UnidadMinima = Convert.ToInt32(sqlDataReader["Unidadminima"]),
                                UnidadMaxima = Convert.ToInt32(sqlDataReader["Unidadmaxima"]),
                                Precio = Convert.ToDecimal(sqlDataReader["Precio"]),
                                Esoferta = Convert.ToBoolean(sqlDataReader["Esoferta"]),
                                IdCategoria = Convert.ToInt32(sqlDataReader["Idcategoria"]),
                                CategoriaNombre = Convert.ToString(sqlDataReader["Categorianombre"]),
                                IdMarca = Convert.ToInt32(sqlDataReader["Idmarca"]),
                                MarcaNombre = Convert.ToString(sqlDataReader["Marcanombre"]),

                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    respuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, exception.Message);
                }
            }
            return productoResultado;
        }
        #endregion Metodos Mostrar Data


        #region Metodos para carrito
        public Producto Obtener_Para_Carrito(ref MetodoRespuesta metodoRespuesta, Int32 idProducto)
        {
            Producto producto = null;

            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    Int16 indiceTabla = 0;
                    SqlCommand sqlCommand = new SqlCommand("Producto_Para_Carrito_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@idProducto", idProducto);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        do
                        {
                            if (indiceTabla == 0)
                            {
                                if (sqlDataReader.Read())
                                {
                                    producto = new Producto();
                                    producto.IdProductoCifrado = HttpUtility.UrlEncode(Encriptador.Encriptar(Convert.ToString(sqlDataReader["IdProducto"])));
                                    producto.SKU = Convert.ToString(sqlDataReader["Codigo"]);
                                    producto.ProductoNombre = Convert.ToString(sqlDataReader["ProductoNombre"]);
                                    producto.EsVentaPorMayor = Convert.ToBoolean(sqlDataReader["EsVentaPorMayor"]);
                                }
                            }
                            else
                            {
                                while (sqlDataReader.Read())
                                {
                                    producto.ProductoPrecio.PrecioRango.Add(new ProductoPrecioRango()
                                    {
                                        UnidadMinima = Convert.ToInt32(sqlDataReader["UnidadMinima"]),
                                        UnidadMaxima = Convert.ToInt32(sqlDataReader["UnidadMaxima"]),
                                        Precio = Convert.ToDecimal(sqlDataReader["Precio"]),
                                        PrecioFormateado = Convert.ToString(sqlDataReader["PrecioFormateado"]),
                                    });
                                }
                            }
                            indiceTabla++;
                        } while (sqlDataReader.NextResult());
                    }
                }
                catch (Exception exception)
                {
                    metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error);
                    throw exception;
                }
            }

            return producto;
        }

        #endregion Producto para carrito



    }
}
