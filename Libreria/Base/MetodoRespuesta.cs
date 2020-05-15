using Libreria.General;
using System;

namespace Libreria.Base
{

    [Serializable]
    public class MetodoRespuesta
    {
        public MetodoRespuesta()
        {
            CodigoRespuesta = EnumTipoMensaje.Exito;
        }
        public MetodoRespuesta(EnumTipoMensaje enumTipoMensaje, String mensaje = "")
        {
            CodigoRespuesta = enumTipoMensaje;
            Mensaje = mensaje;
        }
        public EnumTipoMensaje CodigoRespuesta { get; set; }
        public String Mensaje { get; set; }
        public Object Datos { get; set; }
    }
}
