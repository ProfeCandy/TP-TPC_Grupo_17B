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

                string sitioUrl = System.Configuration.ConfigurationManager.AppSettings["SitioUrl"] ?? "https://localhost:44324";
                string urlRecuperacion = $"{sitioUrl}/Usuarios/RestablecerPassword.aspx?token={Server.UrlEncode(token)}";

                try
                {
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
                }
                catch (Exception emailEx)
                {
                    lblMensaje.Visible = true;
                    
                    if (emailEx.Message.Contains("Sender Identity") || emailEx.Message.Contains("verificado") || emailEx.Message.Contains("Forbidden"))
                    {
                        lblMensaje.Text = $@"
                            <p><strong>No se pudo enviar el correo automáticamente</strong> (el email remitente no está verificado en SendGrid).</p>
                            <p class='mb-3'>Podés usar este enlace directo para restablecer tu contraseña:</p>
                            <div class='bg-light p-3 rounded mb-3 text-center'>
                                <a href='{urlRecuperacion}' class='btn btn-danger btn-lg'>Restablecer Contraseña</a>
                            </div>
                            <p class='small text-muted mb-0'>O copiá este enlace: <code class='small' style='word-break: break-all;'>{urlRecuperacion}</code></p>
                            <p class='small text-muted mt-2 mb-0'><strong>Nota:</strong> Este enlace expirará en 24 horas.</p>";
                        lblMensaje.CssClass = "alert alert-warning text-center mb-4 d-block";
                    }
                    else
                    {
                        lblMensaje.Text = $@"
                            <p><strong>No se pudo enviar el correo automáticamente.</strong></p>
                            <p class='mb-3'>Podés usar este enlace directo para restablecer tu contraseña:</p>
                            <div class='bg-light p-3 rounded mb-3 text-center'>
                                <a href='{urlRecuperacion}' class='btn btn-danger btn-lg'>Restablecer Contraseña</a>
                            </div>
                            <p class='small text-muted mb-0'>O copiá este enlace: <code class='small' style='word-break: break-all;'>{urlRecuperacion}</code></p>
                            <p class='small text-muted mt-2 mb-0'><strong>Nota:</strong> Este enlace expirará en 24 horas.</p>";
                        lblMensaje.CssClass = "alert alert-warning text-center mb-4 d-block";
                    }
                    txtEmail.Enabled = false;
                    btnEnviar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = $"Ocurrió un error: {Server.HtmlEncode(ex.Message)}. Por favor, intentá nuevamente más tarde.";
                lblMensaje.CssClass = "alert alert-danger text-center mb-4 d-block";
                throw ex;
            }
        }
    }
}