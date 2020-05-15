using Dominio.Result;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web.Script.Serialization;

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
                            hfDataCategoria.Value = sJSON.ToString();
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