using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Frontend
{
    public partial class RestablecerPassword : System.Web.UI.Page
    {
        private string token;
        private Usuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            token = Request.QueryString["token"];

            if (string.IsNullOrEmpty(token))
            {
                MostrarError("Enlace inválido. Por favor, solicitá un nuevo enlace de recuperación.");
                pnlRestablecer.Visible = false;
                return;
            }

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuario = usuarioNegocio.BuscarPorTokenRecuperacion(token);

            if (usuario == null)
            {
                MostrarError("El enlace de recuperación ha expirado o no es válido. Por favor, solicitá un nuevo enlace.");
                pnlRestablecer.Visible = false;
                return;
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (usuario == null)
                    {
                        MostrarError("Sesión expirada. Por favor, solicitá un nuevo enlace.");
                        return;
                    }

                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    usuarioNegocio.ActualizarPassword(usuario.IdUsuario, txtPassword.Text);

                    Response.Redirect("~/Usuarios/Login.aspx?mensaje=passwordRestablecida", false);
                }
                catch (Exception ex)
                {
                    MostrarError("Ocurrió un error al restablecer la contraseña. Por favor, intentá nuevamente.");
                }
            }
        }

        private void MostrarError(string mensaje)
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = "alert alert-danger text-center mb-4 d-block";
        }
    }
}