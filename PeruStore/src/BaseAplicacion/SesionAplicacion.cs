using System.Web;
using Dominio.Entidades;
using Libreria.General;

namespace PeruStore.src.BaseAplicacion
{
    public class SesionAplicacion
    {

        public static Tienda SesionTienda
        {
            get { return Extension.ObtenerSesion<Tienda>("Tienda"); }
            set { HttpContext.Current.Session["Tienda"] = value; }
        }

        public static void AbandonarSesion()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
        }

    }
}