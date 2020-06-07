using System;

namespace Dominio.Entidades.Configuraciones
{
    public class Email_Configuracion
    {
        public Int16 IdComercio { get; set; }
        public String EmailFrom { get; set; }
        public String SMTP { get; set; }
        public Int32 Puerto { get; set; }
        public String Password { get; set; }
        public String UserName { get; set; }
        public Boolean Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public Int32 CreadoPor { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Int32? ActualizadoPor { get; set; }

    }

}
