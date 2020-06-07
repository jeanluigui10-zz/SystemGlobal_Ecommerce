using Dominio.Result.Cliente;
using Dominio.TablasTipo;
using Libreria.AdminConexion;
using Libreria.General;
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

        public ClienteResultadoDTO ObtenerCliente_EmailContrasenha(String email, String contrasenha, Int16 idComercio)
        {
            ClienteResultadoDTO objCliente = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand command = new SqlCommand("Cliente_Por_EmailContrasenha_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@contrasenha", contrasenha);
                    command.Parameters.AddWithValue("@idComercio", idComercio);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            objCliente = new ClienteResultadoDTO();
                            while (reader.Read())
                            {
                                objCliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                                objCliente.IdDocumentoTipo = Convert.ToByte(reader["IdDocumentoTipo"]);
                                objCliente.IdComercio = Convert.ToInt16(reader["IdComercio"]);
                                objCliente.Nombre = Convert.ToString(reader["Nombre"]);
                                objCliente.ApellidoPaterno = Convert.ToString(reader["ApellidoPaterno"]);
                                objCliente.ApellidoMaterno = Convert.ToString(reader["ApellidoMaterno"]);
                                objCliente.NumeroDocumento = Convert.ToString(reader["NumeroDocumento"]);
                                objCliente.Celular = Convert.ToString(reader["Celular"]);
                                objCliente.Telefono = Convert.ToString(reader["Telefono"]);
                                objCliente.Email = Convert.ToString(reader["Email"]);
                                objCliente.Estado = Convert.ToBoolean(reader["Estado"]);
                            } 
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Save("Error", "ClienteDao: " + e.Message, e.StackTrace);
                    throw e;
                }
            }
            return objCliente;
        }

        public Boolean Cliente_Registrar(ClienteTablaTipo cliente, DireccionTablaTipo direccion)
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

        public ClienteResultadoDTO Cliente_Por_Email(String email, Int16 idComercio)
        {

            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                ClienteResultadoDTO objCliente = null;
                try
                {
                    SqlCommand command = new SqlCommand("Cliente_Por_Email_Pa", sqlConnection)
                    { 
                        CommandType = CommandType.StoredProcedure 
                    };
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@idComercio", idComercio);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            objCliente = new ClienteResultadoDTO();
                            while (reader.Read())
                            {
                                objCliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                                objCliente.Nombre = Convert.ToString(reader["Nombre"]);
                                objCliente.ApellidoPaterno = Convert.ToString(reader["ApellidoPaterno"]);
                                objCliente.ApellidoMaterno = Convert.ToString(reader["ApellidoMaterno"]);
                                objCliente.Email = Convert.ToString(reader["Email"]);
                                objCliente.Contrasenha = Convert.ToString(reader["Contrasenha"]);
                            }
                            return objCliente;
                        }
                        else {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Save("Error", "ClienteDao: " + ex.Message, ex.StackTrace);
                    throw ex;
                }
            }
        }


        public Boolean ActualizarClave_PorIdCliente_IdComercio(Int32 idCliente, Int16 idComercio, String password)
        {
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand command = new SqlCommand("Actualizar_Clave_Por_ClienteComercio_Pa", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.Parameters.AddWithValue("@idComercio", idComercio);
                    command.Parameters.AddWithValue("@password", password);

                    Int32 countInserciones = command.ExecuteNonQuery();
                    return countInserciones > 0 ? true : false;
                }
                catch (Exception e)
                {
                    Log.Save("Error", "ClienteDao: " + e.Message, e.StackTrace);
                    return false;
                }
            }
        }
        #endregion Metodos

    }
}
