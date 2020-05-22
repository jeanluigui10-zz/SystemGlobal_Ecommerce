using Dominio.Result.Producto;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using System;
using System.Web.Script.Serialization;

namespace PeruStore
{
    public partial class HomePage : System.Web.UI.MasterPage
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
                            hfDataCategoriaMenu.Value = sJSON.ToString();
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
}