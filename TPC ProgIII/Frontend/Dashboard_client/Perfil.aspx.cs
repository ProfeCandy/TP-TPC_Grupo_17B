using System;
using System.Web.UI;
using Dominio;
using Negocio;
using System.IO;
using System.Drawing;
using System.Linq;


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

                CargarFotoPerfil(usuarioActual);
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

                if (fileFotoPerfil.HasFile)
                {
                    string urlFoto = GuardarFotoPerfil(fileFotoPerfil, usuarioAEditar.IdUsuario);
                    if (!string.IsNullOrEmpty(urlFoto))
                    {
                        if (!string.IsNullOrEmpty(usuarioAEditar.UrlFotoPerfil))
                        {
                            EliminarFotoAnterior(usuarioAEditar.UrlFotoPerfil);
                        }
                        usuarioAEditar.UrlFotoPerfil = urlFoto;
                    }
                }

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

        private void CargarFotoPerfil(Usuario user)
        {
            if (!string.IsNullOrEmpty(user.UrlFotoPerfil))
            {
                imgFotoPerfil.ImageUrl = ResolveUrl(user.UrlFotoPerfil);
            }
            else
            {
                imgFotoPerfil.ImageUrl = ResolveUrl("~/assets/images/icons/profile-icon.png");
            }
        }

        private string GuardarFotoPerfil(System.Web.UI.WebControls.FileUpload fileUpload, int idUsuario)
        {
            try
            {
                string extension = Path.GetExtension(fileUpload.FileName).ToLower();
                string[] extensionesPermitidas = { ".jpg", ".jpeg", ".png", ".gif" };

                if (!extensionesPermitidas.Contains(extension))
                {
                    return null;
                }

                if (fileUpload.PostedFile.ContentLength > 2 * 1024 * 1024)
                {
                    return null;
                }

                byte[] imagenBytes = new byte[fileUpload.PostedFile.ContentLength];
                fileUpload.PostedFile.InputStream.Read(imagenBytes, 0, imagenBytes.Length);

                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(ms))
                    {
                        int anchoMaximo = 1000;
                        int altoMaximo = 1000;

                        if (img.Width > anchoMaximo || img.Height > altoMaximo)
                        {
                            return null;
                        }
                    }
                }

                string carpetaImagenes = Server.MapPath("~/assets/img/perfiles/");
                if (!Directory.Exists(carpetaImagenes))
                {
                    Directory.CreateDirectory(carpetaImagenes);
                }

                string nombreArchivo = $"perfil_{idUsuario}_{DateTime.Now.Ticks}{extension}";
                string rutaCompleta = Path.Combine(carpetaImagenes, nombreArchivo);

                File.WriteAllBytes(rutaCompleta, imagenBytes);

                return $"~/assets/img/perfiles/{nombreArchivo}";
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void EliminarFotoAnterior(string urlFoto)
        {
            try
            {
                if (!string.IsNullOrEmpty(urlFoto))
                {
                    string rutaFisica = Server.MapPath(urlFoto);
                    if (File.Exists(rutaFisica))
                    {
                        File.Delete(rutaFisica);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}