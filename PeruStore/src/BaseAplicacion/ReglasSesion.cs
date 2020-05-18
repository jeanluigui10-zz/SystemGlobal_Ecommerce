using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeruStore.src.BaseAplicacion
{
    public static class ReglasSesion
    {

        public static Boolean EsOtraTienda(String urlDominio)
        {
            if (SesionAplicacion.SesionTienda == null) return true;
            return SesionAplicacion.SesionTienda.URL == urlDominio ? false : true;
        }
    }
}