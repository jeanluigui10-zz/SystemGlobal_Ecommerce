using AccesoDatos.AdminProducto;
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
                if(comercioId > 0)
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
        public ProductoResultado ObtenerPrductoPorId(Int32 productId, ref MetodoRespuesta respuesta)
        {
            ProductoResultado productoResultado = null;
            try
            {
                if (productId > 0)
                {
                    productoResultado = ProductoDao.Instancia.ObtenerPrductoPorId(productId, ref respuesta);
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

    }
}
