using System;
using System.Configuration;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Dominio;

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

        public bool EnviarConfirmacionPedido(string email, string nombre, int idPedido, decimal total, string metodoPago, string metodoEnvio, string direccionEnvio, System.Collections.Generic.List<Dominio.DetallePedido> detalles)
        {
            string urlPedido = $"{SitioUrl}/Dashboard_client/DetallePedido.aspx?id={idPedido}";
            
            // Construir tabla de productos
            string tablaProductos = "<table style='width: 100%; border-collapse: collapse; margin: 20px 0;'>";
            tablaProductos += "<thead><tr style='background-color: #dc3545; color: white;'>";
            tablaProductos += "<th style='padding: 10px; text-align: left; border: 1px solid #ddd;'>Producto</th>";
            tablaProductos += "<th style='padding: 10px; text-align: center; border: 1px solid #ddd;'>Cantidad</th>";
            tablaProductos += "<th style='padding: 10px; text-align: right; border: 1px solid #ddd;'>Precio Unitario</th>";
            tablaProductos += "<th style='padding: 10px; text-align: right; border: 1px solid #ddd;'>Subtotal</th>";
            tablaProductos += "</tr></thead><tbody>";
            
            foreach (var detalle in detalles)
            {
                decimal subtotal = detalle.PrecioUnitario * detalle.Cantidad;
                tablaProductos += "<tr>";
                tablaProductos += $"<td style='padding: 10px; border: 1px solid #ddd;'>{detalle.Producto.NombreProducto}</td>";
                tablaProductos += $"<td style='padding: 10px; text-align: center; border: 1px solid #ddd;'>{detalle.Cantidad}</td>";
                tablaProductos += $"<td style='padding: 10px; text-align: right; border: 1px solid #ddd;'>${detalle.PrecioUnitario:N2}</td>";
                tablaProductos += $"<td style='padding: 10px; text-align: right; border: 1px solid #ddd;'>${subtotal:N2}</td>";
                tablaProductos += "</tr>";
            }
            
            tablaProductos += "</tbody></table>";
            
            // Información de envío
            string infoEnvio = "";
            if (metodoEnvio == "Domicilio" && !string.IsNullOrEmpty(direccionEnvio))
            {
                infoEnvio = $"<p><strong>Direcci&oacute;n de env&iacute;o:</strong> {direccionEnvio}</p>";
            }
            else
            {
                infoEnvio = "<p><strong>M&eacute;todo de env&iacute;o:</strong> Retiro en sucursal</p>";
            }
            
            string cuerpo = $@"
                <html>
                <body style='font-family: Arial, sans-serif; padding: 20px; background-color: #f5f5f5;'>
                    <div style='max-width: 600px; margin: 0 auto; background-color: white; padding: 30px; border-radius: 10px; box-shadow: 0 2px 4px rgba(0,0,0,0.1);'>
                        <h2 style='color: #dc3545; margin-bottom: 20px;'>¡Pedido Confirmado!</h2>
                        <p>Hola {nombre},</p>
                        <p>Gracias por tu compra. Tu pedido ha sido recibido y est&aacute; siendo procesado.</p>
                        
                        <div style='background-color: #f8f9fa; padding: 15px; border-radius: 5px; margin: 20px 0;'>
                            <p><strong>N&uacute;mero de pedido:</strong> #{idPedido}</p>
                            <p><strong>Fecha:</strong> {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}</p>
                            <p><strong>M&eacute;todo de pago:</strong> {metodoPago}</p>
                            {infoEnvio}
                        </div>
                        
                        <h3 style='color: #333; margin-top: 30px;'>Detalle de tu pedido:</h3>
                        {tablaProductos}
                        
                        <div style='text-align: right; margin-top: 20px; padding-top: 20px; border-top: 2px solid #dc3545;'>
                            <p style='font-size: 18px; font-weight: bold; color: #dc3545;'>
                                Total: ${total:N2}
                            </p>
                        </div>
                        
                        <p style='margin-top: 30px;'>
                            Puedes ver el estado de tu pedido haciendo clic en el siguiente enlace:
                        </p>
                        <p style='text-align: center; margin: 20px 0;'>
                            <a href='{urlPedido}' style='background-color: #dc3545; color: white; padding: 12px 30px; text-decoration: none; border-radius: 5px; display: inline-block;'>Ver mi pedido</a>
                        </p>
                        
                        <p style='margin-top: 30px; color: #666; font-size: 14px;'>
                            Si tienes alguna pregunta sobre tu pedido, no dudes en contactarnos.
                        </p>
                        
                        <p style='margin-top: 20px;'>
                            Saludos,<br/>
                            <strong>El equipo de AutoParts</strong>
                        </p>
                    </div>
                </body>
                </html>";

            return EnviarEmail(email, $"Confirmación de pedido #{idPedido} - AutoParts", cuerpo);
        }
    }
}

