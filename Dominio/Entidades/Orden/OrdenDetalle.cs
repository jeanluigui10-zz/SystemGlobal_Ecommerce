using System;
using Dominio.Entidades.SucursalProducto;
using Dominio.Entidades.Comercio;

namespace Dominio.Entidades.Orden
{
    public class OrdenDetalle
    {
        public Int32 IdOrdenDetalle { get; set; }
        public Producto Producto { get; set; }
        public Sucursal Sucursal { get; set; }
        public Decimal Precio { get; set; }
        public Int32 Cantidad { get; set; }
        public Decimal Total { get; set; }
    }
}
