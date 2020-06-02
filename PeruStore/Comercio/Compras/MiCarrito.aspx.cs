using Dominio.Entidades.Orden;
using Dominio.Result.Ubigeo;
using InteligenciaNegocio.AdminOrden;
using InteligenciaNegocio.AdminUbigeo;
using Libreria.Base;
using Libreria.General;
using PeruStore.src.BaseAplicacion;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace PeruStore.Comercio.Compras
{
    public partial class MiCarrito : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRegiones();
            }
        }

        [WebMethod]
        public static MetodoRespuesta AgregarDetalle(String idProductoCifrado)
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Exito);
            try
            {
                Ordencabecera ordencabecera = SesionAplicacion.SesionOrdenCabecera ?? new Ordencabecera();

                Boolean _ = Int32.TryParse(Encriptador.Desencriptar(HttpUtility.UrlDecode(idProductoCifrado)), out Int32 idProducto);
                OrdenCabeceraBl.Instancia.AgregarDetalle(ref metodoRespuesta, ref ordencabecera, idProducto);

                SesionAplicacion.SesionOrdenCabecera = ordencabecera;
            }
            catch (Exception exception)
            {
                metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, "No es posible agregar este producto al carrito.");
                //throw exception;
            }
            return metodoRespuesta;
        }

        [WebMethod]
        public static MetodoRespuesta ObtenerOrden()
        {
            MetodoRespuesta metodoRespuesta = null;
            try
            {
                Ordencabecera ordencabecera = SesionAplicacion.SesionOrdenCabecera;
                if (Validar.EsValido(ordencabecera))
                {
                    List<Object> OrdenDetalleLista = new List<Object>();
                    Int32 totalArticulos = 0;
                    foreach (OrdenDetalle detalle in ordencabecera.OrdenDetalleLista)
                    {
                        OrdenDetalleLista.Add(new
                        {
                            IdProductoCifrado = HttpUtility.UrlEncode(Encriptador.Encriptar(detalle.Producto.IdProducto.ToString())),
                            detalle.Producto.ProductoNombre,
                            ProductoCodigo = detalle.Producto.SKU,
                            detalle.Cantidad,
                            Precio = String.Format("{0} {1}", ordencabecera.SimboloMoneda, detalle.Precio.ToStringMoney()),
                            Total = String.Format("{0} {1}", ordencabecera.SimboloMoneda, detalle.Total.ToStringMoney()),
                            NombreRecurso = String.Format("{0}{1}", KeysSistema.PathImagenProducto, detalle.Producto.NombreRecurso)
                        });
                        totalArticulos++;
                    }

                    metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Exito, new
                    {
                        Total = String.Format("{0} {1}", ordencabecera.SimboloMoneda, ordencabecera.Total.ToStringMoney()),
                        OrdenDetalle = OrdenDetalleLista,
                        Articulos = totalArticulos
                    });

                }
            }
            catch (Exception exception)
            {
                metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, "No es posible mostrar tus compras.");
            }
            return metodoRespuesta;
        }

        [WebMethod]
        public static MetodoRespuesta RemoverDetalle(String idProductoCifrado)
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta();
            try
            {
                Int32 idProducto = Convert.ToInt32(Encriptador.Desencriptar(HttpUtility.UrlDecode(idProductoCifrado)));
                Ordencabecera ordencabecera = SesionAplicacion.SesionOrdenCabecera;
                metodoRespuesta.CodigoRespuesta = ordencabecera.RemoverDetalle(idProducto)? EnumCodigoRespuesta.Exito : EnumCodigoRespuesta.Error;
                ordencabecera.RecalcularMontos();

                SesionAplicacion.SesionOrdenCabecera = ordencabecera;
            }
            catch (Exception exception)
            {
                metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, "No es posible remover este producto.");
            }
            return metodoRespuesta;
        }

        private void CargarRegiones()
        {
            try
            {
                UbigeoResultado ubigeoResultado = UbigeoBl.Instancia.ObtenerRegion();
                cboRegion.DataSource = ubigeoResultado.Regiones;
                cboRegion.DataTextField = "RegionNombre";
                cboRegion.DataValueField = "IdRegion";
                cboRegion.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}