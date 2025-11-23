using System;
using System.Web.UI;
using Dominio;
using Negocio;


namespace Frontend.Dashboard_client
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                CargarDatosEnPantalla();
            }
        }

        private void CargarDatosEnPantalla()
        {
            Usuario usuarioSesion = (Usuario)Session["usuario"];
            UsuarioNegocio negocio = new UsuarioNegocio();
 
            Usuario usuarioActual = negocio.BuscarUsuarioPorId(usuarioSesion.IdUsuario);

            if (usuarioActual != null)
            {
                txtNombre.Text = usuarioActual.Nombre;
                txtApellido.Text = usuarioActual.Apellido;
                txtEmail.Text = usuarioActual.Email;
                txtTelefono.Text = usuarioActual.Telefono;
                txtDireccion.Text = usuarioActual.Direccion;
                txtLocalidad.Text = usuarioActual.Localidad;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                // Obtenemos el usuario de la sesión para tener el ID
                Usuario usuarioSesion = (Usuario)Session["usuario"];

                // objeto completo de la BD.
                Usuario usuarioAEditar = negocio.BuscarUsuarioPorId(usuarioSesion.IdUsuario);

                usuarioAEditar.Nombre = txtNombre.Text;
                usuarioAEditar.Apellido = txtApellido.Text;
                usuarioAEditar.Email = txtEmail.Text;
                usuarioAEditar.Telefono = txtTelefono.Text;
                usuarioAEditar.Direccion = txtDireccion.Text;
                usuarioAEditar.Localidad = txtLocalidad.Text;

                // Guardo en BD
                negocio.Modificar(usuarioAEditar);

                //Actualizo sesión
                Session["usuario"] = usuarioAEditar;

                //Msj success
                lblMensaje.Text = "¡Perfil actualizado correctamente!";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Visible = true;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al guardar: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
        }
    }
}