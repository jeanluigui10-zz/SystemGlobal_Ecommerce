using Dominio.Result.Producto;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using Newtonsoft.Json;
using PeruStore.src.BaseAplicacion;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Collections.Generic;

namespace PeruStore.Comercio.Producto
{
    public partial class ListaProducto : PaginaBase
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
            MostrarProductosPorCategoria();
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
            //    else {
            //        vsId = 0;
            //    }
            //}
            vsId = 4; //estatico mientras se termina de implementar el flujo
        }

        public void MostrarProductosPorCategoria() {
            try
            {
                if (SesionAplicacion.SesionTienda != null)
                {
                    MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
                    String IdComercio = SesionAplicacion.SesionTienda.IdComercio.ToString();
                    Int32 IdCategoria = vsId;
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
    }
}