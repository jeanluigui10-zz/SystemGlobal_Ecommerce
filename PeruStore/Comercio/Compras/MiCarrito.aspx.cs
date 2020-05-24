using Libreria.Base;
using Libreria.General;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web.Services;
using PeruStore.src.BaseAplicacion;
using Dominio.Entidades.Orden;
using Dominio.Entidades.SucursalProducto;
using InteligenciaNegocio.AdminProducto;
using System.Web;

namespace PeruStore.Comercio.Compras
{
    public partial class MiCarrito : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static MetodoRespuesta AgregarCarrito(String idProductoCifrado)
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Exito);
            try
            {
                Ordencabecera ordencabecera = SesionAplicacion.SesionOrdenCabecera ?? new Ordencabecera();
                ordencabecera.Tienda = SesionAplicacion.SesionTienda;
                ordencabecera.Cliente = SesionAplicacion.SesionCliente;

                Boolean _ = Int32.TryParse(Encriptador.Desencriptar(HttpUtility.UrlDecode(idProductoCifrado)), out Int32 idProducto);
                Producto producto = ProductoBL.Instancia.Obtener_Para_Carrito(ref metodoRespuesta, idProducto);

                OrdenDetalle ordenDetalle = new OrdenDetalle()
                {
                    Producto = producto,
                    Cantidad = 1
                };
                ordenDetalle.CalcularPrecio();

                ordencabecera.OrdenDetalleLista.Add(ordenDetalle);
                ordencabecera.RecalcularMontos();

                SesionAplicacion.SesionOrdenCabecera = ordencabecera;
                metodoRespuesta.Datos = ordencabecera;


            }
            catch (Exception exception)
            {
                metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, "No es posible agregar este producto al carrito.");
                //throw exception;
            }
            return metodoRespuesta;
        }

        //public static MetodoRespuesta ObtenerCarrito()
        //{
        //    MetodoRespuesta metodoRespuesta = null;
        //    try
        //    {
        //        metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Exito, SesionAplicacion.SesionOrdenCabecera);
        //    }
        //    catch (Exception exception)
        //    {
        //        metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, "Encontramos problemas para mostrar tus compras.");
        //    }
        //    return metodoRespuesta;
        //}
    }
}