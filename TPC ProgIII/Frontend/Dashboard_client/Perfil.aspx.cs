using System;
using System.Web.UI;
using Dominio;

namespace Frontend.Dashboard_client
{
    public partial class Perfil : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // --- PLACEHOLDER ---
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
        }
    }
}