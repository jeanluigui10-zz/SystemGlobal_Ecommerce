using Dominio.Entidades;
using Dominio.Result.Cliente;
using InteligenciaNegocio.AdminCliente;
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
    public partial class ClienteLogin : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (!IsPostBack)
                //{
                //    String emailEncriptado = Request.QueryString["e"];
                //    String passwordEncriptado = Request.QueryString["p"];
                //    String idComercioCifrado = Request.QueryString["c"];

                //    if (!String.IsNullOrEmpty(emailEncriptado) && !String.IsNullOrEmpty(passwordEncriptado) && !String.IsNullOrEmpty(idComercioCifrado))
                //    {
                //        string email = Encriptador.Desencriptar(emailEncriptado);
                //        string password = Encriptador.Desencriptar(passwordEncriptado);
                //        _ = Int16.TryParse(Encriptador.Desencriptar(idComercioCifrado), out Int16 idComercio);
                //        Login(email, password, idComercio);
                //    }

                //    if (SesionAplicacion.SesionCliente != null)
                //    {
                //        Response.Redirect(@"/Comercio/Inicio.aspx");
                //    }
                //}
                Email.Enviar(null,"","","");
            }
            catch (Exception ex)
            {
                Log.Save("Error", "Inicio.aspx:" + ex.Message, ex.Message);
                throw;
            }
        }


        private static MetodoRespuesta Login(String email, String password, Int16 idComercio)
        {
            MetodoRespuesta respuesta = new MetodoRespuesta();
            try
            {
                ClienteBl clienteBl = new ClienteBl();
                if (!String.IsNullOrEmpty(email.Trim()) && !String.IsNullOrEmpty(password) && idComercio > 0)
                {
                    ClienteResultadoDTO objClienteDTO = clienteBl.ObtenerCliente_EmailContrasenha(email, Encriptador.Encriptar(password), idComercio);
                    Cliente objCliente = new Cliente();

                    if (objClienteDTO != null)
                    {
                        objCliente.IdCliente = objClienteDTO.IdCliente;
                        objCliente.IdDocumentoTipo = objClienteDTO.IdDocumentoTipo;
                        objCliente.IdComercio = objClienteDTO.IdComercio;
                        objCliente.Nombre = objClienteDTO.Nombre;
                        objCliente.ApellidoPaterno = objClienteDTO.ApellidoPaterno;
                        objCliente.ApellidoMaterno = objClienteDTO.ApellidoMaterno;
                        objCliente.NumeroDocumento = objClienteDTO.NumeroDocumento;
                        objCliente.Celular = objClienteDTO.Celular;
                        objCliente.Telefono = objClienteDTO.Telefono;
                        objCliente.Email = objClienteDTO.Email;
                        objCliente.Estado = objClienteDTO.Estado;

                        SesionAplicacion.SesionCliente = objCliente;
                        respuesta.CodigoRespuesta = EnumCodigoRespuesta.Exito;
                        respuesta.Datos = String.Format(@"/Comercio/Inicio.aspx");
                    }
                    else
                    {
                        respuesta.CodigoRespuesta = EnumCodigoRespuesta.Informacion;
                        respuesta.Mensaje = "El correo eléctronico o password ingresados son incorrectos";
                        respuesta.Datos = null;
                        Log.Save("Error", "ClienteLogin.aspx", "objClienteDTO es nulo");
                    }
                }
                else
                {
                    respuesta.CodigoRespuesta = EnumCodigoRespuesta.Error;
                    respuesta.Mensaje = respuesta.Mensaje = "A ocurrido un error durante el inicio de Sesion, por favor comuniquese con soporte";
                    respuesta.Datos = null;
                    Log.Save("Error", "ClienteLogin.aspx", String.Format("Error al recibir parametros Email:{0} Password:{1} idComercio:{2}", email, password, idComercio));
                }
            }
            catch (Exception ex)
            {
                Log.Save("Error", "Inicio.aspx:" + ex.Message, ex.Message);
                respuesta.CodigoRespuesta = EnumCodigoRespuesta.Error;
                respuesta.Mensaje = "A ocurrido un error durante el inicio de Sesion, por favor comuniquese con soporte";
                respuesta.Datos = null;
            }
            return respuesta;
        }

        [WebMethod]
        public static Object Login(Dictionary<String, String> credLogin)
        {
            MetodoRespuesta respuesta = new MetodoRespuesta();
            try
            {
                String correo = Convert.ToString(credLogin["correo"]).Trim();
                String password = credLogin["contrasenha"];
                Int16 idComercio = SesionAplicacion.SesionTienda.IdComercio;

                if (!String.IsNullOrEmpty(correo) && !String.IsNullOrEmpty(password) && idComercio > 0)
                {
                    if (!Utilitario.esEmailValido(correo))
                    {
                        Log.Save("Error", "ClienteLogin.aspx", String.Format("Correo {0} ingresado no tiene un formato válido", correo));
                        respuesta.CodigoRespuesta = EnumCodigoRespuesta.Informacion;
                        respuesta.Mensaje = String.Format("Correo {0} ingresado no tiene un formato válido", correo);
                        respuesta.Datos = null;
                    }
                    else
                    {
                        respuesta = Login(correo, password, idComercio);
                    }
                }
                else
                {
                    respuesta.CodigoRespuesta = EnumCodigoRespuesta.Error;
                    respuesta.Mensaje = respuesta.Mensaje = "A ocurrido un error durante el inicio de Sesión, por favor comuníquese con soporte";
                    respuesta.Datos = null;
                    Log.Save("Error", "ClienteLogin.aspx", String.Format("Error al recibir parametros Email:{0} Password:{1} idComercio:{2}", correo, password, idComercio));
                }
            }
            catch (Exception ex)
            {
                Log.Save("Error", "Inicio.aspx:" + ex.Message, ex.Message);
                respuesta.CodigoRespuesta = EnumCodigoRespuesta.Error;
                respuesta.Mensaje = "A ocurrido un error durante el inicio de Sesión, por favor comuníquese con soporte";
                respuesta.Datos = null;
            }
            return JsonConvert.SerializeObject(respuesta);
        }

        [WebMethod]
        public static Object RecuperarContrasenha(String correo)
        {
            MetodoRespuesta respuesta = new MetodoRespuesta();
            ClienteBl objClienteBl = new ClienteBl();
            Int16 idComercio = 0;
            Boolean envioCorrectoEmail = false;

            try
            {
                if (String.IsNullOrEmpty(correo.Trim()))
                {
                    Log.Save("Error", "ClienteLogin.aspx", "Correo de Cliente esta Vacio");
                    respuesta.CodigoRespuesta = EnumCodigoRespuesta.Informacion;
                    respuesta.Mensaje = "correo electrónico no puede ser vacio";
                    respuesta.Datos = null;
                }
                else
                {
                    if (!Utilitario.esEmailValido(correo))
                    {
                        Log.Save("Error", "ClienteLogin.aspx", String.Format("Correo {0} ingresado no tiene un formato válido", correo));
                        respuesta.CodigoRespuesta = EnumCodigoRespuesta.Informacion;
                        respuesta.Mensaje = String.Format("Correo {0} ingresado no tiene un formato válido", correo);
                        respuesta.Datos = null;
                    }
                    else
                    {
                        idComercio = SesionAplicacion.SesionTienda.IdComercio;
                        ClienteResultadoDTO objClienteDTO = objClienteBl.Cliente_RecuperarContrasenha(correo, idComercio);
                        if (objClienteDTO == null) 
                        {
                            respuesta.CodigoRespuesta = EnumCodigoRespuesta.Informacion;
                            respuesta.Mensaje = String.Format("No existe cuenta asociada al correo electrónico {0} ingresado", correo);
                            respuesta.Datos = null;
                            Log.Save("Info", "ClienteLogin.aspx", String.Format("No existe cuenta asociada al correo electrónico {0} ingresado", correo));
                        }
                        else 
                        {
                            envioCorrectoEmail = EnviarEmail_Contraseña(correo, idComercio);
                            if (envioCorrectoEmail) {
                                respuesta.CodigoRespuesta = EnumCodigoRespuesta.Exito;
                                respuesta.Mensaje = String.Format("Hemos enviado un mensaje a tu correo eléctronico {0}. Si no lo recibes en unos minutos, revisa tu carpeta de correo no deseado", correo);
                                respuesta.Datos = null;
                            }
                           else
                            {
                                respuesta.CodigoRespuesta = EnumCodigoRespuesta.Error;
                                respuesta.Mensaje = String.Format("A ocurrido un error al enviar un mensaje al correo electrónico {0}", correo);
                                respuesta.Datos = null;
                                Log.Save("Info", "ClienteLogin.aspx", String.Format("No existe cuenta asociada al correo electrónico {0} ingresado", correo));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Save("Error", "Inicio.aspx:" + ex.Message, ex.Message);
                respuesta.CodigoRespuesta = EnumCodigoRespuesta.Error;
                respuesta.Mensaje = "A ocurrido un error durante el inicio de Sesion, por favor comuniquese con soporte";
                respuesta.Datos = null;
            }
            return JsonConvert.SerializeObject(respuesta);
        }


        private static Boolean EnviarEmail_Contraseña(String correo, Int16 idComercio)
        {

            return true;
        }
    }
}