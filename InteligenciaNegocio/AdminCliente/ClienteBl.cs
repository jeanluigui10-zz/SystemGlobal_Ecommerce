using AccesoDatos.AdminCliente;
using Dominio.Result.Cliente;
using System;

namespace InteligenciaNegocio.AdminCliente
{
    public class ClienteBl
    {
        #region Singleton
        private static ClienteBl _instancia = null;
        public static ClienteBl Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ClienteBl();
                }
                return _instancia;
            }
        }
        #endregion Singleton

        #region Metodos

        public ClienteResultado ObtenerCliente_EmailContrasenha(String email, String contrasenha, Int16 idComercio)
        {
            ClienteResultado objCliente = null;
            try
            {
                if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(contrasenha) && idComercio > 0)
                {
                    objCliente = ClienteDao.Instancia.ObtenerCliente_EmailContrasenha(email, contrasenha, idComercio);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return objCliente;
        }


        #endregion Metodos

    }
}
