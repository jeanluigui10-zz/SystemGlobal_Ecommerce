using AccesoDatos.AdminProducto;
using Dominio.Entidades.SucursalProducto;
using Dominio.Result.Producto;
using Libreria.Base;
using Libreria.General;
using System;

namespace InteligenciaNegocio.AdminProducto
{
    public class ProductoBL
    {
        #region Singleton
        private static ProductoBL _instancia = null;
        public static ProductoBL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ProductoBL();
                }
                return _instancia;
            }
        }
        #endregion Singleton

        #region Metodos

        public ProductoResultado ListaProdctosPorComercio(Int32 comercioId, ref MetodoRespuesta respuesta)
        {
            ProductoResultado productoResultado = null;
            try
            {
                if (comercioId > 0)
                {
                    productoResultado = ProductoDao.Instancia.ListaProdctosPorComercio(comercioId, ref respuesta);
                }
                else
                {
                    respuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, "El id del comercio no puede ser 0");
                }
            }
            catch (Exception exception)
            {
                respuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, exception.Message);
            }
            return productoResultado;
        }
        public ProductoResultado ListaProdctosPor_Comercio_Categoria(Int32 IdComercio, Int32 IdCategoria, ref MetodoRespuesta metodoRespuesta)
        {
            ProductoResultado productoResultado = null;
            try
            {
                if (IdComercio > 0 && IdCategoria > 0)
                {
                    productoResultado = ProductoDao.Instancia.ListaProdctosPor_Comercio_Categoria(IdComercio, IdCategoria, ref metodoRespuesta);
                }
                else
                {
                    metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, "El id del comercio o categoria no puede ser 0");
                }
            }
            catch (Exception exception)
            {
                metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, exception.Message);
            }
            return productoResultado;
        }
        public ProductoResultado ObtenerPrductoPorId(Int32 productId, Int32 sucursalId, ref MetodoRespuesta respuesta)
        {
            ProductoResultado productoResultado = null;
            try
            {
                if (productId > 0)
                {
                    productoResultado = ProductoDao.Instancia.ObtenerPrductoPorId(productId, sucursalId, ref respuesta);
                }
                else
                {
                    respuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, "El id del producto no puede ser 0");
                }
            }
            catch (Exception exception)
            {
                respuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, exception.Message);
            }
            return productoResultado;
        }


        #endregion Metodos

        #region Metodos para carrito
        public Producto Obtener_Para_Carrito(ref MetodoRespuesta metodoRespuesta, Int32 idProducto)
        {
            Producto producto = null;
            try
            {
                if (Validar.EsValido(idProducto))
                {
                    producto = ProductoDao.Instancia.Obtener_Para_Carrito(ref metodoRespuesta, idProducto);
                    if (metodoRespuesta.CodigoRespuesta == EnumCodigoRespuesta.Error || !Validar.EsValido(producto))
                    {
                        metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, "No es posible agregar este producto al carrito.");
                    }
                }
                else
                {
                    metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error, "No es posible agregar este producto al carrito.");
                }
            }
            catch (Exception exception)
            {
                metodoRespuesta = new MetodoRespuesta(EnumCodigoRespuesta.Error);
                throw exception;
            }
            return producto;
        }

        #endregion Metodos para carrito
    }
}
