using System;

namespace Dominio.Entidades
{
    public class Direccion
    {
        public Int32 IdDireccion { get; set; }

        public Int32 IdCliente { get; set; }

        public Byte IdDireccionTipo { get; set; }

        public Int32 IdDistrito { get; set; }

        public Int32 IdProvincia { get; set; }

        public Int32 IdRegion { get; set; }

        public String DireccionPrincipal { get; set; }

        public String DireccionSecundaria { get; set; }

        public String Zip { get; set; }

        public Boolean Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Int32 CreadoPor { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public Int32? ActualizadoPor { get; set; }

    }

}
