using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Result.Orden
{
    public class HistoricoDetalleResultado
    {
        public HistoricoDetalleResultado()
        {
            Datos = new List<HistoricoDetalleDTO>();
        }
        public List<HistoricoDetalleDTO> Datos { get; set; }
    }


    public class HistoricoDetalleDTO
    {
        public Int32 IdOrden { get; set; }
        public String IdProductoCifrado { get; set; }
        public String NombreProducto { get; set; }
        public String CodigoProducto { get; set; }
        public Int32 Cantidad { get; set; }
        public String Precio { get; set; }
        public String Total { get; set; }
    }
}
