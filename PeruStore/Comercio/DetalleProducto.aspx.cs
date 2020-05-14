using Dominio.Result;
using InteligenciaNegocio.AdminProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeruStore.Comercio
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        public Int32 ViewId {
            get { return ViewState["ID"] != null ? (int)ViewState["ID"] : default; }
            set { ViewState["ID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarProductoPorId();
            }
        }

        private void MostrarProductoPorId() {

            Int32 _prodid = Convert.ToInt32(Request.QueryString["prodid"]);
            //ProductoResultado _product = ProductoBL.Instancia.ObtenerPrductoPorId();


        }
    }
}