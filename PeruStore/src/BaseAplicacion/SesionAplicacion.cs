using System.Web;
using Dominio.Entidades.Comercio;
using Dominio.Entidades.Orden;
using Libreria.General;
using Dominio.Entidades;

namespace PeruStore.src.BaseAplicacion
{
    public static class SesionAplicacion
    {

        public static Tienda SesionTienda
        {
            get { return Extension.ObtenerSesion<Tienda>("Tienda"); }
            set { HttpContext.Current.Session["Tienda"] = value; }
        }

        public static Ordencabecera SesionOrdenCabecera
        {
            get { return Extension.ObtenerSesion<Ordencabecera>("OrdenCabecera"); }
            set { HttpContext.Current.Session["OrdenCabecera"] = value; }
        }

        public static Cliente SesionCliente
        {
            get { return Extension.ObtenerSesion<Cliente>("Cliente"); }
            set { HttpContext.Current.Session["Cliente"] = value; }
        }

        public static void LimpiarSesion()
        {
            HttpContext.Current.Session.Clear();
        }
        public static void AbandonarSesion()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}