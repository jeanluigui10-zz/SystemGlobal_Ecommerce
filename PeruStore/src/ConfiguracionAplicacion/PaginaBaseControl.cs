using Libreria.Base;
using Libreria.General;
using System;
using System.Web.UI;

namespace PeruStore.src.ConfiguracionAplicacion
{
    public class PaginaBaseControl: UserControl
    {
        public void Mensaje(EnumCodigoRespuesta tipo, String mensaje)
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta(tipo);
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>Fn_Mensaje('" + metodoRespuesta.CodigoMensajeJs() + "', '" + mensaje + "');</script>", false);
        }
    }
}