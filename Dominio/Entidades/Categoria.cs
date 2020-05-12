using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Categoria
    {
        public Int16 IdCategoria { get; set; }

        public String CategoriaNombre { get; set; }

        public String CategoriaDescripcion { get; set; }

        public Boolean Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Int32 CreadoPor { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public Int32? ActualizadoPor { get; set; }
    }
}
