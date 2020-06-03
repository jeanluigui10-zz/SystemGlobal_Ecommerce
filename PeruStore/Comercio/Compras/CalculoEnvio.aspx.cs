using Libreria.Base;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web.Services;

namespace PeruStore.Comercio.Compras
{
    public partial class CalculoEnvio : PaginaBase
    {


        [WebMethod]
        public static MetodoRespuesta CargarProvincias()
        {
            MetodoRespuesta metodoRespuesta = null;
            try
            {

            }
            catch (Exception exception)
            {
                throw exception;
            }
            return metodoRespuesta;
        }
    }
}