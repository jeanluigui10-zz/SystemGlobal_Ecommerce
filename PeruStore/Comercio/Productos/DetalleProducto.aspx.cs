using Dominio.Result.Producto;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using Newtonsoft.Json;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web.UI;

namespace PeruStore.Comercio.Productos
{
    public partial class DetalleProducto : PaginaBase
    {
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
                String _sucursalid = Convert.ToString(Request.QueryString["s"]);
                if ((Int32.TryParse(Encriptador.Desencriptar(_prodid), out Int32 idp) && idp > 0) && (Int32.TryParse(Encriptador.Desencriptar(_sucursalid), out Int32 ids) && ids > 0))
                {
                    ProductoResultado _product = ProductoBL.Instancia.ObtenerPrductoPorId(idp, ids, ref _respusta);
                    if (_respusta.CodigoRespuesta == EnumCodigoRespuesta.Exito) 
                    {
                        if (_product != null)
                        {
                            for (int i = 0; i < _product.Datos.Count; i++)
                                _product.Datos[i].NombreRecurso = KeysSistema.Impremtawendomain + _product.Datos[i].NombreRecurso;
                            for (int i = 0; i < _product.DetalleImagen.Count; i++)
                                _product.DetalleImagen[i].NombreRecurso = KeysSistema.Impremtawendomain + _product.DetalleImagen[i].NombreRecurso;
                            _hfProduct.Value = JsonConvert.SerializeObject(_product);
                        }
                        else
                        {
                            Mensaje(EnumCodigoRespuesta.Informacion, "Ocurrio un problema al cargar el Detalle de Producto.");
                        }
                    }
                    else
                    {
                        Mensaje(EnumCodigoRespuesta.Informacion, _respusta.Mensaje);
                    }
                }           
                else
                {
                    Mensaje(EnumCodigoRespuesta.Informacion, "Ocurrio un error al cargar el Detalle de Producto.");
                }
            }
            catch (Exception ex)
            {
                Mensaje(EnumCodigoRespuesta.Informacion, "Ocurrio una exception al cargar el Detalle de Producto.");
            }
        }
    }
}
