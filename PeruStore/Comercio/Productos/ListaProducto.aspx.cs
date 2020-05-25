using Dominio.Result.Producto;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using Newtonsoft.Json;
using PeruStore.src.BaseAplicacion;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeruStore.Comercio.Productos
{
    public partial class ListaProducto : PaginaBase
    {
        public int IdCategoriaParam
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
            Categorias_CargarPorComercio();
            ProductosPor_IdCategoria_Carga();
        }

        private void Categoria_ObtenerId()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["c"]))
            {
                String IdCategoria = Encriptador.Desencriptar(Request.QueryString["c"]);
                if (!String.IsNullOrEmpty(IdCategoria))
                {
                    IdCategoriaParam = Convert.ToInt32(IdCategoria);
                }
                else
                {
                    IdCategoriaParam = 0;
                }
            }
        }
        public void Categorias_CargarPorComercio()
        {
            try
            {
                MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
                CategoriaResultado categoriaResultado = new CategoriaResultado();

                String IdComercio = SesionAplicacion.SesionTienda.IdComercio.ToString();
                if (Int32.TryParse(IdComercio, out Int32 idcome) && idcome > 0)
                {
                    categoriaResultado = CategoriaBL.instancia.Categoria_ObtenerLista(ref metodoRespuesta, idcome);

                    if (metodoRespuesta.CodigoRespuesta == EnumCodigoRespuesta.Exito)
                    {
                        if (categoriaResultado != null)
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            String sJSON = serializer.Serialize(categoriaResultado.Datos);
                            hfDatosCategoriasLista.Value = sJSON.ToString();
                        }
                    }
                }
            
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void ProductosPor_IdCategoria_Carga() {
            try
            {
                if (SesionAplicacion.SesionTienda != null)
                {
                    MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
                    String IdComercio = SesionAplicacion.SesionTienda.IdComercio.ToString();
                    Int32 IdCategoria = IdCategoriaParam;
                    if (Int32.TryParse(IdComercio, out Int32 idcome) && idcome > 0)
                    {
                        ProductoResultado productoResultado = ProductoBL.Instancia.ListaProdctosPor_Comercio_Categoria(idcome, IdCategoria, ref metodoRespuesta);
                        if (metodoRespuesta.CodigoRespuesta == EnumCodigoRespuesta.Exito)
                        {
                            if (productoResultado != null)
                            {
                                if (productoResultado.Datos.Count > 0)
                                {
                                    hfDatosProductosPorCategoria.Value = JsonConvert.SerializeObject(productoResultado.Datos);
                                }
                                else
                                {
                                    hfDatosProductosPorCategoria.Value = "{}";
                                    Mensaje(EnumCodigoRespuesta.Informacion, "No hay productos de esta Categoría.");
                                }
                            }
                            else
                            {
                                hfDatosProductosPorCategoria.Value = "{}";
                                Mensaje(EnumCodigoRespuesta.Informacion, "Ocurrio un problema al cargar los productos de Comercio.");
                            }
                        }
                        else
                        {
                            hfDatosProductosPorCategoria.Value = "{}";
                            Mensaje(EnumCodigoRespuesta.Informacion, metodoRespuesta.Mensaje);
                        }
                    }
                    else
                    {
                        hfDatosProductosPorCategoria.Value = "{}";
                        Mensaje(EnumCodigoRespuesta.Informacion, "Ocurrio un error al cargar el Detalle de Producto.");
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [WebMethod]
        public static String ProductosPor_Categoria(String IdCategoriaCifrado)
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
            String sJsonProductos = "";
            try
            {
                Int32 Categoria = Convert.ToInt32(Encriptador.Desencriptar(HttpUtility.UrlDecode(IdCategoriaCifrado)));
                if (SesionAplicacion.SesionTienda != null)
                {
                    String IdComercio = SesionAplicacion.SesionTienda.IdComercio.ToString();
                    if (Int32.TryParse(IdComercio, out Int32 idcome) && idcome > 0)
                    {
                        ProductoResultado productoResultado = ProductoBL.Instancia.ListaProdctosPor_Comercio_Categoria(idcome, Categoria, ref metodoRespuesta);
                        if (metodoRespuesta.CodigoRespuesta == EnumCodigoRespuesta.Exito)
                        {
                            if (productoResultado != null)
                            {
                                JavaScriptSerializer serializer = new JavaScriptSerializer();
                                sJsonProductos = serializer.Serialize(productoResultado.Datos);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
           return sJsonProductos;
        }
    }
}