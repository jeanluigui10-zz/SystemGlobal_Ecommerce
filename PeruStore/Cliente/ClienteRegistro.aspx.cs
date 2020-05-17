using Dominio.Result.Ubigeo;
using InteligenciaNegocio.AdmUbigeo;
using Libreria.Base;
using Libreria.General;
using Newtonsoft.Json;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web.Services;
using WebGrease.Activities;

namespace PeruStore.Cliente
{
    public partial class ClienteRegistro : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Object Ubigeo_ObtenerRegion() {
            MetodoRespuesta respuesta = new MetodoRespuesta();
            try
            {               
                UbigeoResultado ubigeo = new UbigeoBl().ObtenerRegion();

                if ( ubigeo!= null && ubigeo.Regiones.Count > 0)
                {
                    respuesta.CodigoRespuesta = EnumTipoMensaje.Exito;
                    respuesta.Datos = ubigeo;
                }
                else {
                    respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                    respuesta.Datos = null;
                    respuesta.Mensaje = "Ocurrió un problema al cargar los datos.";
                }
                
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                respuesta.Datos = null;
                respuesta.Mensaje = "Ocurrió un problema al cargar los datos.";
            }
            return JsonConvert.SerializeObject(respuesta);
        }
    }
}