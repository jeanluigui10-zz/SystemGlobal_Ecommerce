using AccesoDatos.AdminTienda;
using Dominio.Entidades.Comercio;
using Libreria.Base;
using Libreria.General;
using System;
using Libreria.Base;

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
                if (tienda.Estado == Convert.ToBoolean(EnumGlobalEstado.Inactivo))
                {
                    String mensaje = String.Format("{0} {1} {2}", "La Tienda", tienda.ComercioNombre, "Se encuentra fuera de servicio.");
                    metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Informacion, mensaje);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return tienda;
        }

        public MetodoRespuesta Contactanos_Guardar_Mensaje(TiendaContacto tiendaContacto)
        {
            MetodoRespuesta metodoRespuesta = null;
            try
            {
                if (Validar.EsValido(tiendaContacto) && Validar.EsValido(tiendaContacto.Tienda))
                {
                    metodoRespuesta = TiendaDao.Instancia.Contactanos_Guardar_Mensaje(tiendaContacto);
                    if(metodoRespuesta.CodigoRespuesta == EnumCodigoRespuesta.Error)
                    {
                        metodoRespuesta.Mensaje = String.Format("{0}", "No se pudo enviar su consulta, intentalo otra vez.");
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return metodoRespuesta;
        }

        #endregion Metodos
    }
}
