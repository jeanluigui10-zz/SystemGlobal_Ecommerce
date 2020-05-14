using Dominio.Result.Orden;
using Libreria.AdminConexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

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

        public OrdenHistoricoResultado ObtenerHistorico(Int16 idComercio, Int32 idCliente)
        {
            OrdenHistoricoResultado ordenHistoricoResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Cliente_Orden_Historico_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@idComercio", idComercio);
                    sqlCommand.Parameters.AddWithValue("@idCliente", idCliente);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        ordenHistoricoResultado = new OrdenHistoricoResultado();
                        while (sqlDataReader.Read())
                        {
                            ordenHistoricoResultado.Datos.Add(new OrdenHistoricoDTO()
                            {
                                IdOrden = Convert.ToInt32(sqlDataReader["IdOrden"]),
                                Cantidad = Convert.ToInt32(sqlDataReader["TotalArticulos"]),
                                Estado = Convert.ToString(sqlDataReader["OrdenEstado"]),
                                FechaOrden = Convert.ToString(sqlDataReader["FechaOrden"]),
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
            return ordenHistoricoResultado;
        }


        #endregion Metodos
    }
}
