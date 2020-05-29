using Dominio.Entidades.Comercio;
using Libreria.Base;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades.Orden
{
    public class Ordencabecera
    {
        public Ordencabecera()
        {
            Tienda = new Tienda();
            Cliente = new Cliente();
            Direccion = new Direccion();
            MetodoPago = new MetodoPago();
            OrdenEstado = new OrdenEstado();
            EntregaTipo = new EntregaTipo();
            OrdenDetalleLista = new List<OrdenDetalle>();
        }

        public Int32 IdOrden { get; set; }
        public Tienda Tienda { get; set; }
        public Cliente Cliente { get; set; }
        public Direccion Direccion { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public OrdenEstado OrdenEstado { get; set; }
        public EntregaTipo EntregaTipo { get; set; }
        public List<OrdenDetalle> OrdenDetalleLista { get; set; }
        public String SimboloMoneda
        {
            get { return OrdenDetalleLista.Count > 0 ? OrdenDetalleLista[0].Producto.SimboloMoneda : String.Empty; }
        }
        public DateTime FechaOrden { get; set; }
        public Decimal Total { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal DeliveryTotal { get; set; }
        public Decimal Descuento { get; set; }
        public Decimal PorcentajeImpuesto { get; set; }
        public Decimal Impuesto { get; set; }

        public void RecalcularMontos()
        {
            try
            {
                if (Validar.EsValido(OrdenDetalleLista))
                {
                    SubTotal = 0;
                    foreach (OrdenDetalle detalle in OrdenDetalleLista)
                    {
                        SubTotal += detalle.Total;
                    }
                    Total = ((SubTotal + DeliveryTotal) - Descuento);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public Boolean AgregarDetalle(OrdenDetalle ordenDetalle)
        {
            Boolean exito = false;
            try
            {
                if (Validar.EsValido(ordenDetalle))
                {
                    OrdenDetalleLista.Add(ordenDetalle);
                    exito = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return exito;
        }
        public Boolean RemoverDetalle(Int32 idProducto)
        {
            Boolean exito = false;
            try
            {
                if (Validar.EsValido(idProducto))
                {
                    Int32 indice = OrdenDetalleLista.FindIndex(d => d.Producto.IdProducto == idProducto);
                    OrdenDetalleLista.RemoveAt(indice);
                    exito = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return exito;
        }
    }

}
