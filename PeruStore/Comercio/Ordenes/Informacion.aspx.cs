using PeruStore.src.ConfiguracionAplicacion;
using System;

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
            Cabecera();
            Detalle();
            Estados();
        }

        private void Cabecera()
        {

        }

        private void Detalle()
        {

        }

        private void Estados()
        {

        }

    }
}