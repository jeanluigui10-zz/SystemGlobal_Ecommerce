using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web;

namespace Libreria.General
{
    public class Log
    {
        private static void Grabar<T>(T obj, string archivo)
        {
            //GetType() apunta a la clase
            //GetProperties() saca las propiedades de la clase apuntada
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            using (StreamWriter sw = new StreamWriter(archivo, true))
            {
                object valor = null;
                foreach (PropertyInfo propiedad in propiedades)
                {   //si objeto es de tipo array se coloca un indice si no null
                    valor = propiedad.GetValue(obj, null);
                    //WriteLine ya tiene formateador en este caso va a grabar el nombre y su valor de la propiedad
                    sw.WriteLine("{0} = {1}", propiedad.Name, valor != null ? valor : "");
                }
                sw.WriteLine(new string('_', 60));
            }
        }

        public static void Save(string TipoLog, string MensajeError, string DetalleError)
        {
            String archivoLog = ConfigurationManager.AppSettings["rutaArchivoLog"];
            beLog obeLog = new beLog();
            obeLog.TipoLog = TipoLog;
            obeLog.Usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;//saca usuario del IIS, tambien se puede sacar del session, del request ,,etc
            obeLog.Aplicacion = ConfigurationManager.AppSettings["aplicacion"];
            obeLog.FechaHora = DateTime.Now;
            obeLog.MensajeError = MensajeError;
            obeLog.DetalleError = DetalleError;
            obeLog.IP_Cliente = HttpContext.Current.Request.UserHostAddress;//no funciona cuando es local , funciona cuando ya esta en red
            Grabar(obeLog, archivoLog);
        }
    }

    
    public class beLog
    {
        public string TipoLog { get; set; }
        public string Usuario { get; set; }
        public string Aplicacion { get; set; }
        public DateTime FechaHora { get; set; }
        public string MensajeError { get; set; }
        public string DetalleError { get; set; }
        public string IP_Cliente { get; set; }
    }
}
