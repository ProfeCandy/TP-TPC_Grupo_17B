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
                Response.Redirect("Inicio.aspx");
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

                // Configuración por defecto para nuevos usuarios
                user.Activo = true;
                user.Rol = new Rol();
                user.Rol.IdRol = 1; 

                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Agregar(user);
                negocio.Loguear(user);

                // Como ya sabemos que los datos son válidos, lo metemos en sesión directamente
                Session.Add("usuario", user);

                Response.Redirect("Inicio.aspx", false);

            }
            catch (Exception ex)
            {
                panelError.Visible = true;
                lblError.Text = "Hubo un error al registrarse. Intente nuevamente.";
                throw ex;
            }
        }
    }
}