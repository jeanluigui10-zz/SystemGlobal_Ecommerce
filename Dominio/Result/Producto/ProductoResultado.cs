using System;
using System.Collections.Generic;

namespace Dominio.Result.Producto
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
        public Int32 IdProducto { get; set; }
        public String IdProductoEncriptado { get; set; }
        public String Sku { get; set; }
        public String ProductoNombre { get; set; }
        public String ProductoDescripcion { get; set; }
        public String ProductoDescripcionLarga { get; set; }
        public String NombreRecurso { get; set; }
        public Int32 UnidadMinima { get; set; }
        public Int32 UnidadMaxima { get; set; }
        public Decimal Precio { get; set; }
        public Decimal PrecioOferta { get; set; }
        public String Simbolo { get; set; }
        public Boolean Esoferta { get; set; }
        public Int32 IdCategoria { get; set; }
        public String CategoriaNombre { get; set; }
        public Int32 IdMarca { get; set; }
        public String MarcaNombre { get; set; }
        public Boolean Estado { get; set; }
    }

}
