using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Result.Orden
{
    public class EstadoResultado
    {
        public EstadoResultado()
        {
            Datos = new List<EstadoDto>();
        }
        public List<EstadoDto> Datos { get; set; }
    }

    public class EstadoDto
    {
        public Int32 IdOrden { get; set; }
        public String OrdenEstado { get; set; }
        public String FechaRegistro { get; set; }
    }
}
