using AccesoDatos.AdminUbigeo;
using Dominio.Result.Ubigeo;
using System;

namespace InteligenciaNegocio.AdminUbigeo
{
    public class UbigeoBl
    {
        #region Singleton
        private static UbigeoBl _instancia = null;
        public static UbigeoBl Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new UbigeoBl();
                }
                return _instancia;
            }
        }
        #endregion Singleton

        #region Metodos

        public UbigeoResultado ObtenerRegion()
        {
            UbigeoResultado regiones = null;
            try
            {
                regiones = UbigeoDao.Instancia.ObtenerRegion();                
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return regiones;
        }
        public UbigeoResultado ObtenerProvincias_PorIdRegion(Int16 idRegion)
        {
            UbigeoResultado provincias = null;
            try
            {
                provincias = UbigeoDao.Instancia.ObtenerProvincias_PorIdRegion(idRegion);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return provincias;
        }
        public UbigeoResultado ObtenerDistrito_PorIdProvincia(Int16 idProvincia)
        {
            UbigeoResultado distritos = null;
            try
            {
                distritos = UbigeoDao.Instancia.ObtenerDistrito_PorIdprovincia(idProvincia);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return distritos;
        }

        #endregion Metodos
    }
}
