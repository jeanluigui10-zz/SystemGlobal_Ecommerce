using AccesoDatos.AdminCliente;
using Dominio.Result.Cliente;
using Dominio.TablasTipo;
using Libreria.General;
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

        public ClienteResultadoDTO ObtenerCliente_EmailContrasenha(String email, String contrasenha, Int16 idComercio)
        {
            ClienteResultadoDTO objCliente = null;
            try
            {
                if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(contrasenha) && idComercio > 0)
                {
                    objCliente = ClienteDao.Instancia.ObtenerCliente_EmailContrasenha(email, contrasenha, idComercio);
                }
            }
            catch (Exception e)
            {
                Log.Save("Error", "ClienteBl:" + e.Message, e.Message);
                throw e;
            }
            return objCliente;
        }

        public Boolean Cliente_Registrar(ClienteTablaTipo cliente, DireccionTablaTipo direccion)
        {
            Boolean registroExitoso = false;
            try
            {
                if (cliente != null && direccion != null)
                {
                    registroExitoso = ClienteDao.Instancia.Cliente_Registrar(cliente, direccion);
                }
            }
            catch (Exception e)
            {
                Log.Save("Error", "ClienteBl: " + e.Message, e.Message);
                registroExitoso = false;
            }
            return registroExitoso;
        }

        public ClienteResultadoDTO Cliente_RecuperarContrasenha(String email, Int16 idComercio)
        {
            try
            {
                ClienteResultadoDTO objCliente = ClienteDao.Instancia.Cliente_RecuperarContrasenha(email, idComercio);
                return objCliente;
            }
            catch (Exception e)
            {
                Log.Save("Error", "ClienteBl: " + e.Message, e.Message);
                throw e;
            }
        }
        #endregion Metodos

    }
}
