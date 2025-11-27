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
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Por favor, ingresá tu email.";
                    lblMensaje.CssClass = "alert alert-danger text-center mb-4 d-block";
                    return;
                }

                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = usuarioNegocio.BuscarPorEmail(txtEmail.Text);

                if (usuario == null)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Si el email existe en nuestro sistema, recibirás un correo con las instrucciones.";
                    lblMensaje.CssClass = "alert alert-info text-center mb-4 d-block";
                    txtEmail.Enabled = false;
                    btnEnviar.Enabled = false;
                    return;
                }

                string token = Guid.NewGuid().ToString();
                usuarioNegocio.GenerarTokenRecuperacion(usuario.Email, token);

                EmailServicio emailServicio = new EmailServicio();
                string nombreCompleto = $"{usuario.Nombre} {usuario.Apellido}";
                bool emailEnviado = emailServicio.EnviarRecuperacionPassword(usuario.Email, nombreCompleto, token);

                if (emailEnviado)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Hemos enviado un correo a tu dirección de email con las instrucciones para restablecer tu contraseña.";
                    lblMensaje.CssClass = "alert alert-success text-center mb-4 d-block";
                    txtEmail.Enabled = false;
                    btnEnviar.Enabled = false;
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Hubo un error al enviar el correo. Por favor, intentá nuevamente más tarde.";
                    lblMensaje.CssClass = "alert alert-danger text-center mb-4 d-block";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Ocurrió un error. Por favor, intentá nuevamente más tarde.";
                lblMensaje.CssClass = "alert alert-danger text-center mb-4 d-block";
                throw ex;
            }
        }
    }
}