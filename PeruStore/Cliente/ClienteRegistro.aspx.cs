using Dominio.Result.Cliente;
using Dominio.Result.Ubigeo;
using InteligenciaNegocio.AdminCliente;
using InteligenciaNegocio.AdminUbigeo;
using Libreria.Base;
using Libreria.General;
using Newtonsoft.Json;
using PeruStore.src.BaseAplicacion;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Collections.Generic;
using System.Web.Services;

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
                    respuesta.Datos = ubigeo.Regiones;
                }
                else {
                    respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                    respuesta.Datos = null;
                    respuesta.Mensaje = "Ocurrió un problema al cargar las Regiones.";
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                respuesta.Datos = null;
                respuesta.Mensaje = "Ocurrió un problema al cargar las Regiones.";
                //Log error
            }
            return JsonConvert.SerializeObject(respuesta);
        }

        [WebMethod]
        public static Object Ubigeo_ObtenerProvincias_PorIdRegion(String strIdRegion)
        {
            MetodoRespuesta respuesta = new MetodoRespuesta();
            try
            {
                Int16 idRegion = Convert.ToInt16(strIdRegion);

                if (!String.IsNullOrEmpty(strIdRegion) && idRegion > 0)
                {
                    UbigeoResultado ubigeo = new UbigeoBl().ObtenerProvincias_PorIdRegion(idRegion);

                    if (ubigeo != null && ubigeo.Provincias.Count > 0)
                    {
                        respuesta.CodigoRespuesta = EnumTipoMensaje.Exito;
                        respuesta.Datos = ubigeo.Provincias;
                    }
                    else
                    {
                        respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                        respuesta.Datos = null;
                        respuesta.Mensaje = "Ocurrió un problema al cargar las Provincias.";
                    }
                }
                else {
                    respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                    respuesta.Datos = null;
                    respuesta.Mensaje = "Ocurrió un problema al cargar las Provincias.";
                    //Log error seleccionar una Region valida
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                respuesta.Datos = null;
                respuesta.Mensaje = "Ocurrió un problema al cargar las Provincias.";
                // Log error
            }
            return JsonConvert.SerializeObject(respuesta);
        }


        [WebMethod]
        public static Object Ubigeo_ObtenerDistritos_PorIdProvincia(String strIdProvincia)
        {
            MetodoRespuesta respuesta = new MetodoRespuesta();
            try
            {
                Int16 idProvincia = Convert.ToInt16(strIdProvincia);

                if (!String.IsNullOrEmpty(strIdProvincia) && idProvincia > 0)
                {
                    UbigeoResultado ubigeo = new UbigeoBl().ObtenerDistrito_PorIdProvincia(idProvincia);

                    if (ubigeo != null && ubigeo.Distritos.Count > 0)
                    {
                        respuesta.CodigoRespuesta = EnumTipoMensaje.Exito;
                        respuesta.Datos = ubigeo.Distritos;
                    }
                    else
                    {
                        respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                        respuesta.Datos = null;
                        respuesta.Mensaje = "Ocurrió un problema al cargar los Distritos.";
                    }
                }
                else
                {
                    respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                    respuesta.Datos = null;
                    respuesta.Mensaje = "Ocurrió un problema al cargar los Distritos.";
                    //Log error seleccionar una Region valida
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                respuesta.Datos = null;
                respuesta.Mensaje = "Ocurrió un problema al cargar los Distritos.";
                // Log error
            }
            return JsonConvert.SerializeObject(respuesta);
        }

        [WebMethod]
        public static Object RegistrarCliente(Dictionary<String,String> cliente) {
            MetodoRespuesta respuesta = new MetodoRespuesta();
            Boolean esClienteValido = true;
            Int16 idComercio = SesionAplicacion.SesionTienda.IdComercio;
            try
            {
                if (cliente != null)
                {
                    String nombre = cliente["nombre"];
                    String apellPaterno = cliente["apellPaterno"];
                    String apellMaterno = cliente["apellMaterno"];
                    String correo = cliente["correo"];
                    String celular = cliente["celular"];
                    String telefono = cliente["telefono"];
                    String direccionPrincipal = cliente["direccionPrincipal"];
                    String direccionSecundaria = cliente["direccionSecundaria"];
                    Int16 IdRegion = Convert.ToInt16(cliente["IdRegion"]);
                    Int16 IdProvincia = Convert.ToInt16(cliente["IdProvincia"]);
                    Int16 IdDistrito = Convert.ToInt16(cliente["IdDistrito"]);
                    String codigoPostal = cliente["codigoPostal"];
                    String contrasenha = cliente["contrasenha"];


                    if (!String.IsNullOrEmpty(nombre.Trim())) {
                        Log.Save("Error","Nombre de Cliente esta Vacio", "Nombre de Cliente esta Vacio");
                        esClienteValido = false;
                    }
                    if (String.IsNullOrEmpty(apellPaterno.Trim()))
                    {
                        esClienteValido = false;
                    }
                    if (String.IsNullOrEmpty(apellMaterno.Trim()))
                    {
                        esClienteValido = false;
                    }
                    if (String.IsNullOrEmpty(correo.Trim()))
                    {
                        esClienteValido = false;
                    }
                    else {
                        if (false) {// no tiene formato de correo
                            esClienteValido = false;
                        }
                    }

                    if (String.IsNullOrEmpty(celular))
                    {
                        esClienteValido = false;
                    }
                    else {
                        if (false || celular.Length != 9) {  // no es celular valido
                            esClienteValido = false;
                        }
                    }
                    if (!String.IsNullOrEmpty(telefono))
                    {
                        if (false || telefono.Length != 9) { // no es telefono valido
                            esClienteValido = false;
                        }
                    }
                    if (String.IsNullOrEmpty(direccionPrincipal))
                    {
                        esClienteValido = false;
                    }

                    if (String.IsNullOrEmpty(codigoPostal)) {
                        esClienteValido = false;
                    }
                    if (String.IsNullOrEmpty(contrasenha)) {
                        esClienteValido = false;
                    }

                    if (!esClienteValido) {
                        respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                        respuesta.Datos = null;
                        respuesta.Mensaje = "Ocurrió un problema al cargar las Provincias.";
                    }

                    else {
                        ClienteResultado objCliente = new ClienteBl().ObtenerCliente_EmailContrasenha(correo, contrasenha, idComercio);
                        if (objCliente != null && objCliente.Datos != null && objCliente.Datos.Count > 0)
                        {
                            respuesta.CodigoRespuesta = EnumTipoMensaje.Informacion;
                            respuesta.Datos = null;
                            respuesta.Mensaje = "El correo electrónico ingresado ya pertenece a otra cuenta";
                        }
                        else { 
                             // mandar a Guardar a la bd
                        }
                    }

                }
                else {
                    respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                    respuesta.Datos = null;
                    respuesta.Mensaje = "Ocurrió un problema al cargar las Provincias.";
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                respuesta.Datos = null;
                respuesta.Mensaje = "Ocurrió un problema al cargar las Provincias.";
            }
            return JsonConvert.SerializeObject(respuesta);

        }
    }
}