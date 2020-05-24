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
                        if (_respusta.CodigoRespuesta == EnumCodigoRespuesta.Exito)
                        {
                            if (_producto != null)
                            {
                                if (_producto.Datos.Count > 0) 
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

                                            Detalle.Add(new
                                            {   _producto.Datos[i].IdProductoCifrado,
                                                _producto.Datos[i].ProductoNombre, 
                                                _producto.Datos[i].ProductoDescripcion, 
                                                _producto.Datos[i].ProductoDescripcionLarga, 
                                                _producto.Datos[i].Precio,
                                                _producto.Datos[i].PrecioOferta,
                                                _producto.Datos[i].Simbolo,
                                                _producto.Datos[i].Sku,
                                                _producto.Datos[i].UnidadMaxima,
                                                _producto.Datos[i].UnidadMinima,
                                                _producto.Datos[i].MarcaNombre,
                                                _producto.Datos[i].CategoriaNombre,
                                                _producto.Datos[i].NombreRecurso,
                                                _producto.Datos[i].Esoferta,
                                            });
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
                                    Mensaje(EnumCodigoRespuesta.Informacion, "Esta tienda no tiene Productos.");
                                }
                            }
                            else
                            {
                                _hfListaProducto.Value = "{}";
                                Mensaje(EnumCodigoRespuesta.Informacion, "Ocurrio un problema al cargar los productos de Comercio.");
                            }
                        }
                        else
                        {
                            _hfListaProducto.Value = "{}";
                            Mensaje(EnumCodigoRespuesta.Informacion, _respusta.Mensaje);
                        }
                    }
                    else
                    {
                        _hfListaProducto.Value = "{}";
                        Mensaje(EnumCodigoRespuesta.Informacion, "Ocurrio un error al cargar el Detalle de Producto.");
                    }
                }
            }
            catch (Exception ex)
            {
                _hfListaProducto.Value = "{}";
                Mensaje(EnumCodigoRespuesta.Informacion, "Ocurrio una exception al cargar el Detalle de Producto.");
            }
        }
    }
}