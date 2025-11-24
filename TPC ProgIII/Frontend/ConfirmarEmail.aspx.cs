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

            // Si viene desde el registro (sin token), mostrar mensaje de espera
            if (string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(email))
            {
                panelEspera.Visible = true;
                panelExito.Visible = false;
                panelError.Visible = false;
                lblMensajeEspera.Text = $"Hemos enviado un email de confirmaci&oacute;n a <strong>{Server.HtmlEncode(email)}</strong>.<br/>Por favor, revisa tu bandeja de entrada y haz clic en el enlace para activar tu cuenta.";
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
                catch (Exception ex)
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

