using InteligenciaNegocio.AdminCliente;
using Libreria.Base;
using Libreria.General;
using Newtonsoft.Json;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web.Services;

namespace PeruStore.AdminCliente
{
    public partial class ClienteResetearClave : PaginaBase
    {
        private static Int16 idComercio = 0;
        private static Int32 idCliente = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            String idComercioCifrado = Request.QueryString["c"];
            String idClienteEncriptado = Request.QueryString["icl"];

            if (!String.IsNullOrEmpty(idComercioCifrado) && !String.IsNullOrEmpty(idClienteEncriptado))
            {
                _ = Int16.TryParse(Encriptador.Desencriptar(idComercioCifrado), out idComercio);
                _ = Int32.TryParse(Encriptador.Desencriptar(idClienteEncriptado), out idCliente);
            }
        }


        [WebMethod]
        public static Object ActualizarClave(String password)
        {
            MetodoRespuesta respuesta = new MetodoRespuesta();
            try
            {
                Boolean actualizado = false;
                if (String.IsNullOrEmpty(password))
                {
                    respuesta.CodigoRespuesta = EnumCodigoRespuesta.Error;
                    respuesta.Datos = null;
                    respuesta.Mensaje = "Ocurrió un problema al Actualizar Contraseña.";
                    Log.Save("Error", "ClienteResetearClave", "Password es nulo o vacío.");
                }
                else
                {
                    actualizado = ClienteBl.Instancia.ActualizarClave_PorIdCliente_IdComercio(idCliente, idComercio, Encriptador.Encriptar(password));
                    respuesta.CodigoRespuesta = EnumCodigoRespuesta.Exito;
                    respuesta.Datos = "ClienteLogin.aspx";
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumCodigoRespuesta.Error;
                respuesta.Datos = null;
                respuesta.Mensaje = "Ocurrió un problema al Actualizar Contraseña.";
                Log.Save("Error", "ClienteRegistro:" + ex.Message, ex.StackTrace);
            }
            return JsonConvert.SerializeObject(respuesta);
        }
    }
}