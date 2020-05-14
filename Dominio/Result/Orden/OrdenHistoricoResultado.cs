using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Result.Orden
{

    public class OrdenHistoricoResultado
    {
        public OrdenHistoricoResultado()
        {
            Datos = new List<OrdenHistoricoDTO>();
        }
        public List<OrdenHistoricoDTO> Datos { get; set; }
    }

    public class OrdenHistoricoDTO
    {
        public Int32 IdOrden { get; set; }
        public String Estado { get; set; }
        public Int32 Cantidad { get; set; }
        public String FechaOrden { get; set; }
        public String TotalOrden { get; set; }

    }
}
