using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Orden
{
    public class EntregaTipo
    {
        public Byte IdEntregaTipo { get; set; }
        public String Descripcion { get; set; }
        public Decimal MontoMinimoEnvioFree { get; set; }
        public Decimal Costo { get; set; }
        public Boolean Estado { get; set; }

    }
}
