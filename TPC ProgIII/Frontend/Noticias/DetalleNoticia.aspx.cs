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
    public partial class DetalleNoticia : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    CargarDetalle(id);
                }
                else
                {
                    Response.Redirect("Noticias.aspx");
                }
            }
        }

        private void CargarDetalle(int id)
        {
            NoticiaNegocio negocio = new NoticiaNegocio();
            NoticiaImagenNegocio imagenNegocio = new NoticiaImagenNegocio();
            Noticia noticia = negocio.ObtenerPorId(id);

            if (noticia != null)
            {
                lblTitulo.Text = noticia.Titulo;
                lblCuerpo.Text = noticia.Cuerpo; // Si tienes HTML en la DB, podrías necesitar decodificarlo
                lblFecha.Text = noticia.FechaPublicacion.ToString("dd 'de' MMMM 'de' yyyy");
                lblCategoria.Text = noticia.Categoria ?? "General";

                noticia.Imagenes = imagenNegocio.ObtenerPorNoticia(noticia.IdNoticia);
                if (noticia.Imagenes != null && noticia.Imagenes.Count > 0)
                {
                    string imagenUrl = noticia.Imagenes[0].UrlImagen;
                    if (!string.IsNullOrEmpty(imagenUrl))
                    {
                        imgNoticia.ImageUrl = ResolveUrl(imagenUrl);
                        imgNoticia.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("Noticias.aspx");
            }
        }
    }
}

