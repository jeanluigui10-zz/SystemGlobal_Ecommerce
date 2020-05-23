using System;

namespace Dominio.Entidades.Comercio
{
    public class TiendaContacto
    {
        public Tienda Tienda { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public String Asunto { get; set; }
        public String Mensaje { get; set; }

    }

}
