using Dominio.Result.Producto;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using Newtonsoft.Json;
using PeruStore.src.BaseAplicacion;
using System;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace PeruStore.WebMethodPaginaMaestra
{
    public partial class PaginaMaestra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static String SubCategoria_Lista_PorIdCategoria(Int16 IdCategoria)
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
            String sJSONSubcategoria = "";
            try
            {
                CategoriaResultado categoriaResultado = new CategoriaResultado();

                categoriaResultado = CategoriaBL.instancia.SubCategoria_ObtenerLista_PorIdCategoria(ref metodoRespuesta, IdCategoria);
                if (metodoRespuesta.CodigoRespuesta == EnumCodigoRespuesta.Exito)
                {
                    if (categoriaResultado != null)
                    {
                        sJSONSubcategoria = JsonConvert.SerializeObject(categoriaResultado.DatosSubCategoria);
                    }
                }
            }
            catch (Exception exception)
            {
                sJSONSubcategoria = "";
            }
            return sJSONSubcategoria;
        }

        [WebMethod]
        public static String SubCategoria_Lista_PorIdSubCategoria(Int16 IdSubCategoria)
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
            String sJSONSubcategoriaDetalle = "";
            try
            {
                CategoriaResultado categoriaResultado = new CategoriaResultado();

                categoriaResultado = CategoriaBL.instancia.SubCategoria_ObtenerLista_PorIdSubCategoria(ref metodoRespuesta, IdSubCategoria);
                if (metodoRespuesta.CodigoRespuesta == EnumCodigoRespuesta.Exito)
                {
                    if (categoriaResultado != null)
                    {
                        sJSONSubcategoriaDetalle = JsonConvert.SerializeObject(categoriaResultado.DatosSubCategoriaDetalle);
                    }
                }
            }
            catch (Exception exception)
            {
                sJSONSubcategoriaDetalle = "";
            }
            return sJSONSubcategoriaDetalle;
        }

        [WebMethod]
        public static Object CerrarSession()
        {
            MetodoRespuesta respuesta = new MetodoRespuesta();
            try
            {
                SesionAplicacion.LimpiarSesion();
                SesionAplicacion.AbandonarSesion();
                respuesta.CodigoRespuesta = EnumCodigoRespuesta.Exito;
                respuesta.Datos = "/Comercio/Inicio.aspx";
            }
            catch (Exception ex)
            {
                respuesta.CodigoRespuesta = EnumCodigoRespuesta.Error;
                respuesta.Mensaje = "Ha ocurrido un error inesperado";
            }
            return JsonConvert.SerializeObject(respuesta);
        }
    }
}