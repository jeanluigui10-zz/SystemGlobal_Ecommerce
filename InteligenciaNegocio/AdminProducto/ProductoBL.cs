﻿using AccesoDatos.AdminProducto;
using Dominio.Result;
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

        public ProductoResultado ObtenerPrductoPorId(Int32 productId, ref MetodoRespuesta respuesta)
        {
            ProductoResultado productoResultado = null;
            try
            {
                if(productId > 0)
                {
                    productoResultado = ProductoDao.Instancia.ObtenerPrductoPorId(productId, ref respuesta);
                }
                else
                {
                    respuesta = new MetodoRespuesta(EnumTipoMensaje.Error, "El id del producto no puede ser 0");
                }
            }
            catch (Exception exception)
            {
                respuesta = new MetodoRespuesta(EnumTipoMensaje.Error, exception.Message);
            }
            return productoResultado;
        }


        #endregion Metodos

    }
}