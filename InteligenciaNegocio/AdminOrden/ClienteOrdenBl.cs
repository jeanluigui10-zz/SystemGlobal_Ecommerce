﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Result;
using AccesoDatos.AdminOrden;

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

        public OrdenHistoricoResultado ObtenerHistorico(Int16 idComercio, Int32 idCliente)
        {
            OrdenHistoricoResultado ordenHistoricoResultado = null;
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