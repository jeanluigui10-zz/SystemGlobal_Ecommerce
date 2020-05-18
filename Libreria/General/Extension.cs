using System;
using System.Web;

namespace Libreria.General
{
    public static class Extension
    {

        public static T ObtenerSesion<T>(String nombreSesion)
        {
            T objGenerico = default(T);
            try
            {
                if (HttpContext.Current != null)
                {
                    objGenerico = (T)HttpContext.Current.Session[nombreSesion];
                }
                return (T)objGenerico;

            }
            catch { return default(T); }
        }


    }
}
