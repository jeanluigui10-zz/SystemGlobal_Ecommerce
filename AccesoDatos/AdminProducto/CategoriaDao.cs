using Dominio.Result;
using Libreria.AdminConexion;
using Libreria.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.AdminProducto
{
    public class CategoriaDao
    {
        #region Singleton
        private static CategoriaDao _instancia = null;
        public static CategoriaDao instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CategoriaDao();
                return _instancia;
            }
        }
        #endregion

        #region Metodos
        public CategoriaResultado Categoria_ObtenerLista(ref MetodoRespuesta metodoRespuesta, Int32 IdComercio)
        {
            CategoriaResultado categoriaResultado = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Categoria_Lista_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@IdComercio", IdComercio);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        categoriaResultado = new CategoriaResultado();
                        while (sqlDataReader.Read())
                        {
                            categoriaResultado.Datos.Add(new CategoriaDTO()
                            {
                                IdCategoria = Convert.ToInt16(sqlDataReader["IdCategoria"]),
                                CategoriaNombre = Convert.ToString(sqlDataReader["CategoriaNombre"])

                            }); 
                        }
                    }
                }
                catch (Exception exception)
                {
                    metodoRespuesta.Errors.Add(new MetodoRespuesta.ListError(exception, "Ocurrio un error al cargar la data."));
                    throw exception;
                }
            }
            return categoriaResultado;
        }
        #endregion
    }
}
