using Libreria.General;
using System;

namespace Libreria.Base
{

    [Serializable]
    public class MetodoRespuesta
    {
        public MetodoRespuesta()
        {
            CodigoRespuesta = EnumCodigoRespuesta.Exito;
        }

        public String CodigoMensajeJs()
        {
            String codigoMensajeJs = String.Empty;
            switch (CodigoRespuesta)
            {
                case EnumCodigoRespuesta.Advertencia: 
                    codigoMensajeJs = "w"; 
                    break;
                case EnumCodigoRespuesta.Error:
                    codigoMensajeJs = "e";
                    break;
                case EnumCodigoRespuesta.Exito:
                    codigoMensajeJs = "s";
                    break;
                case EnumCodigoRespuesta.Informacion:
                    codigoMensajeJs = "i";
                    break;
                default:
                    codigoMensajeJs = "";
                    break;
            }
            return codigoMensajeJs;
        }
        public MetodoRespuesta(EnumCodigoRespuesta enumCodigoRespuesta, String mensaje, Object datos)
        {
            CodigoRespuesta = enumCodigoRespuesta;
            Mensaje = mensaje;
            Datos = datos;
        }
        public MetodoRespuesta(EnumCodigoRespuesta enumCodigoRespuesta, Object datos)
        {
            CodigoRespuesta = enumCodigoRespuesta;
            Datos = datos;
        }
        public MetodoRespuesta(EnumCodigoRespuesta enumCodigoRespuesta)
        {
            CodigoRespuesta = enumCodigoRespuesta;
        }
        public EnumCodigoRespuesta CodigoRespuesta { get; set; }
        public String Mensaje { get; set; }
        public Object Datos { get; set; }
    }
}
