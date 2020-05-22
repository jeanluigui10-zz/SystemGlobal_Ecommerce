using Dominio.Entidades;
using Dominio.Result.Cliente;
using Dominio.Result.Ubigeo;
using Dominio.TablasTipo;
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

namespace PeruStore.AdminCliente
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
                    Log.Save("Error", "ClienteRegistro.aspx", "Ubigeo null || regiones = 0");
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                respuesta.Datos = null;
                respuesta.Mensaje = "Ocurrió un problema al cargar las Regiones.";
                Log.Save("Error", "ClienteRegistro.aspx:" + ex.Message, ex.StackTrace);
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
                        Log.Save("Error", "ClienteRegistro.aspx", "Ubigeo null || Provincias = 0 " + idRegion);
                    }
                }
                else {
                    respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                    respuesta.Datos = null;
                    respuesta.Mensaje = "Ocurrió un problema al cargar las Provincias.";
                    Log.Save("Error", "ClienteRegistro.aspx", "Parametro strIdRegion incorrecto:"+ strIdRegion);
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                respuesta.Datos = null;
                respuesta.Mensaje = "Ocurrió un problema al cargar las Provincias.";
                Log.Save("Error", "ClienteRegistro.aspx:" + ex.Message, ex.StackTrace);
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
                        Log.Save("Error", "ClienteRegistro.aspx", "Ubigeo null || Distritos = 0 " + idProvincia);
                    }
                }
                else
                {
                    respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                    respuesta.Datos = null;
                    respuesta.Mensaje = "Ocurrió un problema al cargar los Distritos.";
                    Log.Save("Error", "ClienteRegistro.aspx", "Parametro strIdProvincia incorrecto:" + strIdProvincia);
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                respuesta.Datos = null;
                respuesta.Mensaje = "Ocurrió un problema al cargar los Distritos.";
                Log.Save("Error", "ClienteRegistro.aspx:" + ex.Message, ex.StackTrace);
            }
            return JsonConvert.SerializeObject(respuesta);
        }

        [WebMethod]
        public static Object RegistrarCliente(Dictionary<String,String> cliente) {
            MetodoRespuesta respuesta = new MetodoRespuesta();
            Boolean datosValidos = true;
            ClienteTablaTipo cliente_Tipo = null;
            DireccionTablaTipo direccion_Tipo = null;
            Boolean registroExitoso = false;
            try
            {
                Int16 idComercio = SesionAplicacion.SesionTienda.IdComercio;

                if (cliente != null)
                {
                    String nombre = cliente["nombre"];
                    String apellPaterno = cliente["apellPaterno"];
                    String apellMaterno = cliente["apellMaterno"];
                    String correo = cliente["correo"].ToLower();
                    String celular = cliente["celular"];
                    String telefono = cliente["telefono"];
                    String direccionPrincipal = cliente["direccionPrincipal"];
                    String direccionSecundaria = cliente["direccionSecundaria"];
                    Int16 IdRegion = Convert.ToInt16(cliente["IdRegion"]);
                    Int16 IdProvincia = Convert.ToInt16(cliente["IdProvincia"]);
                    Int16 IdDistrito = Convert.ToInt16(cliente["IdDistrito"]);
                    String codigoPostal = cliente["codigoPostal"];
                    String contrasenha = cliente["contrasenha"];


                    #region validar campos
                    if (String.IsNullOrEmpty(nombre.Trim()))
                    {
                        Log.Save("Error", "ClienteRegistro.aspx", "Nombre de Cliente esta Vacio");
                        datosValidos = false;
                    }
                    if (String.IsNullOrEmpty(apellPaterno.Trim()))
                    {
                        Log.Save("Error", "ClienteRegistro.aspx", "Apellido Paterno de Cliente esta Vacio");
                        datosValidos = false;
                    }
                    if (String.IsNullOrEmpty(apellMaterno.Trim()))
                    {
                        Log.Save("Error", "ClienteRegistro.aspx", "Apellido Materno de Cliente esta Vacio");
                        datosValidos = false;
                    }
                    if (String.IsNullOrEmpty(correo.Trim()))
                    {
                        Log.Save("Error", "ClienteRegistro.aspx", "Correo de Cliente esta Vacio");
                        datosValidos = false;
                    }
                    else
                    {
                        if (!Utilitario.esEmailValido(correo))
                        {
                            Log.Save("Error", "ClienteRegistro.aspx", "Correo ingresado no tiene un formato valido:" + correo);
                            datosValidos = false;
                        }
                    }

                    if (String.IsNullOrEmpty(celular))
                    {
                        Log.Save("Error", "ClienteRegistro.aspx", "Celular de Cliente esta Vacio");
                        datosValidos = false;
                    }
                    else
                    {
                        if (!Utilitario.esNumerico(celular))
                        {
                            Log.Save("Error", "ClienteRegistro.aspx", "Celular de Cliente no tiene formato valido:" + celular);
                            datosValidos = false;
                        }
                        if (celular.Length != 9)
                        {
                            Log.Save("Error", "ClienteRegistro.aspx", "Celular de Cliente no cumple el tamaño requerido:" + celular);
                            datosValidos = false;
                        }
                    }
                    if (!String.IsNullOrEmpty(telefono))
                    {
                        if (!Utilitario.esNumerico(telefono))
                        {
                            Log.Save("Error", "ClienteRegistro.aspx", "Teléfono de Cliente no tiene formato valido:" + telefono);
                            datosValidos = false;
                        }
                        if (telefono.Length != 9)
                        {
                            Log.Save("Error", "ClienteRegistro.aspx", "Teléfono de Cliente no cumple el tamaño requerido:" + telefono);
                            datosValidos = false;
                        }
                    }
                    if (String.IsNullOrEmpty(direccionPrincipal))
                    {
                        Log.Save("Error", "ClienteRegistro.aspx", "Direccion Principal de Cliente esta vacio");
                        datosValidos = false;
                    }

                    if (String.IsNullOrEmpty(codigoPostal))
                    {
                        Log.Save("Error", "ClienteRegistro.aspx", "Codigo Postal esta vacio");
                        datosValidos = false;
                    }
                    else
                    {
                        if (!Utilitario.esNumerico(codigoPostal))
                        {
                            Log.Save("Error", "ClienteRegistro.aspx", "Codigo Postal no tiene formato valido:" + codigoPostal);
                            datosValidos = false;
                        }
                        if (codigoPostal.Length != 5)
                        {
                            Log.Save("Error", "ClienteRegistro.aspx", "Codigo Postal no cumple el tamaño requerido:" + codigoPostal);
                            datosValidos = false;
                        }
                    }

                    if (String.IsNullOrEmpty(contrasenha))
                    {
                        Log.Save("Error", "ClienteRegistro.aspx", "Contraseña esta vacio");
                        datosValidos = false;
                    } 
                    #endregion

                    if (!datosValidos) {
                        respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                        respuesta.Datos = null;
                        respuesta.Mensaje = "Ocurrió un problema al Registrar Cliente.";
                    }

                    else {
                        ClienteBl objClienteBl = new ClienteBl();
                        contrasenha = Encriptador.Encriptar(contrasenha);
                        Boolean existeCliente = objClienteBl.Cliente_Existe_PorEmail(correo, idComercio);
                        if (existeCliente)
                        {
                            respuesta.CodigoRespuesta = EnumTipoMensaje.Informacion;
                            respuesta.Datos = null;
                            respuesta.Mensaje = "El correo electrónico ingresado ya pertenece a otra cuenta, ingrese otra dirección de Correo Eléctronico";
                            Log.Save("Info", "ClienteRegistro.aspx", "Correo ya existe:" + correo);
                        }
                        else {
                            
                            Cliente objCliente = new Cliente();                            
                            objCliente.IdDocumentoTipo = 0;
                            objCliente.IdComercio = idComercio;
                            objCliente.Nombre = nombre;
                            objCliente.ApellidoPaterno = apellPaterno;
                            objCliente.ApellidoMaterno = apellMaterno;
                            objCliente.NumeroDocumento = String.Empty;
                            objCliente.Celular = celular;
                            objCliente.Telefono = telefono;
                            objCliente.Email = correo;
                            objCliente.Contrasenha = contrasenha;
                            objCliente.Estado = true;
                            objCliente.CreadoPor = 0;
                            objCliente.ActualizadoPor = 0;
                            cliente_Tipo = new ClienteTablaTipo();
                            cliente_Tipo.Add(objCliente);

                            Direccion objDireccion = new Direccion();
                            objDireccion.IdCliente = 0;
                            objDireccion.IdDireccionTipo = 0;
                            objDireccion.IdDistrito = IdDistrito;
                            objDireccion.IdProvincia = IdProvincia;
                            objDireccion.IdRegion = IdRegion;
                            objDireccion.DireccionPrincipal = direccionPrincipal;
                            objDireccion.DireccionSecundaria = direccionSecundaria;
                            objDireccion.Zip = codigoPostal;
                            objDireccion.Estado = true;
                            objDireccion.CreadoPor = 0;
                            objDireccion.ActualizadoPor = 0;
                            direccion_Tipo = new DireccionTablaTipo();
                            direccion_Tipo.Add(objDireccion);


                            objClienteBl = new ClienteBl();
                            registroExitoso = objClienteBl.RegistrarCliente(cliente_Tipo,direccion_Tipo);

                            if (registroExitoso){
                                respuesta.CodigoRespuesta = EnumTipoMensaje.Exito;
                                respuesta.Datos = null;
                                respuesta.Mensaje = String.Format("¡Gracias {0} {1}! ya eres parte de nuestros Clientes.", nombre, apellPaterno);
                            }
                            else {
                                respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                                respuesta.Datos = null;
                                respuesta.Mensaje = "Ocurrió un problema al Registrar.";
                            }
                        }
                    }

                }
                else {
                    respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                    respuesta.Datos = null;
                    respuesta.Mensaje = "Ocurrió un problema al Registrar.";
                    Log.Save("Error", "ClienteRegistro", "Parametro Cliente es null" );
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumTipoMensaje.Error;
                respuesta.Datos = null;
                respuesta.Mensaje = "Ocurrió un problema al Registrar Cliente.";
                Log.Save("Error", "ClienteRegistro:" + ex.Message, ex.StackTrace);
            }
            return JsonConvert.SerializeObject(respuesta);
        }
    }
}