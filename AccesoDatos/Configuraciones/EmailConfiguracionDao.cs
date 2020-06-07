using Dominio.Result;
using Libreria.AdminConexion;
using Libreria.General;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Configuraciones
{
    public class EmailConfiguracionDao
    {
        #region Singleton
        private static EmailConfiguracionDao _instancia = null;
        public static EmailConfiguracionDao Instancia
        {
            get
            {
                return _instancia == null ? new EmailConfiguracionDao() : _instancia;
            }
        }
        #endregion Singleton

        public Email_ConfiguracionDTO EmailConfiguration_Por_Comercio(Int16 idComercio)
        {
            Email_ConfiguracionDTO emailConfiguracion = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand command = new SqlCommand("Email_Configuration_Por_Comercio", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@idComercio", idComercio);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            emailConfiguracion = new Email_ConfiguracionDTO();
                            while (reader.Read())
                            {
                                emailConfiguracion.EmailFrom = Convert.ToString(reader["EmailFrom"]);
                                emailConfiguracion.SMTP = Convert.ToString(reader["SMTP"]);
                                emailConfiguracion.Puerto = Convert.ToInt32(reader["Puerto"]);
                                emailConfiguracion.Password = Convert.ToString(reader["Password"]);
                                emailConfiguracion.UserName = Convert.ToString(reader["UserName"]);
                                emailConfiguracion.ComercioNombre = Convert.ToString(reader["ComercioNombre"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Save("Error", "EmailConfigurationDao: " + ex.Message, ex.StackTrace);
                    throw ex;
                }
            }
            return emailConfiguracion;
        }
    }

}
