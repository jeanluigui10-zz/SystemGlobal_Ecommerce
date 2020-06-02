using Dominio.Result.Orden;
using Libreria.AdminConexion;
using Libreria.General;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;

namespace AccesoDatos.AdminOrden
{
    public class ClienteOrdenDao
    {
        #region Singleton
        private static ClienteOrdenDao _instancia = null;
        public static ClienteOrdenDao Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ClienteOrdenDao();
                }
                return _instancia;
            }
        }
        #endregion Singleton


        #region Metodos

        public HistoricoResultado Historico(Int16 idComercio, Int32 idCliente)
        {
            HistoricoResultado historicoResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Cliente_Orden_Historico_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@idComercio", idComercio);
                    sqlCommand.Parameters.AddWithValue("@idCliente", idCliente);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        historicoResultado = new HistoricoResultado();
                        while (sqlDataReader.Read())
                        {
                            historicoResultado.Datos.Add(new HistoricoDTO()
                            {
                                IdOrden = Convert.ToInt32(sqlDataReader["IdOrden"]),
                                Cantidad = Convert.ToInt32(sqlDataReader["TotalArticulos"]),
                                Estado = Convert.ToString(sqlDataReader["OrdenEstado"]),
                                FechaOrden = Convert.ToDateTime(sqlDataReader["FechaOrden"], CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"),
                                TotalOrden = Convert.ToString(sqlDataReader["Total"]),
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return historicoResultado;
        }

        public HistoricoDTO HistoricoCabecera(Int32 idOrden)
        {
            HistoricoDTO historicoDTO = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Cliente_Orden_Cabecera_Informacion_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@idOrden", idOrden);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            historicoDTO = new HistoricoDTO()
                            {
                                IdOrden = Convert.ToInt32(sqlDataReader["IdOrden"]),
                                FechaOrden = Convert.ToDateTime(sqlDataReader["FechaCreacion"], CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"),
                                MetodoPago = Convert.ToString(sqlDataReader["MetodoPago"]),
                                TipoEntrega = Convert.ToString(sqlDataReader["TipoEntrega"]),
                                DireccionEntrega = Convert.ToString(sqlDataReader["DireccionEntrega"]),
                                Distrito = Convert.ToString(sqlDataReader["Distrito"]),
                                Provincia = Convert.ToString(sqlDataReader["Provincia"]),
                                Region = Convert.ToString(sqlDataReader["Region"]),
                                Zip = Convert.ToString(sqlDataReader["Zip"]),
                                SubTotal = Convert.ToString(sqlDataReader["SubTotal"]),
                                Impuesto = Convert.ToString(sqlDataReader["Impuesto"]),
                                PorcentajeImpuesto = Convert.ToString(sqlDataReader["PorcentajeImpuesto"]),
                                Descuento = Convert.ToString(sqlDataReader["Descuento"]),
                                DeliveryTotal = Convert.ToString(sqlDataReader["DeliveryTotal"]),
                                TotalOrden = Convert.ToString(sqlDataReader["Total"])
                            };
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                return historicoDTO;
            }
        }

        public HistoricoDetalleResultado HistoricoDetalle(Int32 idOrden)
        {
            HistoricoDetalleResultado historicoDetalleResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Orden_Detalle_Informacion_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@idOrden", idOrden);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        historicoDetalleResultado = new HistoricoDetalleResultado();
                        while (sqlDataReader.Read())
                        {
                            historicoDetalleResultado.Datos.Add(new HistoricoDetalleDTO()
                            {
                                IdOrden = Convert.ToInt32(sqlDataReader["IdOrden"]),
                                IdProductoCifrado = HttpUtility.UrlEncode(Encriptador.Encriptar(Convert.ToString(sqlDataReader["IdProducto"]))),
                                NombreProducto = Convert.ToString(sqlDataReader["ProductoNombre"]),
                                CodigoProducto = Convert.ToString(sqlDataReader["CodigoProducto"]),
                                Cantidad = Convert.ToInt32(sqlDataReader["Cantidad"]),
                                Precio = Convert.ToString(sqlDataReader["Precio"]),
                                Total = Convert.ToString(sqlDataReader["Total"]),
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return historicoDetalleResultado;
        }


        public EstadoResultado HistoricoEstado(Int32 idOrden)
        {
            EstadoResultado estadoResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Orden_Estado_Nota_Informacion_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@idOrden", idOrden);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        estadoResultado = new EstadoResultado();
                        while (sqlDataReader.Read())
                        {
                            estadoResultado.Datos.Add(new EstadoDto()
                            {
                                IdOrden = Convert.ToInt32(sqlDataReader["IdOrden"]),
                                OrdenEstado = Convert.ToString(sqlDataReader["OrdenEstado"]),
                                FechaRegistro = Convert.ToDateTime(sqlDataReader["FechaRegistro"], CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"),
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return estadoResultado;
        }


        #endregion Metodos
    }
}
