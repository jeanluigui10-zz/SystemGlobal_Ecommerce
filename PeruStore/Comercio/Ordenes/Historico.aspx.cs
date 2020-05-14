using Libreria.General;
using PeruStore.src.app_code;
using System;
using Dominio.Result.Orden;
using InteligenciaNegocio.AdminOrden;
using Newtonsoft.Json;

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
                Int16 idComercio = 1;
                Int32 idCliente = 1;

                OrdenHistoricoResultado ordenHistoricoResultado = ClienteOrdenBl.Instancia.ObtenerHistorico(idComercio, idCliente);
                hfOrdenHistorico.Value = JsonConvert.SerializeObject(ordenHistoricoResultado);

            }
            catch (Exception exception)
            {
                Mensaje(EnumTipoMensaje.Error, "Ocurrio un problema, intentalo otra vez.");
            }
        }
    }
}