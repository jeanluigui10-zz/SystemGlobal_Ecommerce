using Dominio.Entidades;
using Dominio.Result.Producto;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using Newtonsoft.Json;
using PeruStore.src.BaseAplicacion;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web.UI;

namespace PeruStore.Controles.Inicio
{
    public partial class ucProductoLista :PaginaBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarProductosPorComercio();
            }
        }

        private void MostrarProductosPorComercio()
        {
            try
            {
                if (SesionAplicacion.SesionTienda != null) {
                    MetodoRespuesta _respusta = new MetodoRespuesta();
                    String _comerid = SesionAplicacion.SesionTienda.IdComercio.ToString();
                    if (Int32.TryParse(_comerid, out Int32 id) && id > 0)
                    {
                        ProductoResultado _producto = ProductoBL.Instancia.ListaProdctosPorComercio(id, ref _respusta);
                        if (_respusta.CodigoRespuesta == EnumTipoMensaje.Exito)
                        {
                            if (_producto != null)
                            {
                                _hfListaProducto.Value = JsonConvert.SerializeObject(_producto);
                            }
                            else
                            {
                                Mensaje(EnumTipoMensaje.Informacion, "Ocurrio un problema al cargar los productos de Comercio.");
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
            }
            catch (Exception ex)
            {
                Mensaje(EnumTipoMensaje.Informacion, "Ocurrio una exception al cargar el Detalle de Producto.");
            }
        }
    }
}