using System;
using System.Web.UI;
using Libreria.General;

namespace PeruStore.src.ConfiguracionAplicacion
{
    public class PaginaBase: Page
    {

        public void Mensaje(EnumTipoMensaje tipo, String mensaje)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>Fn_Mensaje('" + tipo.ObtenerString() + "', '" + mensaje + "');</script>", false);
        }


    }
}