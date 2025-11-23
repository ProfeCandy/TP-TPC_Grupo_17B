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
                Response.Redirect("Inicio.aspx");
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
                    Session.Add("usuario", usuario);
                    Response.Redirect("Inicio.aspx", false);
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