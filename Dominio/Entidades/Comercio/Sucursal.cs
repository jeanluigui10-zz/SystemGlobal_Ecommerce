using System;

namespace Dominio.Entidades.Comercio
{
    public class Sucursal
    {
        public Int16 IdSucursal { get; set; }
        public Int16 IdComercio { get; set; }
        public String SucursalNombre { get; set; }
        public Boolean? EsPrincipal { get; set; }
        public Boolean? Estado { get; set; }
    }
}
