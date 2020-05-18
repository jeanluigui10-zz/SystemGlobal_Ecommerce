using Dominio.Result.Ubigeo;
using Libreria.AdminConexion;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.AdminUbigeo
{
    public class UbigeoDao
    {
        #region Singleton
        private static UbigeoDao _instancia = null;
        public static UbigeoDao Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new UbigeoDao();
                }
                return _instancia;
            }
        }
        #endregion Singleton

        #region Metodos

        public UbigeoResultado ObtenerRegion()
        {
            UbigeoResultado objUbigeo = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Ubigeo_Region_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                   
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        objUbigeo = new UbigeoResultado();
                        while (sqlDataReader.Read())
                        {
                            objUbigeo.Regiones.Add(new RegionResultadoDTO()
                            {
                                IdRegion = Convert.ToInt16(sqlDataReader["IdRegion"]),
                                RegionNombre = Convert.ToString(sqlDataReader["RegionNombre"])
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return objUbigeo;
        }

        public UbigeoResultado ObtenerProvincias_PorIdRegion(Int16 idRegion)
        {
            UbigeoResultado objUbigeo = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Ubigeo_Provincia_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@idRegion", idRegion );

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        objUbigeo = new UbigeoResultado();
                        while (sqlDataReader.Read())
                        {
                            objUbigeo.Provincias.Add(new ProvinciaResultadoDTO()
                            {
                                IdProvincia = Convert.ToInt16(sqlDataReader["IdProvincia"]),
                                ProvinciaNombre = Convert.ToString(sqlDataReader["ProvinciaNombre"])
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return objUbigeo;
        }

        public UbigeoResultado ObtenerDistrito_PorIdprovincia(Int16 idProvincia)
        {
            UbigeoResultado objUbigeo = null;
            using (SqlConnection sqlConnection = Conexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("Ubigeo_Distrito_Pa", sqlConnection) { CommandType = CommandType.StoredProcedure };
                    sqlCommand.Parameters.AddWithValue("@idProvincia", idProvincia);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        objUbigeo = new UbigeoResultado();
                        while (sqlDataReader.Read())
                        {
                            objUbigeo.Distritos.Add(new DistritoResultadoDTO()
                            {
                                IdDistrito = Convert.ToInt16(sqlDataReader["IdDistrito"]),
                                DistritoNombre = Convert.ToString(sqlDataReader["DistritoNombre"])
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return objUbigeo;
        }

        #endregion Metodos
    }
}
