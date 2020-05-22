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
            catch (Exception e)
            {
                Log.Save("Error", "ClienteBl:" + e.Message, e.Message);
                throw e;
            }
            return objCliente;
        }

        public Boolean RegistrarCliente(ClienteTablaTipo cliente, DireccionTablaTipo direccion) 
        {
            Boolean registroExitoso = false;
            try
            {
                if (cliente!= null && direccion!= null)
                {
                    registroExitoso = ClienteDao.Instancia.RegistrarCliente(cliente, direccion);
                }
            }
            catch (Exception e)
            {
                Log.Save("Error", "ClienteBl: " + e.Message, e.Message);
                registroExitoso = false;
            }
            return registroExitoso;
        }

        public Boolean Cliente_Existe_PorEmail(String email, Int16 idComercio) {
            Boolean existeCliente = false;
            try
            {
                existeCliente = ClienteDao.Instancia.Cliente_Existe_PorEmail(email, idComercio);
                return existeCliente;
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
