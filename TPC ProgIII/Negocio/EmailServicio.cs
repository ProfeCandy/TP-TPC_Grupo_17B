using System;
using System.Configuration;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Negocio
{
    public class EmailServicio
    {
        private string EmailFrom
        {
            get
            {
                try
                {
                    string valor = ConfigHelper.ObtenerEmailFrom();
                    if (!string.IsNullOrEmpty(valor))
                    {
                        return valor;
                    }
                }
                catch
                {
                }
                return ConfigurationManager.AppSettings["EmailFrom"] ?? "noreply@tuempresa.com";
            }
        }
        private string EmailFromName => ConfigurationManager.AppSettings["EmailFromName"] ?? "AutoParts";
        private string SitioUrl => ConfigurationManager.AppSettings["SitioUrl"] ?? "https://localhost:44324";
        private bool ModoDesarrollo => ConfigurationManager.AppSettings["EmailModoDesarrollo"] == "true";
        
        private string SendGridApiKey
        {
            get
            {
                string apiKey = ConfigurationManager.AppSettings["SendGridApiKey"];
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new Exception("SendGridApiKey no está configurada en Web.config. Por favor, agrega la clave API de SendGrid.");
                }
                return apiKey;
            }
        }

        public bool EnviarEmail(string destinatario, string asunto, string cuerpo, bool esHtml = true)
        {
            try
            {
                if (ModoDesarrollo)
                {
                    System.Diagnostics.Debug.WriteLine($"=== EMAIL (MODO DESARROLLO - NO ENVIADO) ===");
                    System.Diagnostics.Debug.WriteLine($"Desde: {EmailFrom} ({EmailFromName})");
                    System.Diagnostics.Debug.WriteLine($"Para: {destinatario}");
                    System.Diagnostics.Debug.WriteLine($"Asunto: {asunto}");
                    System.Diagnostics.Debug.WriteLine($"Cuerpo: {cuerpo}");
                    System.Diagnostics.Debug.WriteLine($"==========================================");
                    return true;
                }


                return Task.Run(async () => await EnviarEmailAsync(destinatario, asunto, cuerpo, esHtml)).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al enviar email: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Stack trace: " + ex.StackTrace);
                throw new Exception("Error al enviar el correo: " + ex.Message, ex);
            }
        }

        private async Task<bool> EnviarEmailAsync(string destinatario, string asunto, string cuerpo, bool esHtml)
        {
            try
            {
                var client = new SendGridClient(SendGridApiKey);
                var from = new EmailAddress(EmailFrom, EmailFromName);
                var to = new EmailAddress(destinatario);
                var msg = MailHelper.CreateSingleEmail(from, to, asunto, esHtml ? null : cuerpo, esHtml ? cuerpo : null);
                
                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
                
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted || 
                    response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    var responseBody = await response.Body.ReadAsStringAsync().ConfigureAwait(false);
                    throw new Exception($"SendGrid retornó un código de estado inesperado: {response.StatusCode}. Respuesta: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al enviar email con SendGrid: " + ex.Message);
                throw;
            }
        }

        public bool EnviarConfirmacionRegistro(string email, string nombre, string token)
        {
            string urlConfirmacion = $"{SitioUrl}/ConfirmarEmail.aspx?token={token}";
            string cuerpo = $@"
                <html>
                <body style='font-family: Arial, sans-serif;'>
                    <h2>¡Bienvenido a AutoParts!</h2>
                    <p>Hola {nombre},</p>
                    <p>Gracias por registrarte. Para activar tu cuenta, haz clic en el siguiente enlace:</p>
                    <p><a href='{urlConfirmacion}' style='background-color: #dc3545; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px;'>Confirmar mi cuenta</a></p>
                    <p>O copia este enlace: {urlConfirmacion}</p>
                    <p>Saludos,<br/>El equipo de AutoParts</p>
                </body>
                </html>";

            return EnviarEmail(email, "Confirma tu cuenta - AutoParts", cuerpo);
        }

        public bool EnviarRecuperacionPassword(string email, string nombre, string token)
        {
            string urlRecuperacion = $"{SitioUrl}/RestablecerPassword.aspx?token={token}";
            string cuerpo = $@"
                <html>
                <body style='font-family: Arial, sans-serif;'>
                    <h2>Recuperaci&oacute;n de contrase&ntilde;a</h2>
                    <p>Hola {nombre},</p>
                    <p>Haz clic en el siguiente enlace para restablecer tu contrase&ntilde;a:</p>
                    <p><a href='{urlRecuperacion}' style='background-color: #dc3545; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px;'>Restablecer contrase&ntilde;a</a></p>
                    <p>O copia este enlace: {urlRecuperacion}</p>
                    <p><strong>Este enlace expirar&aacute; en 24 horas.</strong></p>
                    <p>Saludos,<br/>El equipo de AutoParts</p>
                </body>
                </html>";

            return EnviarEmail(email, "Recuperar contraseña - AutoParts", cuerpo);
        }
    }
}

