using Dominio.Result;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
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
                if (metodoRespuesta.CodigoRespuesta == EnumTipoMensaje.Exito)
                {
                    if (categoriaResultado != null)
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        sJSONSubcategoria = serializer.Serialize(categoriaResultado.DatosSubCategoria);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
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
                if (metodoRespuesta.CodigoRespuesta == EnumTipoMensaje.Exito)
                {
                    if (categoriaResultado != null)
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        sJSONSubcategoriaDetalle = serializer.Serialize(categoriaResultado.DatosSubCategoriaDetalle);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return sJSONSubcategoriaDetalle;
        }
    }
}