using System;
using System.Collections.Generic;

namespace Dominio.Result
{
    public class CategoriaResultado
    {
        public CategoriaResultado() 
        {
            Datos = new List<CategoriaDTO>();
            DatosSubCategoria = new List<CategoriaDTO>();
            DatosSubCategoriaDetalle = new List<CategoriaDTO>();
        }
        public List<CategoriaDTO> Datos { get; set; }
        public List<CategoriaDTO> DatosSubCategoria { get; set; }
        public List<CategoriaDTO> DatosSubCategoriaDetalle { get; set; }

    }

    public class CategoriaDTO {
        public Int16 IdCategoria { get; set; }
        public Int16 IdSubCategoriaDetalle { get; set; }
        public Int16 IdSubCategoria { get; set; }
        public String IdCategoriaEncriptado { get; set; }
        public String IdSubCategoriaDetalleEncriptado { get; set; }
        public String IdSubCategoriaEncriptado { get; set; }
        public String SubCategoriaDetalleNombre { get; set; }
        public String CategoriaNombre { get; set; }
        public String RutaIcono { get; set; }
        public String RutaBanner { get; set; }
        public String SubCategoriaNombre { get; set; }
    }
  
}
