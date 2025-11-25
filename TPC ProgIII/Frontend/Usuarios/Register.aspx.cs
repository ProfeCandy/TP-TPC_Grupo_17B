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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/Inicio.aspx");
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    panelError.Visible = true;
                    lblError.Text = "El email y la contraseña son obligatorios.";
                    return;
                }

                Usuario user = new Usuario();
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Clave = txtPassword.Text;

                user.Activo = true;
                user.Rol = new Rol();
                user.Rol.IdRol = 1; 

                UsuarioNegocio negocio = new UsuarioNegocio();
                
                // Agregar usuario y obtener el IdUsuario generado
                int idUsuario = negocio.Agregar(user);
                
                // Generar token único de confirmación
                string token = Guid.NewGuid().ToString();
                
                // Guardar token en la base de datos
                negocio.GenerarTokenConfirmacion(idUsuario, token);
                
                // Enviar email de confirmación
                EmailServicio emailServicio = new EmailServicio();
                string nombreCompleto = $"{user.Nombre} {user.Apellido}";
                bool emailEnviado = emailServicio.EnviarConfirmacionRegistro(user.Email, nombreCompleto, token);
                
                // Redirigir a página de confirmación (sin hacer login)
                // En modo desarrollo, también pasamos el token para mostrarlo en la página
                string modoDesarrollo = System.Configuration.ConfigurationManager.AppSettings["EmailModoDesarrollo"];
                if (modoDesarrollo == "true")
                {
                    Response.Redirect(ResolveUrl($"~/Usuarios/ConfirmarEmail.aspx?email={Server.UrlEncode(user.Email)}&token={Server.UrlEncode(token)}&modoDev=true"), false);
                }
                else
                {
                    Response.Redirect(ResolveUrl($"~/Usuarios/ConfirmarEmail.aspx?email={Server.UrlEncode(user.Email)}"), false);
                }
            }
            catch (Exception ex)
            {
                panelError.Visible = true;
                
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += " " + ex.InnerException.Message;
                }
                
                if (errorMessage.Contains("UNIQUE KEY constraint") && errorMessage.Contains("UQ_Usuario_Email") || 
                    errorMessage.Contains("duplicate key") || 
                    errorMessage.Contains("ya existe"))
                {
                    lblError.Text = "El correo electrónico ingresado ya está registrado. Por favor, utiliza otro correo o inicia sesión.";
                }
                else
                {
                    lblError.Text = $"Hubo un error al registrarse: {ex.Message}";
                }
            }
        }
    }
}