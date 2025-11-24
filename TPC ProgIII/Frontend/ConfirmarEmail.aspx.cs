using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Frontend
{
    public partial class ConfirmarEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string token = Request.QueryString["token"];
            string email = Request.QueryString["email"];
            string modoDev = Request.QueryString["modoDev"];

            // Si viene desde el registro (sin token), mostrar mensaje de espera
            if (string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(email))
            {
                panelEspera.Visible = true;
                panelExito.Visible = false;
                panelError.Visible = false;
                lblMensajeEspera.Text = $"Hemos enviado un email de confirmaci&oacute;n a <strong>{Server.HtmlEncode(email)}</strong>.<br/>Por favor, revisa tu bandeja de entrada y haz clic en el enlace para activar tu cuenta.";
                return;
            }

            // Si viene en modo desarrollo con token, mostrar mensaje especial con el enlace
            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(email) && modoDev == "true")
            {
                panelEspera.Visible = true;
                panelExito.Visible = false;
                panelError.Visible = false;
                string sitioUrl = System.Configuration.ConfigurationManager.AppSettings["SitioUrl"] ?? "https://localhost:44324";
                string urlConfirmacion = $"{sitioUrl}/ConfirmarEmail.aspx?token={Server.UrlEncode(token)}";
                lblMensajeEspera.Text = $@"
                    <p>Hemos enviado un email de confirmaci&oacute;n a <strong>{Server.HtmlEncode(email)}</strong>.</p>
                    <p class='mb-3'>Haz clic en el siguiente enlace para activar tu cuenta:</p>
                    <div class='bg-light p-3 rounded mb-3 text-center'>
                        <a href='{urlConfirmacion}' class='btn btn-danger btn-lg'>Confirmar mi cuenta</a>
                    </div>
                    <p class='small text-muted mb-0'>O copia este enlace: <code class='small'>{urlConfirmacion}</code></p>";
                return;
            }

            // Si hay token, intentar confirmar
            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    
                    // Confirmar email usando el token
                    negocio.ConfirmarEmail(token);
                    
                    // Mostrar mensaje de éxito
                    panelExito.Visible = true;
                    panelError.Visible = false;
                    panelEspera.Visible = false;
                    lblMensajeExito.Text = "Tu cuenta ha sido confirmada exitosamente.<br/>Ya puedes iniciar sesi&oacute;n.";
                }
                catch (Exception)
                {
                    // Mostrar mensaje de error
                    panelError.Visible = true;
                    panelExito.Visible = false;
                    panelEspera.Visible = false;
                    lblMensajeError.Text = "El token de confirmaci&oacute;n no es v&aacute;lido o ha expirado.<br/>Por favor, solicita un nuevo enlace de confirmaci&oacute;n.";
                }
            }
            else
            {
                // Si no hay token ni email, mostrar error
                panelError.Visible = true;
                panelExito.Visible = false;
                panelEspera.Visible = false;
                lblMensajeError.Text = "Enlace de confirmaci&oacute;n inv&aacute;lido.";
            }
        }
    }
}

