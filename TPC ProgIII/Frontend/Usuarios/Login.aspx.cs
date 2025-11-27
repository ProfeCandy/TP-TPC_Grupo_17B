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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/Inicio.aspx");
            }

            string mensaje = Request.QueryString["mensaje"];
            if (mensaje == "passwordRestablecida")
            {
                panelError.Visible = true;
                panelError.CssClass = "alert alert-success";
                lblError.Text = "Tu contraseña ha sido restablecida exitosamente. Ya podés iniciar sesión.";
            }
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Clave = txtPassword.Text;

                if (negocio.Loguear(usuario))
                {
                    // Verificar si el email está confirmado
                    if (!usuario.EmailConfirmado)
                    {
                        panelError.Visible = true;
                        lblError.Text = $"Tu cuenta no ha sido confirmada. Por favor, revisa tu email y haz clic en el enlace de confirmaci&oacute;n.<br/>Si no recibiste el email, puedes <a href='~/Usuarios/ConfirmarEmail.aspx?email={Server.UrlEncode(usuario.Email)}' class='alert-link'>solicitar uno nuevo</a>.";
                        return;
                    }

                    // Verificar si el usuario está activo
                    if (!usuario.Activo)
                    {
                        panelError.Visible = true;
                        lblError.Text = "Tu cuenta ha sido desactivada. Contacta al administrador.";
                        return;
                    }

                    Session.Add("usuario", usuario);
                    Response.Redirect("~/Inicio.aspx", false);
                }
                else
                {
                    panelError.Visible = true;
                    lblError.Text = "Usuario o contraseña incorrectos.";
                }
            }
            catch (Exception ex)
            {
                panelError.Visible = true;
                lblError.Text = "Error al intentar ingresar. Intente más tarde.";
                throw ex;
            }
        }
    }
}