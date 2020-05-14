using Libreria.General;
using System;

namespace Libreria.Base
{

    [Serializable]
    public class MetodoRespuesta
    {
        public MetodoRespuesta()
        {
            TipoMensaje = EnumTipoMensaje.Exito;
        }
        public MetodoRespuesta(EnumTipoMensaje enumTipoMensaje, String mensaje = "")
        {
            TipoMensaje = EnumTipoMensaje.Exito;
            Mensaje = mensaje;
        }
        public EnumTipoMensaje TipoMensaje { get; set; }
        public String Mensaje { get; set; }
        public Object Datos { get; set; }
    }
}
