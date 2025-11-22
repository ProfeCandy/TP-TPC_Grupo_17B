using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["usuario"];

                txtEmail.Text = user.Email;
                txtNombre.Text = user.Nombre;
                txtApellido.Text = user.Apellido;
                txtTelefono.Text = user.Telefono;
                txtDireccion.Text = user.Direccion;
                txtLocalidad.Text = user.Localidad;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = (Usuario)Session["usuario"];

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Telefono = txtTelefono.Text;
                user.Direccion = txtDireccion.Text;
                user.Localidad = txtLocalidad.Text;


                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Modificar(user);

                Session.Add("usuario", user);

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}