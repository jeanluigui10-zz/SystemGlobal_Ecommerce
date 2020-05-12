using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Result
{
    public class CategoriaResultado
    {
        public List<CategoriaDTO> lstCategoria { get; set; }
    }

    public class CategoriaDTO {
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Perras { get; set; }

    }

}
