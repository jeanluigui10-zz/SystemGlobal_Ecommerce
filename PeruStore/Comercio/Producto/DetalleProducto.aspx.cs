using Dominio.Result;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using Newtonsoft.Json;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web.UI;

namespace PeruStore.Comercio.Producto
{
    public partial class DetalleProducto : PaginaBase
    {
        public Int32 ViewId
        {
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

        private void MostrarProductoPorId()
        {
            try
            {
                MetodoRespuesta _respusta = new MetodoRespuesta();
                String _prodid = Convert.ToString(Request.QueryString["p"]);
                if (Int32.TryParse(_prodid, out Int32 id) && id > 0)
                {
                    ProductoResultado _product = ProductoBL.Instancia.ObtenerPrductoPorId(id, ref _respusta);
                    if (_respusta.CodigoRespuesta == EnumTipoMensaje.Exito) 
                    {
                        if (_product != null)
                        {
                            _hfProduct.Value = JsonConvert.SerializeObject(_product);
                        }
                        else
                        {
                            Mensaje(EnumTipoMensaje.Informacion, "Ocurrio un problema al cargar el Detalle de Producto.");
                        }
                    }
                    else
                    {
                        Mensaje(EnumTipoMensaje.Informacion, _respusta.Mensaje);
                    }
                }           
                else
                {
                    Mensaje(EnumTipoMensaje.Informacion, "Ocurrio un error al cargar el Detalle de Producto.");
                }
            }
            catch (Exception ex)
            {
                Mensaje(EnumTipoMensaje.Informacion, "Ocurrio una exception al cargar el Detalle de Producto.");
            }
        }
    }
}
