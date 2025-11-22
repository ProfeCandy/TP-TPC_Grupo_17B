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
            Noticia noticia = negocio.ObtenerPorId(id);

            if (noticia != null)
            {
                lblTitulo.Text = noticia.Titulo;
                lblCuerpo.Text = noticia.Cuerpo; // Si tienes HTML en la DB, podrías necesitar decodificarlo
                lblFecha.Text = noticia.FechaPublicacion.ToString("dd 'de' MMMM 'de' yyyy");
                lblCategoria.Text = noticia.Categoria ?? "General";

                if (!string.IsNullOrEmpty(noticia.ImagenUrl))
                {
                    imgNoticia.ImageUrl = noticia.ImagenUrl;
                    imgNoticia.Visible = true;
                }
            }
            else
            {
                // Si no encuentra la noticia, vuelve al listado
                Response.Redirect("Noticias.aspx");
            }
        }
    }
}

