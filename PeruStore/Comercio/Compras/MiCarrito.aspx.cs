using Libreria.Base;
using Libreria.General;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web.Services;
using PeruStore.src.BaseAplicacion;
using Dominio.Entidades.Orden;
using Dominio.Entidades.SucursalProducto;

namespace PeruStore.Comercio.Compras
{
    public partial class MiCarrito : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static MetodoRespuesta AgregarCarrito(Producto objProducto)
        {
            MetodoRespuesta metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Exito);
            try
            {
                Ordencabecera ordencabecera = SesionAplicacion.SesionOrdenCabecera?? new Ordencabecera();
                ordencabecera.Tienda = SesionAplicacion.SesionTienda;
                ordencabecera.Cliente = SesionAplicacion.SesionCliente;

                OrdenDetalle ordenDetalle = new OrdenDetalle();
                ordenDetalle.Producto = objProducto;

                ordencabecera.OrdenDetalle.Add(ordenDetalle);



            }
            catch (Exception exception)
            {
                throw exception;
            }
            return metodoRespuesta;
        }

    }
}