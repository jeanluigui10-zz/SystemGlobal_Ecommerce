using System;

namespace Dominio.Entidades
{
    public class Cliente
    {
        public Int32 IdCliente { get; set; }
        public Byte? IdDocumentoTipo { get; set; }
        public Int16 IdComercio { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String NumeroDocumento { get; set; }
        public String Celular { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String Contrasenha { get; set; }
        public Boolean Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Int32 CreadoPor { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Int32? ActualizadoPor { get; set; }

    }

}
