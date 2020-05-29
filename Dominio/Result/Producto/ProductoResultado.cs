using System;
using System.Collections.Generic;

namespace Dominio.Result.Producto
{
    public class ProductoResultado
    {
        public ProductoResultado()
        {
            Datos = new List<ProductoResultadoDTO>();
            DetalleImagen = new List<DetalleImagenDTO>();
            DetalleOferta = new List<DetalleOfertaDTO>();
            DetalleColor = new List<DetalleColorDTO>();
            DetalleTalla = new List<DetalleTallaDTO>();
            DetalleSucursal = new List<DetalleSucursalDTO>();
        }
        public List<ProductoResultadoDTO> Datos { get; set; }
        public List<DetalleImagenDTO> DetalleImagen { get; set; }
        public List<DetalleOfertaDTO> DetalleOferta { get; set; }
        public List<DetalleColorDTO> DetalleColor { get; set; }
        public List<DetalleTallaDTO> DetalleTalla { get; set; }
        public List<DetalleSucursalDTO> DetalleSucursal { get; set; }
            
        }
    public class ProductoResultadoDTO
    {
        public Int32 IdProducto { get; set; }
        public String IdProductoCifrado { get; set; }
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
        public Int32 IdSucursal { get; set; }
        public String IdSucursalCifrado { get; set; }

    }

    public class DetalleImagenDTO
    {
        public Int32 IdProducto { get; set; }
        public String ArchivoNombre { get; set; }
        public String ArchivoExtension { get; set; }
        public String NombreRecurso { get; set; }
    }

    public class DetalleOfertaDTO
    {
        public Int32 IdProducto { get; set; }
        public String SucursalNombre { get; set; }
        public String Simbolo { get; set; }
        public Decimal Precio { get; set; }
        public Int32 UnidadMinima { get; set; }
        public Int32 UnidadMaxima { get; set; }
        public DateTime VigenteDesde { get; set; }
        public DateTime VigenteHasta { get; set; }
        public String OfertaNombre { get; set; }

    }
    public class DetalleColorDTO
    {
        public Int32 IdColor { get; set; }
        public String DescripcionColor { get; set; }
        public Int32 Stock { get; set; }

    }
    public class DetalleTallaDTO
    {
        public Int32 IdTalla { get; set; }
        public String DescripcionTalla { get; set; }
        public Int32 Stock { get; set; }
    }
    public class DetalleSucursalDTO
    {
        public Int16 IdSucursal { get; set; }
        public String SucursalNombre { get; set; }
        public String Direccionprimaria { get; set; }
        public String Localidad { get; set; }
        public Int32 Stock { get; set; }
    }
}
