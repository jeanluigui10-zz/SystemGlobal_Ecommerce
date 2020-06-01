﻿using System;
using System.Web;
using System.Web.UI;
using Dominio.Entidades.Comercio;
using InteligenciaNegocio.AdminTienda;
using Libreria.Base;
using Libreria.General;
using PeruStore.src.BaseAplicacion;

namespace PeruStore.src.ConfiguracionAplicacion
{
    public class PaginaBase: Page
    {

        public void Mensaje(EnumCodigoRespuesta tipo, String mensaje)
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta(tipo);
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>Fn_Mensaje('" + metodoRespuesta.CodigoMensajeJs() + "', '" + mensaje + "');</script>", false);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            CrearSesionTienda();
            base.OnPreLoad(e);
        }
        private void CrearSesionTienda()
        {
            try
            {
                String urlDominio = HttpContext.Current.Request.Url.Host;
                if (ReglasSesion.EsOtraTienda(urlDominio))
                {
                    SesionAplicacion.LimpiarSesion(); // limpia todas las sesiones(ordenes, cliente, tienda)
                    MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
                    Tienda tienda = TiendaBl.Instancia.Obtener(ref metodoRespuesta, urlDominio);

                    metodoRespuesta.Datos = tienda; // falta agregar logica mostrar pagina de tienda fuera de servicio
                    SesionAplicacion.SesionTienda = tienda;
                }
            }
            catch (Exception exception)
            {
                throw exception; // mostrar pagina error. 
            }
        }


    }
}