using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
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
