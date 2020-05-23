using Libreria.General;
using System;
using System.Web.UI;

namespace PeruStore.src.ConfiguracionAplicacion
{
    public class PaginaBaseControl: System.Web.UI.UserControl
    {
        public void Mensaje(EnumTipoMensaje tipo, String mensaje)
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>Fn_Mensaje('" + tipo.ObtenerString() + "', '" + mensaje + "');</script>", false);
        }
    }
}