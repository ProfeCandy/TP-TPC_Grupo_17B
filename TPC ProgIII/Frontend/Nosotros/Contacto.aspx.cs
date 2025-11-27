using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Frontend
{
    public partial class Contacto : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRedesSociales();
            }
        }

        private void CargarRedesSociales()
        {
            try
            {
                string facebookUrl = ConfigurationManager.AppSettings["FacebookUrl"];
                string instagramUrl = ConfigurationManager.AppSettings["InstagramUrl"];
                string whatsAppUrl = ConfigurationManager.AppSettings["WhatsAppUrl"];
                string linkedInUrl = ConfigurationManager.AppSettings["LinkedInUrl"];

                if (string.IsNullOrEmpty(facebookUrl)) facebookUrl = "https://www.facebook.com";
                if (string.IsNullOrEmpty(instagramUrl)) instagramUrl = "https://www.instagram.com";
                if (string.IsNullOrEmpty(whatsAppUrl)) whatsAppUrl = "https://wa.me/5492991234567";
                if (string.IsNullOrEmpty(linkedInUrl)) linkedInUrl = "https://www.linkedin.com";

                if (lnkFacebookContacto != null) 
                {
                    lnkFacebookContacto.HRef = facebookUrl;
                    lnkFacebookContacto.Attributes["href"] = facebookUrl;
                }
                if (lnkInstagramContacto != null) 
                {
                    lnkInstagramContacto.HRef = instagramUrl;
                    lnkInstagramContacto.Attributes["href"] = instagramUrl;
                }
                if (lnkWhatsAppContacto != null) 
                {
                    lnkWhatsAppContacto.HRef = whatsAppUrl;
                    lnkWhatsAppContacto.Attributes["href"] = whatsAppUrl;
                }
                if (lnkLinkedInContacto != null) 
                {
                    lnkLinkedInContacto.HRef = linkedInUrl;
                    lnkLinkedInContacto.Attributes["href"] = linkedInUrl;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || 
                    string.IsNullOrWhiteSpace(txtAsunto.Text) || string.IsNullOrWhiteSpace(txtMensaje.Text))
                {
                    lblMensaje.Text = "Por favor, completa todos los campos obligatorios.";
                    lblMensaje.CssClass = "alert alert-warning";
                    lblMensaje.Visible = true;
                    return;
                }

                string emailDestinatario = ConfigHelper.ObtenerEmailFrom();
                string nombre = Server.HtmlEncode(txtNombre.Text);
                string email = Server.HtmlEncode(txtEmail.Text);
                string telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? "No proporcionado" : Server.HtmlEncode(txtTelefono.Text);
                string asunto = Server.HtmlEncode(txtAsunto.Text);
                string mensaje = Server.HtmlEncode(txtMensaje.Text);

                string cuerpoEmail = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; padding: 20px;'>
                        <h2 style='color: #dc3545;'>Nuevo mensaje de contacto</h2>
                        <div style='background-color: #f8f9fa; padding: 15px; border-radius: 5px; margin: 15px 0;'>
                            <p><strong>Nombre:</strong> {nombre}</p>
                            <p><strong>Email:</strong> {email}</p>
                            <p><strong>Teléfono:</strong> {telefono}</p>
                            <p><strong>Asunto:</strong> {asunto}</p>
                        </div>
                        <hr style='border: 1px solid #dee2e6; margin: 20px 0;'>
                        <div style='padding: 15px; background-color: #ffffff; border-left: 4px solid #dc3545;'>
                            <p><strong>Mensaje:</strong></p>
                            <p style='white-space: pre-wrap;'>{mensaje.Replace("\n", "<br>")}</p>
                        </div>
                    </body>
                    </html>";

                EmailServicio emailServicio = new EmailServicio();
                bool modoDesarrollo = ConfigurationManager.AppSettings["EmailModoDesarrollo"] == "true";
                
                bool enviado = emailServicio.EnviarEmail(emailDestinatario, $"Contacto: {asunto}", cuerpoEmail);

                if (enviado)
                {
                    if (modoDesarrollo)
                    {
                        lblMensaje.Text = "¡Mensaje procesado correctamente! (Modo desarrollo: el correo se registró pero no se envió. Cambiá EmailModoDesarrollo a 'false' en Web.config para enviar realmente).";
                        lblMensaje.CssClass = "alert alert-info";
                    }
                    else
                    {
                        lblMensaje.Text = "¡Mensaje enviado correctamente! Te responderemos a la brevedad.";
                        lblMensaje.CssClass = "alert alert-success";
                    }
                    lblMensaje.Visible = true;
                    
                    txtNombre.Text = "";
                    txtEmail.Text = "";
                    txtTelefono.Text = "";
                    txtAsunto.Text = "";
                    txtMensaje.Text = "";
                }
                else
                {
                    lblMensaje.Text = "Hubo un error al enviar el mensaje. Por favor, intentá nuevamente más tarde.";
                    lblMensaje.CssClass = "alert alert-danger";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al enviar el mensaje: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
                lblMensaje.Visible = true;
            }
        }
    }
}

