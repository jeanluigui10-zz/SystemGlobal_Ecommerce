using System;

namespace Dominio.Entidades.SucursalProducto
{
    public class Producto
    {
        public Producto()
        {
            ProductoPrecio = new ProductoPrecio();
        }
        public Int32 IdProducto { get; set; }
        public String IdProductoCifrado { get; set; }
        public ProductoPrecio ProductoPrecio { get; set; }
        public Int16 IdCategoria { get; set; }
        public Int32 IdMarca { get; set; }
        public String SKU { get; set; }
        public String ProductoNombre { get; set; }
        public Boolean EsVentaPorMayor { get; set; }
        public Boolean EsOferta { get; set; }
        public String ArchivoNombre { get; set; }
        public String ProductoDescripcion { get; set; }
        public String ProductoDescripcionLarga { get; set; }
        public String ArchivoExtension { get; set; }
        public String ArchivoPublicoNombre { get; set; }
        public String UnidadMedida { get; set; }
        public String NombreRecurso { get; set; }
        public Boolean Estado { get; set; }
        public String TipoDocumento { get; set; }
        public Int16? EsCarga { get; set; }
    }

}
