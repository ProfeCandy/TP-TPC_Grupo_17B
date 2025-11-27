using Dominio;
using Negocio;
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
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Usuarios/Login.aspx");
            }
        }
        protected void btnCambiarPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassActual.Text) ||
                string.IsNullOrWhiteSpace(txtPassNueva.Text) ||
                string.IsNullOrWhiteSpace(txtPassConfirmar.Text))
            {
                MostrarMensaje("Por favor, completa todos los campos.", true);
                MantenerContrasenaActual();
                return;
            }

            if (txtPassNueva.Text != txtPassConfirmar.Text)
            {
                MostrarMensaje("Las contraseñas nuevas no coinciden.", true);
                MantenerContrasenaActual();
                return;
            }

            if (txtPassNueva.Text.Length < 6)
            {
                MostrarMensaje("La contraseña debe tener al menos 6 caracteres.", true);
                MantenerContrasenaActual();
                return;
            }

            if (txtPassActual.Text == txtPassNueva.Text)
            {
                MostrarMensaje("La nueva contraseña no puede ser igual a la actual.", true);
                MantenerContrasenaActual();
                return;
            }

            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                UsuarioNegocio negocio = new UsuarioNegocio();

                if (!negocio.VerificarContrasenaActual(usuario.IdUsuario, txtPassActual.Text))
                {
                    MostrarMensaje("La contraseña actual ingresada es incorrecta.", true);
                    return;
                }
                negocio.ModificarClave(usuario.IdUsuario, txtPassNueva.Text);

                MostrarMensaje("¡Contraseña actualizada correctamente!", false);
                txtPassActual.Text = "";
                txtPassNueva.Text = "";
                txtPassConfirmar.Text = "";
 
                usuario.Clave = txtPassNueva.Text;
                Session["usuario"] = usuario;
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cambiar la contraseña: " + ex.Message, true);
                MantenerContrasenaActual();
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
        private void MantenerContrasenaActual()
        {
            txtPassActual.Attributes["value"] = txtPassActual.Text;
        }
    }
}