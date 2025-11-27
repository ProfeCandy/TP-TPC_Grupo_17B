using System;
using System.Configuration;
using System.Web.UI;
using Negocio;

namespace TPC_ProgIII
{
    public partial class TrabajaConNosotros : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MostrarMensaje("Por favor, completá los campos obligatorios (Nombre y Email).", "warning");
                    return;
                }

                string emailDestinatario = ConfigHelper.ObtenerEmailFrom();
                string nombre = Server.HtmlEncode(txtNombre.Text);
                string email = Server.HtmlEncode(txtEmail.Text);
                string dni = string.IsNullOrWhiteSpace(txtDni.Text) ? "No proporcionado" : Server.HtmlEncode(txtDni.Text);
                string telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? "No proporcionado" : Server.HtmlEncode(txtTelefono.Text);
                string puesto = ddlPuesto.SelectedValue;
                if (string.IsNullOrEmpty(puesto) || puesto == "")
                {
                    puesto = "No especificado";
                }

                string infoCV = "";
                if (fileCV.HasFile)
                {
                    try
                    {
                        string nombreArchivo = Server.HtmlEncode(fileCV.FileName);
                        long tamañoArchivo = fileCV.PostedFile.ContentLength;
                        string tamañoFormateado = tamañoArchivo < 1024 ? $"{tamañoArchivo} bytes" : $"{tamañoArchivo / 1024} KB";
                        infoCV = $"<p><strong>CV adjunto:</strong> {nombreArchivo} ({tamañoFormateado})</p>";
                    }
                    catch
                    {
                        infoCV = "<p><strong>CV:</strong> Se adjuntó un archivo (error al leer detalles)</p>";
                    }
                }
                else
                {
                    infoCV = "<p><strong>CV:</strong> No se adjuntó ningún archivo</p>";
                }

                string cuerpoEmail = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; padding: 20px;'>
                        <h2 style='color: #dc3545;'>Nueva solicitud de trabajo</h2>
                        <div style='background-color: #f8f9fa; padding: 15px; border-radius: 5px; margin: 15px 0;'>
                            <p><strong>Nombre completo:</strong> {nombre}</p>
                            <p><strong>Email:</strong> {email}</p>
                            <p><strong>DNI:</strong> {dni}</p>
                            <p><strong>Teléfono:</strong> {telefono}</p>
                            <p><strong>Puesto de interés:</strong> {puesto}</p>
                            {infoCV}
                        </div>
                        <hr style='border: 1px solid #dee2e6; margin: 20px 0;'>
                        <p style='color: #666; font-size: 14px;'>Este mensaje fue enviado desde el formulario de 'Trabajá con nosotros' del sitio web.</p>
                    </body>
                    </html>";

                EmailServicio emailServicio = new EmailServicio();
                bool modoDesarrollo = ConfigurationManager.AppSettings["EmailModoDesarrollo"] == "true";
                
                bool enviado = emailServicio.EnviarEmail(emailDestinatario, $"Solicitud de trabajo - {puesto}: {nombre}", cuerpoEmail);

                if (enviado)
                {
                    if (modoDesarrollo)
                    {
                        MostrarMensaje("¡Solicitud procesada correctamente! (Modo desarrollo: el correo se registró pero no se envió. Cambiá EmailModoDesarrollo a 'false' en Web.config para enviar realmente).", "info");
                    }
                    else
                    {
                        MostrarMensaje("¡Solicitud enviada correctamente! Te contactaremos a la brevedad.", "success");
                    }
                    
                    LimpiarFormulario();
                }
                else
                {
                    MostrarMensaje("Hubo un error al enviar la solicitud. Por favor, intentá nuevamente más tarde.", "danger");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al enviar la solicitud: " + Server.HtmlEncode(ex.Message) + ". Por favor, intentá nuevamente más tarde.", "danger");
            }
        }

        private void MostrarMensaje(string mensaje, string tipo)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = "alert alert-" + tipo + " mb-4";
            lblMensaje.Visible = true;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtDni.Text = "";
            txtTelefono.Text = "";
            ddlPuesto.SelectedIndex = 0;
        }
    }
}

