using Dominio.Result.Cliente;
using Libreria.AdminConexion;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.AdminCliente
{
    public class ClienteDao
    {
        #region Singleton
        private static ClienteDao _instancia = null;
        public static ClienteDao Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ClienteDao();
                }
                return _instancia;
            }
        }
        #endregion Singleton


        #region Metodos

        public ClienteResultado ObtenerCliente_EmailContrasenha(String email, String contrasenha, Int16 idComercio)
        {
            ClienteResultado objCliente = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Cliente_Por_EmailContrasenha_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@contrasenha", contrasenha);
                    sqlCommand.Parameters.AddWithValue("@idComercio", idComercio);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        objCliente = new ClienteResultado();
                        while (sqlDataReader.Read())
                        {
                            objCliente.Datos.Add(new ClienteResultadoDTO()
                            {
                                IdDocumentoTipo = Convert.ToInt16(sqlDataReader["IdDocumentoTipo"]),
                                IdComercio = Convert.ToInt32(sqlDataReader["IdComercio"]),
                                Nombre = Convert.ToString(sqlDataReader["Nombre"]),
                                ApellidoPaterno = Convert.ToString(sqlDataReader["ApellidoPaterno"]),
                                ApellidoMaterno = Convert.ToString(sqlDataReader["ApellidoMaterno"]),
                                NumeroDocumento = Convert.ToString(sqlDataReader["NumeroDocumento"]),
                                Celular = Convert.ToString(sqlDataReader["Celular"]),
                                Telefono = Convert.ToString(sqlDataReader["Telefono"]),
                                Email = Convert.ToString(sqlDataReader["Email"]),
                                Estado = Convert.ToBoolean(sqlDataReader["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return objCliente;
        }


        #endregion Metodos

    }
}
