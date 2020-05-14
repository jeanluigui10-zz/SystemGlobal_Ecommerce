using AccesoDatos.AdminProducto;
using Dominio.Result;
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

        public ProductoResultado ObtenerPrducto_PorId(Int32 productId)
        {
            ProductoResultado productoResultado = null;
            try
            {
                if(productId > 0)
                {
                    productoResultado = ProductoDao.Instancia.ObtenerPrducto_PorId(productId);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return productoResultado;
        }


        #endregion Metodos

    }
}
