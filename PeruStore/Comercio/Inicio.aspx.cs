using Dominio.Result;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace PeruStore.Comercio
{
    public partial class Inicio : PaginaBase
    {
        public int vsId
        {
            get { return ViewState["ID"] != null ? (int)ViewState["ID"] : default(int); }
            set { ViewState["ID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargar_Datos();
            }
        }

        public void Cargar_Datos()
        {
            Categoria_ObtenerId();
            Cargar_Categoria_SubCategoriaMenu();
            Cargar_Categoria_Menu();
        }

        private void Categoria_ObtenerId()
        {
            //if (!String.IsNullOrEmpty(Request.QueryString["c"]))
            //{
            //    String IdCategoria = Encriptador.Desencriptar(Request.QueryString["c"]);
            //    if (!String.IsNullOrEmpty(IdCategoria))
            //    {
            //        vsId = Convert.ToInt32(IdCategoria);
            //    }
            //}
            vsId = 1; //estatico para q se muestren las categorias por mientras
        }

        public void Cargar_Categoria_SubCategoriaMenu()
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
            if (vsId > 0)
            {
                try
                {
                    CategoriaResultado categoriaResultado = new CategoriaResultado();
                    categoriaResultado = CategoriaBL.instancia.Categoria_ObtenerLista(ref metodoRespuesta, vsId);

                    if (metodoRespuesta.CodigoRespuesta == EnumTipoMensaje.Exito)
                    {
                        if (categoriaResultado != null)
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            String sJSON = serializer.Serialize(categoriaResultado.Datos);
                            hfDataCategoriaMenuSubMenu.Value = sJSON.ToString();
                        }
                    }
                }
                catch (Exception exception)
                {
                    Mensaje(EnumTipoMensaje.Informacion, "Ocurrio un problema al cargar la información.");
                    throw exception;
                }
            }
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

        public void Cargar_Categoria_Menu()
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
            if (vsId > 0) {
                try
                {
                    CategoriaResultado categoriaResultado = new CategoriaResultado();

                    categoriaResultado = CategoriaBL.instancia.Categoria_ObtenerLista(ref metodoRespuesta, vsId);
                    if (metodoRespuesta.CodigoRespuesta == EnumTipoMensaje.Exito)
                    {
                        if (categoriaResultado != null)
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            String sJSON = serializer.Serialize(categoriaResultado.Datos);
                            hfDataCategoriaMenu.Value = sJSON.ToString();
                        }
                    }
                }
                catch (Exception exception)
                {
                    Mensaje(EnumTipoMensaje.Informacion, "Ocurrio un problema al cargar la información.");
                    throw exception;
                }
            }
        }
    }
}