using Dominio.Entidades;
using Dominio.Result.Producto;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using Newtonsoft.Json;
using PeruStore.src.BaseAplicacion;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace PeruStore.Controles.Inicio
{
    public partial class ucProductoLista : PaginaBaseControl
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
                if (SesionAplicacion.SesionTienda != null)
                {

                    MetodoRespuesta _respusta = new MetodoRespuesta();
                    String _comerid = SesionAplicacion.SesionTienda.IdComercio.ToString();
                    if (Int32.TryParse(_comerid, out Int32 id) && id > 0)
                    {                     
                        ProductoResultado _producto = ProductoBL.Instancia.ListaProdctosPorComercio(id, ref _respusta);
                        if (_respusta.CodigoRespuesta == EnumTipoMensaje.Exito)
                        {
                            if (_producto != null)
                            {
                                Object Productos = new Object();
                                List<Object> ListaProductos = new List<Object>();
                                List<Object> Detalle = new List<Object>();
                                Int16 count = 0;
                                Int32 total = _producto.Datos.Count;
                                for (int i = 0; i < _producto.Datos.Count; i++)
                                {
                                    count++;
                                    if (count < 3)
                                    {
                                        Detalle.Add(_producto.Datos[i]);
                                        Object DetalleProductos = new { Detalle, };

                                        if (count == 2)
                                        {
                                            Detalle = new List<Object>();
                                            ListaProductos.Add(DetalleProductos);
                                            count = 0;
                                        }
                                        else
                                        {
                                            if (i == total - 1 && total % 2 != 0 && count == 1)
                                            {
                                                Detalle = new List<Object>();
                                                ListaProductos.Add(DetalleProductos);
                                                count = 0;
                                            }
                                        }
                                    }
                                }
                                Productos = new { ListaProductos };
                                _hfListaProducto.Value = JsonConvert.SerializeObject(Productos);
                            }
                            else
                            {
                                _hfListaProducto.Value = "{}";
                                Mensaje(EnumTipoMensaje.Informacion, "Ocurrio un problema al cargar los productos de Comercio.");
                            }
                        }
                        else
                        {
                            _hfListaProducto.Value = "{}";
                            Mensaje(EnumTipoMensaje.Informacion, _respusta.Mensaje);
                        }
                    }
                    else
                    {
                        _hfListaProducto.Value = "{}";
                        Mensaje(EnumTipoMensaje.Informacion, "Ocurrio un error al cargar el Detalle de Producto.");
                    }
                }
            }
            catch (Exception ex)
            {
                _hfListaProducto.Value = "{}";
                Mensaje(EnumTipoMensaje.Informacion, "Ocurrio una exception al cargar el Detalle de Producto.");
            }
        }
    }
}