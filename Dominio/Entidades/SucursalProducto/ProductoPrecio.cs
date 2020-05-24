using System;
using System.Collections.Generic;

namespace Dominio.Entidades.SucursalProducto
{
    public class ProductoPrecio
    {
        public ProductoPrecio()
        {
            PrecioRango = new List<ProductoPrecioRango>();
        }
        public Int32 IdProductoPrecio { get; set; }
        public List<ProductoPrecioRango> PrecioRango { get; set; }
        public DateTime VigenteDesde { get; set; }
        public DateTime? VigenciaHasta { get; set; }
        public Boolean? Estado { get; set; }
    }
}
