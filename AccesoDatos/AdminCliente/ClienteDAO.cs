using Dominio.Result.Cliente;
using Dominio.TablasTipo;
using Libreria.AdminConexion;
using Libreria.General;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

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
                    SqlCommand command = new SqlCommand("Cliente_Por_EmailContrasenha_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@contrasenha", contrasenha);
                    command.Parameters.AddWithValue("@idComercio", idComercio);

                    using (SqlDataReader sqlDataReader = command.ExecuteReader())
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

        public Boolean RegistrarCliente(ClienteTablaTipo cliente, DireccionTablaTipo direccion)
        {
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand command = new SqlCommand("Cliente_Registro_Pa", sqlConnection) 
                    { 
                        CommandType = CommandType.StoredProcedure 
                    };
                    SqlParameter parameterCliente = command.Parameters.AddWithValue("@cliente", cliente);
                    parameterCliente.SqlDbType = SqlDbType.Structured;
                    parameterCliente.TypeName = "dbo.Tipo_Cliente";

                    SqlParameter parameterDireccion = command.Parameters.AddWithValue("@direccion", direccion);
                    parameterDireccion.SqlDbType = SqlDbType.Structured;
                    parameterDireccion.TypeName = "dbo.Tipo_Direccion";

                    Int32 countInserciones = command.ExecuteNonQuery();
                    return  countInserciones > 0? true: false;
                }
                catch (Exception e)
                {
                    Log.Save("Error", "ClienteDao: "+ e.Message, e.StackTrace);
                    return false;
                }
            }
        }

        public Boolean Cliente_Existe_PorEmail(String email, Int16 idComercio)
        {
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand command = new SqlCommand("Cliente_Validar_Por_Email_Pa", sqlConnection)
                    { 
                        CommandType = CommandType.StoredProcedure 
                    };
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@idComercio", idComercio);
                    
                    Byte contEmailxUsuario = Convert.ToByte(command.ExecuteScalar());
                    if (contEmailxUsuario > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Log.Save("Error", "ClienteDao: " + ex.Message, ex.StackTrace);
                    throw ex;
                }
            }
        }




        #endregion Metodos

    }
}
