using System;
using System.Collections.Generic;

namespace Dominio.Result
{
    public class ProductoResultado
    {
        public ProductoResultado()
        {
            Datos = new List<ProductoResultadoDTO>();
        }
        public List<ProductoResultadoDTO> Datos { get; set; }
    }
    public class ProductoResultadoDTO
    {
        public Int32 Idproducto { get; set; }
        public String Sku { get; set; }
        public String Productonombre { get; set; }
        public String Productodescripcion { get; set; }
        public Int32 Unidadminima { get; set; }
        public Int32 Unidadmaxima { get; set; }
        public Decimal Precio { get; set; }
        public Boolean Esoferta { get; set; }
        public Int32 Idcategoria { get; set; }
        public String Categorianombre { get; set; }
        public Int32 Idmarca { get; set; }
        public String Marcanombre { get; set; }
        public Boolean Estado { get; set; }
    }

}
