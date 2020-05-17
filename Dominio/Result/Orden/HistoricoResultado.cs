using Libreria.General;
using System;
using System.Collections.Generic;
using System.Web;

namespace Dominio.Result.Orden
{

    public class HistoricoResultado
    {
        public HistoricoResultado()
        {
            Datos = new List<HistoricoDTO>();
        }
        public List<HistoricoDTO> Datos { get; set; }
    }

    public class HistoricoDTO
    {
        public Int32 IdOrden { get; set; }
        public String IdOrdenCifrado
        {
            get
            {
                if (!String.IsNullOrEmpty(IdOrden.ToString())) { return HttpUtility.UrlEncode(Encriptador.Encriptar(IdOrden.ToString())); }
                else { return String.Empty; } 
            }
        }
        public String Estado { get; set; }
        public Int32 Cantidad { get; set; }
        public String FechaOrden { get; set; }
        public String TotalOrden { get; set; }
        public String MetodoPago { get; set; }
        public String TipoEntrega { get; set; }
        public String DireccionEntrega { get; set; }
        public String Distrito { get; set; }
        public String Provincia { get; set; }
        public String Region { get; set; }
        public String Zip { get; set; }
        public String SubTotal { get; set; }
        public String Impuesto { get; set; }
        public String PorcentajeImpuesto { get; set; }
        public String Descuento { get; set; }
        public String DeliveryTotal { get; set; }
    }
}
