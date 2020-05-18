using Dominio.Result;
using Libreria.AdminConexion;
using Libreria.Base;
using Libreria.General;
using System;
using System.Data;
using System.Data.SqlClient;

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


        #region Metodos

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
                                Idproducto = Convert.ToInt32(sqlDataReader["Idproducto"]),
                                Sku = Convert.ToString(sqlDataReader["Sku"]),
                                Productonombre = Convert.ToString(sqlDataReader["Productonombre"]),
                                Productodescripcion = Convert.ToString(sqlDataReader["Productodescripcion"]),
                                ProductodescripcionLarga = Convert.ToString(sqlDataReader["ProductodescripcionLarga"]),
                                Unidadminima = Convert.ToInt32(sqlDataReader["Unidadminima"]),
                                Unidadmaxima = Convert.ToInt32(sqlDataReader["Unidadmaxima"]),
                                Precio = Convert.ToDecimal(sqlDataReader["Precio"]),
                                Esoferta = Convert.ToBoolean(sqlDataReader["Esoferta"]),
                                Idcategoria = Convert.ToInt32(sqlDataReader["Idcategoria"]),
                                Categorianombre = Convert.ToString(sqlDataReader["Categorianombre"]),
                                Idmarca = Convert.ToInt32(sqlDataReader["Idmarca"]),
                                Marcanombre = Convert.ToString(sqlDataReader["Marcanombre"]),

                            }); 
                        }
                    }
                }
                catch (Exception exception)
                {
                    respuesta = new MetodoRespuesta(EnumTipoMensaje.Error, exception.Message);
                }
            }
            return productoResultado;
        }


        #endregion Metodos
    }
}
