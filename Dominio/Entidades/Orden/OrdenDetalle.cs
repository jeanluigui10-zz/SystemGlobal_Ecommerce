using System;
using Dominio.Entidades.SucursalProducto;
using Dominio.Entidades.Comercio;
using Libreria.Base;

namespace Dominio.Entidades.Orden
{
    public class OrdenDetalle
    {
        public OrdenDetalle(Producto producto)
        {
            Producto = producto;
            Cantidad = 1;
        }

        public Int32 IdOrdenDetalle { get; set; }
        public Producto Producto { get; set; }
        public Sucursal Sucursal { get; set; }
        public Decimal Precio { get; set; }
        public Int32 Cantidad { get; set; }
        public Decimal Total
        {
            get
            {
                return Precio * Cantidad;
            }
        }

        public void CalcularPrecio()
        {
            try
            {
                Precio = 0;
                if (Validar.EsValido(Producto))
                {
                    if (Producto.EsVentaPorMayor)
                    {
                        CalcularPrecioPorMayor();
                    }
                    else
                    {
                        CalcularPrecioUnico();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        } 

        private void CalcularPrecioPorMayor()
        {
            try
            {
                if (Validar.EsValido(Producto.ProductoPrecio) && Validar.EsValido(Producto.ProductoPrecio.PrecioRango))
                {
                    foreach (ProductoPrecioRango precioRango in Producto.ProductoPrecio.PrecioRango)
                    {
                        if (Cantidad >= precioRango.UnidadMinima && Cantidad <= precioRango.UnidadMaxima)
                        {
                            Precio = precioRango.Precio;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void CalcularPrecioUnico()
        {
            try
            {
                if (Validar.EsValido(Producto.ProductoPrecio) && Validar.EsValido(Producto.ProductoPrecio.PrecioRango))
                {
                    Precio = Producto.ProductoPrecio.PrecioRango[0].Precio;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
