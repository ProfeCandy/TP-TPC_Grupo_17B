using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

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

                CargarFotoPerfil(user);
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

                if (fileFotoPerfil.HasFile)
                {
                    string urlFoto = GuardarFotoPerfil(fileFotoPerfil, user.IdUsuario);
                    if (!string.IsNullOrEmpty(urlFoto))
                    {
                        if (!string.IsNullOrEmpty(user.UrlFotoPerfil))
                        {
                            EliminarFotoAnterior(user.UrlFotoPerfil);
                        }
                        user.UrlFotoPerfil = urlFoto;
                    }
                }

                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Modificar(user);

                Session.Add("usuario", user);

                Response.Redirect("Inicio.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
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

        private string GuardarFotoPerfil(FileUpload fileUpload, int idUsuario)
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