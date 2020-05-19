using AccesoDatos.AdminProducto;
using Dominio.Result.Producto;
using Libreria.Base;
using Libreria.General;
using System;

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
        
     public CategoriaResultado SubCategoria_ObtenerLista_PorIdCategoria(ref MetodoRespuesta metodoRespuesta, Int16 IdSubCategoria)
        {
            CategoriaResultado categoriaResultado = null;
            try
            {
                if (IdSubCategoria > 0)
                {
                    categoriaResultado = CategoriaDao.instancia.SubCategoria_ObtenerLista_PorIdCategoria(ref metodoRespuesta, IdSubCategoria);
                }
            }
            catch (Exception exception)
            {
                metodoRespuesta = new MetodoRespuesta(EnumTipoMensaje.Error, exception.Message);
                throw exception;
            }
            return categoriaResultado;
        }

        public CategoriaResultado SubCategoria_ObtenerLista_PorIdSubCategoria(ref MetodoRespuesta metodoRespuesta, Int32 IdSubCategoria)
        {
            CategoriaResultado categoriaResultado = null;
            try
            {
                if (IdSubCategoria > 0)
                {
                    categoriaResultado = CategoriaDao.instancia.SubCategoria_ObtenerLista_PorIdSubCategoria(ref metodoRespuesta, IdSubCategoria);
                }
            }
            catch (Exception exception)
            {
                metodoRespuesta = new MetodoRespuesta(EnumTipoMensaje.Error, exception.Message);
                throw exception;
            }
            return categoriaResultado;
        }
        public CategoriaResultado Categoria_ObtenerLista(ref MetodoRespuesta metodoRespuesta, Int32 IdComercio)
        {
            CategoriaResultado categoriaResultado = null;
            try
            {
                if (IdComercio > 0)
                {
                    categoriaResultado = CategoriaDao.instancia.Categoria_ObtenerLista(ref metodoRespuesta, IdComercio);
                }
            }
            catch (Exception exception)
            {
                metodoRespuesta = new MetodoRespuesta(EnumTipoMensaje.Error, exception.Message);
                throw exception;
            }
            return categoriaResultado;
        }
        #endregion
    }
}
