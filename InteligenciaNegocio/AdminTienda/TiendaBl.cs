using AccesoDatos.AdminTienda;
using Dominio.Entidades;
using Libreria.Base;
using Libreria.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteligenciaNegocio.AdminTienda
{
    public class TiendaBl
    {
        #region Singleton
        private static TiendaBl _instancia = null;
        public static TiendaBl Instancia
        {
            get
            {
                return _instancia == null ? new TiendaBl() : _instancia;
            }
        }

        #endregion Singleton


        #region Metodos

        public Tienda Obtener(ref MetodoRespuesta metodoRespuesta, String urlDominio)
        {
            Tienda tienda = null;
            try
            {
                tienda = TiendaDao.Instancia.Obtener(urlDominio);
                if(tienda.Estado == Convert.ToBoolean(EnumGlobalEstado.Inactivo))
                {
                    String mensaje = String.Format("{0} {1} {2}", "La Tienda", tienda.ComercioNombre, "Se encuentra fuera de servicio.");
                    metodoRespuesta = new MetodoRespuesta(EnumTipoMensaje.Informacion, mensaje);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return tienda;
        }

        #endregion Metodos
    }
}
