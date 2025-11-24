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

            if (Session["error"] != null)
            {
                MostrarMensaje(Session["error"].ToString(), true);
                Session.Remove("error");
            }
            else if (Session["success"] != null)
            {
                MostrarMensaje(Session["success"].ToString(), false);
                Session.Remove("success");
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

                string imagenBase64 = hiddenImagenRecortada.Value;
                if (!string.IsNullOrEmpty(imagenBase64) && imagenBase64.StartsWith("data:image"))
                {
                    try
                    {
                        string urlFoto = GuardarFotoPerfilDesdeBase64(imagenBase64, user.IdUsuario);
                        if (!string.IsNullOrEmpty(urlFoto))
                        {
                            if (!string.IsNullOrEmpty(user.UrlFotoPerfil))
                            {
                                EliminarFotoAnterior(user.UrlFotoPerfil);
                            }
                            user.UrlFotoPerfil = urlFoto;
                        }
                    }
                    catch (Exception exFoto)
                    {
                        MostrarMensaje(exFoto.Message, true);
                    }
                }
                else if (fileFotoPerfil.HasFile)
                {
                    try
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
                    catch (Exception exFoto)
                    {
                        MostrarMensaje(exFoto.Message, true);
                    }
                }

                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Modificar(user);

                Usuario usuarioActualizado = negocio.BuscarUsuarioPorId(user.IdUsuario);
                Session["usuario"] = usuarioActualizado;

                CargarFotoPerfil(usuarioActualizado);
                MostrarMensaje("¡Perfil actualizado correctamente!", false);
                
                hiddenImagenRecortada.Value = "";
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar: " + ex.Message, true);
            }
        }

        private void CargarFotoPerfil(Usuario user)
        {
            if (!string.IsNullOrEmpty(user.UrlFotoPerfil))
            {
                string url = ResolveUrl(user.UrlFotoPerfil);
                imgFotoPerfil.ImageUrl = url + "?t=" + DateTime.Now.Ticks;
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
                if (!fileUpload.HasFile)
                {
                    return null;
                }

                string extension = Path.GetExtension(fileUpload.FileName).ToLower();
                string[] extensionesPermitidas = { ".jpg", ".jpeg", ".png", ".gif" };

                if (!extensionesPermitidas.Contains(extension))
                {
                    throw new Exception("Formato de imagen no válido. Use JPG, PNG o GIF.");
                }

                if (fileUpload.PostedFile.ContentLength > 2 * 1024 * 1024)
                {
                    throw new Exception("La imagen es demasiado grande. Tamaño máximo: 2MB.");
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
                            throw new Exception($"Las dimensiones de la imagen son demasiado grandes. Máximo: {anchoMaximo}x{altoMaximo}px. Tu imagen: {img.Width}x{img.Height}px");
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
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la foto de perfil: " + ex.Message);
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

        private string GuardarFotoPerfilDesdeBase64(string base64String, int idUsuario)
        {
            try
            {
                string base64Data = base64String.Contains(",") ? base64String.Split(',')[1] : base64String;
                byte[] imagenBytes = Convert.FromBase64String(base64Data);

                if (imagenBytes.Length > 2 * 1024 * 1024)
                {
                    throw new Exception("La imagen es demasiado grande. Tamaño máximo: 2MB.");
                }

                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(ms))
                    {
                    }
                }

                string carpetaImagenes = Server.MapPath("~/assets/img/perfiles/");
                if (!Directory.Exists(carpetaImagenes))
                {
                    Directory.CreateDirectory(carpetaImagenes);
                }

                string nombreArchivo = $"perfil_{idUsuario}_{DateTime.Now.Ticks}.jpg";
                string rutaCompleta = Path.Combine(carpetaImagenes, nombreArchivo);

                File.WriteAllBytes(rutaCompleta, imagenBytes);

                return $"~/assets/img/perfiles/{nombreArchivo}";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la foto de perfil: " + ex.Message);
            }
        }

        private void MostrarMensaje(string mensaje, bool esError)
        {
            panelMensaje.Visible = true;
            lblMensaje.Text = mensaje;
            
            if (esError)
                panelMensaje.CssClass = "alert alert-danger mb-4";
            else
                panelMensaje.CssClass = "alert alert-success mb-4";
        }
    }
}