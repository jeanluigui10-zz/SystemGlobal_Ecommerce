using Dominio.Result.Producto;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using PeruStore.src.BaseAplicacion;
using System;
using System.Web.Script.Serialization;

namespace PeruStore
{
    public partial class HomePage : System.Web.UI.MasterPage
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
            Categorias_SubCategorias_PorComercio();
        }

        public void Categorias_SubCategorias_PorComercio()
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
                            hfDataCategoriaMenuSubMenu.Value = sJSON.ToString();
                            hfDataCategoriaMenu.Value = sJSON.ToString();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}