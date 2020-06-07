using Dominio.Result.Orden;
using InteligenciaNegocio.AdminOrden;
using Libreria.General;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using System.Web;
using Newtonsoft.Json;

namespace PeruStore.Comercio.Ordenes
{
    public partial class Informacion : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar();
            }
        }

        private void Cargar()
        {
            try
            {
                Int32 idOrden = ObtenerIdOrden();

                Cabecera(idOrden);
                Detalle(idOrden);
                Estados(idOrden);
            }
            catch (Exception exception)
            {
                Mensaje(EnumCodigoRespuesta.Error, "Ocurrio un problema, intentalo otra vez.");
            }
        }

        private Int32 ObtenerIdOrden()
        {
            try
            {
                String idOrdenCifrado = Request.QueryString["o"];
                Boolean _ = Int32.TryParse(Encriptador.Desencriptar(idOrdenCifrado), out Int32 idOrden);
                return idOrden;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void Cabecera(Int32 idOrden)
        {
            try
            {
                HistoricoDTO historicoDTO = ClienteOrdenBl.Instancia.HistoricoCabecera(idOrden);
                hfCabeceraJson.Value = JsonConvert.SerializeObject(historicoDTO); 
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void Detalle(Int32 idOrden)
        {
            try
            {
                HistoricoDetalleResultado historicoDetalleResultado = ClienteOrdenBl.Instancia.HistoricoDetalle(idOrden);
                hfDetalleJson.Value = JsonConvert.SerializeObject(historicoDetalleResultado);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void Estados(Int32 idOrden)
        {
            try
            {
                EstadoResultado estadoResultado = ClienteOrdenBl.Instancia.HistoricoEstado(idOrden);
                hfEstadosJson.Value = JsonConvert.SerializeObject(estadoResultado);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}