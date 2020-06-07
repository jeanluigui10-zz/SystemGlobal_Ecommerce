using AccesoDatos.Configuraciones;
using Dominio.Result;
using Libreria.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteligenciaNegocio.Configuraciones
{
    public class EmailConfiguracionBl
    {
        #region Singleton
        private static EmailConfiguracionBl _instancia = null;
        public static EmailConfiguracionBl Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new EmailConfiguracionBl();
                }
                return _instancia;
            }
        }
        #endregion Singleton

        #region Metodos
        public Email_ConfiguracionDTO EmailConfiguration_Por_Comercio( Int16 idComercio)
        {
            try
            {
                Email_ConfiguracionDTO objEmailConfiguracion = EmailConfiguracionDao.Instancia.EmailConfiguration_Por_Comercio(idComercio);
                return objEmailConfiguracion;
            }
            catch (Exception e)
            {
                Log.Save("Error", "EmailConfiguracionBl: " + e.Message, e.Message);
                throw e;
            }
        }
        #endregion Metodos
    }
}
