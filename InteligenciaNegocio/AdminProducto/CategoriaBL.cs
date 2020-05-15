﻿using AccesoDatos.AdminProducto;
using Dominio.Result;
using Libreria.Base;
using System;
using System.Data;

namespace InteligenciaNegocio.AdminProducto
{
    public class CategoriaBL
    {
        #region Singleton
        private static CategoriaBL _instancia = null;
        public static CategoriaBL instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CategoriaBL();
                return _instancia;
            }
        }
        #endregion

        #region Metodos
        public CategoriaResultado Categoria_ObtenerLista(ref MetodoRespuesta metodoRespuesta, Int32 IdComercio)
        {
            CategoriaResultado categoriaResultado = null;
            try
            {
                if (IdComercio > 0) {
                    categoriaResultado = CategoriaDao.instancia.Categoria_ObtenerLista(ref metodoRespuesta, IdComercio);
                }
            }
            catch (Exception exception)
            {
                metodoRespuesta.Errors.Add(new MetodoRespuesta.ListError(exception, "Ocurrio un error al cargar la data."));
                throw exception;
            }
            return categoriaResultado;
        }
        #endregion
    }
}
