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

        public HistoricoResultado Historico(Int16 idComercio, Int32 idCliente)
        {
            HistoricoResultado ordenHistoricoResultado = null;
            try
            {
                if (idComercio > 0 && idCliente > 0)
                {
                    ordenHistoricoResultado = ClienteOrdenDao.Instancia.Historico(idComercio, idCliente);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return ordenHistoricoResultado;
        }

        public HistoricoDTO HistoricoCabecera(Int32 idOrden)
        {
            HistoricoDTO historicoDTO = null;
            try
            {
                if (idOrden > 0)
                {
                    historicoDTO = ClienteOrdenDao.Instancia.HistoricoCabecera(idOrden);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return historicoDTO;
        }

        public HistoricoDetalleResultado HistoricoDetalle(Int32 idOrden)
        {
            HistoricoDetalleResultado historicoDetalleResultado = null;
            try
            {
                if (idOrden > 0)
                {
                    historicoDetalleResultado = ClienteOrdenDao.Instancia.HistoricoDetalle(idOrden);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return historicoDetalleResultado;
        }

        public EstadoResultado HistoricoEstado(Int32 idOrden)
        {
            EstadoResultado estadoResultado = null;
            try
            {
                if (idOrden > 0)
                {
                    estadoResultado = ClienteOrdenDao.Instancia.HistoricoEstado(idOrden);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return estadoResultado;
        }

        #endregion Metodos

    }
}
