using AccesoDatos.AdminOrden;
using Dominio.Result.Orden;
using System;

namespace InteligenciaNegocio.AdminOrden
{
    public class ClienteOrdenBl
    {
        #region Singleton
        private static ClienteOrdenBl _instancia = null;
        public static ClienteOrdenBl Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ClienteOrdenBl();
                }
                return _instancia;
            }
        }
        #endregion Singleton

        #region Metodos

        public HistoricoResultado ObtenerHistorico(Int16 idComercio, Int32 idCliente)
        {
            HistoricoResultado ordenHistoricoResultado = null;
            try
            {
                if(idComercio > 0 && idCliente > 0)
                {
                    ordenHistoricoResultado = ClienteOrdenDao.Instancia.ObtenerHistorico(idComercio, idCliente);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return ordenHistoricoResultado;
        }


        #endregion Metodos

    }
}
