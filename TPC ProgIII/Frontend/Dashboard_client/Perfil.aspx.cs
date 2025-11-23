using System;
using System.Web.UI;
using Dominio;
using Negocio; // Asegúrate de tener este using

namespace Frontend.Dashboard_client
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Validar sesión
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            // 2. Cargar datos solo la primera vez (no en postbacks)
            if (!IsPostBack)
            {
                CargarDatosEnPantalla();
            }
        }

        private void CargarDatosEnPantalla()
        {
            Usuario usuarioSesion = (Usuario)Session["usuario"];
            UsuarioNegocio negocio = new UsuarioNegocio();

            // Traemos el usuario actualizado desde la BD por si hubo cambios externos
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

                // 1. IMPORTANTE: Traemos el objeto completo de la BD.
                // Esto evita que sobrescribamos la Contraseña o el Rol con nulos.
                Usuario usuarioAEditar = negocio.BuscarUsuarioPorId(usuarioSesion.IdUsuario);

                // Actualizo SOLO los campos editables
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