using Dominio.Entidades.Comercio;
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
            OrdenDetalle = new List<OrdenDetalle>();
        }
        public Int32 IdOrden { get; set; }
        public Tienda Tienda { get; set; }
        public Cliente Cliente { get; set; }
        public Direccion Direccion { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public OrdenEstado OrdenEstado { get; set; }
        public EntregaTipo EntregaTipo { get; set; }
        public List<OrdenDetalle> OrdenDetalle { get; set; }
        public DateTime FechaOrden { get; set; }
        public Decimal Total { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal? DeliveryTotal { get; set; }
        public Decimal? Descuento { get; set; }
        public Decimal? PorcentajeImpuesto { get; set; }
        public Decimal? Impuesto { get; set; }

    }

}
