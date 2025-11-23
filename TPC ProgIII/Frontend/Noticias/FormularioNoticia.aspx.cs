using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using Dominio;
using Negocio;

namespace Frontend
{
    public partial class FormularioNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario es administrador
            if (Session["usuario"] == null || !EsAdmin())
            {
                Response.Redirect("Noticias.aspx");
                return;
            }

            if (!IsPostBack)
            {
                // Si viene un ID en la URL, cargar los datos de la noticia
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int idNoticia = int.Parse(Request.QueryString["id"]);
                    lblTituloPagina.Text = "Editar Noticia";
                    CargarNoticia(idNoticia);
                }
                else
                {
                    lblTituloPagina.Text = "Crear Noticia";
                }
            }
        }

        private void CargarNoticia(int id)
        {
            try
            {
                NoticiaNegocio negocio = new NoticiaNegocio();
                Noticia noticia = negocio.ObtenerPorId(id);

                if (noticia != null)
                {
                    txtTitulo.Text = noticia.Titulo;
                    txtCategoria.Text = noticia.Categoria ?? "";
                    txtCuerpo.Text = noticia.Cuerpo;
                    
                    // Cargar imagen principal si existe
                    if (noticia.Imagenes != null && noticia.Imagenes.Count > 0)
                    {
                        string imagenUrl = noticia.Imagenes[0].UrlImagen;
                        imgActual.ImageUrl = imagenUrl;
                        pnlImagenActual.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar la noticia: " + ex.Message, true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTitulo.Text) || string.IsNullOrEmpty(txtCuerpo.Text))
                {
                    MostrarMensaje("El t&iacute;tulo y el cuerpo son obligatorios.", true);
                    return;
                }

                Noticia noticia = new Noticia();
                noticia.Titulo = txtTitulo.Text;
                noticia.Categoria = txtCategoria.Text;
                noticia.Cuerpo = txtCuerpo.Text;
                noticia.FechaPublicacion = DateTime.Now;
                noticia.Activa = true;

                NoticiaNegocio negocio = new NoticiaNegocio();
                NoticiaImagenNegocio imagenNegocio = new NoticiaImagenNegocio();

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    // Editar noticia existente
                    noticia.IdNoticia = int.Parse(Request.QueryString["id"]);
                    negocio.Modificar(noticia);
                    
                    // Eliminar imágenes anteriores
                    imagenNegocio.EliminarPorNoticia(noticia.IdNoticia);
                    
                    MostrarMensaje("Noticia actualizada correctamente.", false);
                }
                else
                {
                    // Crear nueva noticia
                    int idNoticiaCreada = negocio.Agregar(noticia);
                    noticia.IdNoticia = idNoticiaCreada;
                    
                    MostrarMensaje("Noticia creada correctamente.", false);
                }

                // Guardar la imagen si se subió un archivo
                if (fileImagen.HasFile)
                {
                    string nombreArchivo = GuardarImagen(fileImagen, noticia.IdNoticia);
                    if (!string.IsNullOrEmpty(nombreArchivo))
                    {
                        NoticiaImagen imagen = new NoticiaImagen();
                        imagen.IdNoticia = noticia.IdNoticia;
                        imagen.UrlImagen = nombreArchivo;
                        imagen.Orden = 0;
                        imagen.FechaSubida = DateTime.Now;
                        imagenNegocio.Agregar(imagen);
                    }
                }

                // Redirigir a la lista de noticias despu&eacute;s de 2 segundos
                Response.AddHeader("Refresh", "2;url=Noticias.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar: " + ex.Message, true);
            }
        }

        private string GuardarImagen(FileUpload fileUpload, int idNoticia)
        {
            try
            {
                // Validar extensión
                string extension = Path.GetExtension(fileUpload.FileName).ToLower();
                string[] extensionesPermitidas = { ".jpg", ".jpeg", ".png", ".gif" };
                
                if (!extensionesPermitidas.Contains(extension))
                {
                    MostrarMensaje("Formato de imagen no v&aacute;lido. Use JPG, PNG o GIF.", true);
                    return null;
                }

                // Validar tamaño de archivo (2MB máximo)
                if (fileUpload.PostedFile.ContentLength > 2 * 1024 * 1024)
                {
                    MostrarMensaje("La imagen es demasiado grande. M&aacute;ximo 2MB.", true);
                    return null;
                }

                // Validar dimensiones de la imagen
                // Leer el contenido en memoria para no consumir el stream
                byte[] imagenBytes = new byte[fileUpload.PostedFile.ContentLength];
                fileUpload.PostedFile.InputStream.Read(imagenBytes, 0, imagenBytes.Length);
                
                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(ms))
                    {
                        int anchoMaximo = 1920; // Full HD width
                        int altoMaximo = 1080;  // Full HD height

                        if (img.Width > anchoMaximo || img.Height > altoMaximo)
                        {
                            MostrarMensaje($"Las dimensiones de la imagen son demasiado grandes. M&aacute;ximo: {anchoMaximo}x{altoMaximo}px. Tu imagen: {img.Width}x{img.Height}px", true);
                            return null;
                        }
                    }
                }

                // Crear carpeta si no existe
                string carpetaImagenes = Server.MapPath("~/assets/img/noticias/");
                if (!Directory.Exists(carpetaImagenes))
                {
                    Directory.CreateDirectory(carpetaImagenes);
                }

                // Generar nombre único
                string nombreArchivo = $"noticia_{idNoticia}_{DateTime.Now.Ticks}{extension}";
                string rutaCompleta = Path.Combine(carpetaImagenes, nombreArchivo);

                // Guardar archivo desde los bytes leídos
                File.WriteAllBytes(rutaCompleta, imagenBytes);

                // Retornar ruta relativa para guardar en BD
                return $"~/assets/img/noticias/{nombreArchivo}";
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar la imagen: " + ex.Message, true);
                return null;
            }
        }

        private void MostrarMensaje(string mensaje, bool esError)
        {
            panelMensaje.Visible = true;
            lblMensaje.Text = mensaje;
            
            if (esError)
                panelMensaje.CssClass = "alert alert-danger";
            else
                panelMensaje.CssClass = "alert alert-success";
        }

        private bool EsAdmin()
        {
            if (Session["usuario"] != null)
            {
                Usuario user = (Usuario)Session["usuario"];
                if (user.Rol != null && user.Rol.NombreRol.ToLower() == "administrador")
                    return true;
            }
            return false;
        }
    }
}

