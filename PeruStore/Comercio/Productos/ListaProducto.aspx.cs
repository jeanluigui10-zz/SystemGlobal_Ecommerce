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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargar_Datos();
            }
        }

        public void Cargar_Datos()
        {
            Categorias_CargarPorComercio();
            ProductosPor_IdCategoria_Carga();
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

                    String IdCategoriaParam = Convert.ToString(Request.QueryString["c"]);
                    String IdComercio = SesionAplicacion.SesionTienda.IdComercio.ToString();
                    if ((Int32.TryParse(IdComercio, out Int32 idcome) && idcome > 0) && (Int32.TryParse(Encriptador.Desencriptar(IdCategoriaParam), out Int32 IdCategoria) && IdCategoria > 0))
                    {
                        ProductoResultado productoResultado = ProductoBL.Instancia.ListaProdctosPor_Comercio_Categoria(idcome, IdCategoria, ref metodoRespuesta);
                        if (metodoRespuesta.CodigoRespuesta == EnumCodigoRespuesta.Exito)
                        {
                            if (productoResultado != null)
                            {
                                if (productoResultado.Datos.Count > 0)
                                {
                                    for (int i = 0; i < productoResultado.Datos.Count; i++) {
                                        productoResultado.Datos[i].NombreRecurso = KeysSistema.Impremtawendomain + productoResultado.Datos[i].NombreRecurso;
                                    }
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