using System;

namespace Dominio.Entidades.Orden
{
    public class MetodoPago
    {
        public Int32 IdMetodoPago { get; set; }

        public String Nombre { get; set; }

        public Boolean Estado { get; set; }

        public Int32? EsSeleccionado { get; set; }

        public Byte GrupoId { get; set; }

        public Byte? TipoEntrada { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Int32 CreadoPor { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public Int32? ActualizadoPor { get; set; }

    }
}
