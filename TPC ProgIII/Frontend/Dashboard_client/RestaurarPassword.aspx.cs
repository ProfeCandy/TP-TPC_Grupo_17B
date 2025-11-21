using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.Dashboard_client
{
    public partial class RestaurarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCambiarPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassActual.Text) ||
                string.IsNullOrWhiteSpace(txtPassNueva.Text) ||
                string.IsNullOrWhiteSpace(txtPassConfirmar.Text))
            {
                MostrarMensaje("Por favor, completa todos los campos.", true);
                return;
            }

            if (txtPassNueva.Text != txtPassConfirmar.Text)
            {
                MostrarMensaje("Las contraseñas nuevas no coinciden.", true);
                return;
            }

            if (txtPassNueva.Text.Length < 8)
            {
                MostrarMensaje("La contraseña debe tener al menos 8 caracteres.", true);
                return;
            }

            bool cambioExitoso = true; 

            if (cambioExitoso)
            {
                MostrarMensaje("¡Contraseña actualizada correctamente!", false);

                txtPassActual.Text = "";
                txtPassNueva.Text = "";
                txtPassConfirmar.Text = "";
            }
            else
            {
                MostrarMensaje("La contraseña actual no es correcta.", true);
            }
        }

        private void MostrarMensaje(string texto, bool esError)
        {
            pnlMensaje.Visible = true;
            lblMensaje.Text = texto;

            if (esError)
            {
                pnlMensaje.CssClass = "alert alert-danger mb-4";
            }
            else
            {
                pnlMensaje.CssClass = "alert alert-success mb-4";
            }
        }
    }
}