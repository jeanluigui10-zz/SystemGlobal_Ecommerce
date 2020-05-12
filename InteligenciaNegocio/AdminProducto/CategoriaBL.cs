using AccesoDatos.AdminProducto;
using Libreria.Base;
using System;
using System.Data;

namespace InteligenciaNegocio.AdminProducto
{
    public class CategoriaBL
    {
        #region Singleton
        private static CategoriaBL instance = null;
        public static CategoriaBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoriaBL();
                return instance;
            }
        }
        #endregion

        public DataTable Categoria_Lista(ref MetodoRespuesta objRespuesta)
        {
            try
            {
                objRespuesta = new MetodoRespuesta();
                DataTable dt = null;
                dt = CategoriaDao.Instance.Categoria_Lista(ref objRespuesta);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
