using Libreria.General;
using PeruStore.src.ConfiguracionAplicacion;
using System;
using Dominio.Result.Orden;
using InteligenciaNegocio.AdminOrden;
using Newtonsoft.Json;
using PeruStore.src.BaseAplicacion;

namespace PeruStore.Comercio.Ordenes
{
    public partial class Historico : PaginaBase
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
                Int16 idComercio = SesionAplicacion.SesionTienda.IdComercio;
                Int32 idCliente = 1; // SesionAplicacion.SesionCliente.IdCliente;

                HistoricoResultado ordenHistoricoResultado = ClienteOrdenBl.Instancia.Historico(idComercio, idCliente);
                hfOrdenHistorico.Value = JsonConvert.SerializeObject(ordenHistoricoResultado);

            }
            catch (Exception exception)
            {
                Mensaje(EnumCodigoRespuesta.Error, "Ocurrio un problema, intentalo otra vez.");
            }
        }
    }
}