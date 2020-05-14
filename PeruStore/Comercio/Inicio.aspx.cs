using Dominio.Result;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using System;
using System.Web.Script.Serialization;

namespace PeruStore.Comercio
{
    public partial class Inicio : System.Web.UI.Page
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
            Cargar_Categoria();
        }
        private void Categoria_ObtenerId()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["c"]))
            {
                //String IdCategoria = Encryption.Decrypt(Request.QueryString["c"]);
                //if (!String.IsNullOrEmpty(IdCategoria))
                //{
                //    vsId = Convert.ToInt32(IdCategoria);
                //}
            }
        }
        public void Cargar_Categoria()
        {
            if (vsId > 0) {
                MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
                CategoriaResultado categoriaResultado = new CategoriaResultado();
                try
                {
                    categoriaResultado = CategoriaBL.instancia.Categoria_ObtenerLista(ref metodoRespuesta, vsId);
                    if (metodoRespuesta.Errors.Count == 0)
                    {
                        if (categoriaResultado != null)
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            String sJSON = serializer.Serialize(categoriaResultado.Datos);
                            hfDataCategoria.Value = sJSON.ToString();
                        }
                    }
                }
                catch (Exception exception)
                {
                    metodoRespuesta.Errors.Add(new MetodoRespuesta.ListError(exception, "Ocurrio un error al cargar la data."));
                    throw exception;
                }
            }
           
        }
    }
}