using Dominio.Entidades.Orden;
using Dominio.Entidades.SucursalProducto;
using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using System;

namespace InteligenciaNegocio.AdminOrden
{
    public class OrdenCabeceraBl
    {
        #region Singleton
        private static OrdenCabeceraBl instancia = null;
        public static OrdenCabeceraBl Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new OrdenCabeceraBl();
                }
                return instancia;
            }
        }
        #endregion Singleton

        #region Metodos

        public void AgregarDetalle(ref MetodoRespuesta metodoRespuesta, ref Ordencabecera ordencabecera, Int32 idProducto)
        {
            try
            {
                Int32 posicionProducto = ordencabecera.OrdenDetalleLista.FindIndex(d =>  d.Producto.IdProducto == idProducto);
                if (posicionProducto >= 0)
                {
                    ordencabecera.OrdenDetalleLista[posicionProducto].Cantidad++;
                    ordencabecera.OrdenDetalleLista[posicionProducto].CalcularPrecio();
                }
                else
                {
                    Producto producto = ProductoBL.Instancia.Obtener_Para_Carrito(ref metodoRespuesta, idProducto);
                    OrdenDetalle ordenDetalle = new OrdenDetalle(producto);
                    ordenDetalle.CalcularPrecio();

                    metodoRespuesta.CodigoRespuesta =  ordencabecera.AgregarDetalle(ordenDetalle)? EnumCodigoRespuesta.Exito : EnumCodigoRespuesta.Error;
                }

                ordencabecera.RecalcularMontos();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        #endregion Metodos      
    }
}
