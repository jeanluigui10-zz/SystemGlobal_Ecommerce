using System;

namespace Dominio.Entidades.SucursalProducto
{
    public class ProductoPrecioRango
    {
        public Int32 IdProductoPrecioRango { get; set; }
        public Int32 UnidadMinima { get; set; }
        public Int32 UnidadMaxima { get; set; }
        public Decimal Precio { get; set; }
        public String PrecioFormateado { get; set; }
        public Boolean? Estado { get; set; }
    }
}
