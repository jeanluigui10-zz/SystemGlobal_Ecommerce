using System;
using System.Collections.Generic;

namespace Dominio.Result
{
    public class CategoriaResultado
    {
        public CategoriaResultado() 
        {
            Datos = new List<CategoriaDTO>();
        }
        public List<CategoriaDTO> Datos { get; set; }
    }

    public class CategoriaDTO {
        public Int16 IdCategoria { get; set; }
        public String CategoriaNombre { get; set; }
    }

}
