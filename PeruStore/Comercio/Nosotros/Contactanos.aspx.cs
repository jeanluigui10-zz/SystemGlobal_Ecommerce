using PeruStore.src.ConfiguracionAplicacion;
using System;
using Dominio.Entidades.Comercio;
using PeruStore.src.BaseAplicacion;
using Libreria.Base;
using InteligenciaNegocio.AdminTienda;

namespace PeruStore.Comercio.Nosotros
{
    public partial class Contactanos : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // code here
            }
        }


        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                TiendaContacto tiendaContacto = new TiendaContacto()
                {
                    Tienda = new Tienda()
                    {
                        IdComercio = SesionAplicacion.SesionTienda.IdComercio
                    },
                    Nombre = txtNombre.Value,
                    Email = txtEmail.Value,
                    Asunto = String.Empty,
                    Mensaje = txtConsulta.Value,
                };

                MetodoRespuesta metodoRespuesta = TiendaBl.Instancia.Contactanos_Guardar_Mensaje(tiendaContacto);
            }
            catch (Exception exception)
            {
                Mensaje(Libreria.General.EnumCodigoRespuesta.Error, "Ocurrio un problema, intentalo mas tarde.");
            }
        }
    }
}