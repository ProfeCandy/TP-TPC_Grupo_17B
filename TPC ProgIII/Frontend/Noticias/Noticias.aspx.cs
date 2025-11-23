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
    public partial class Noticias : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Mostrar botón de crear noticia solo para admins
                pnlAdminActions.Visible = EsAdmin();
                
                NoticiaNegocio negocio = new NoticiaNegocio();
                NoticiaImagenNegocio imagenNegocio = new NoticiaImagenNegocio();
                
                List<Noticia> listaNoticias = negocio.Listar();
                
                // Cargar imágenes para cada noticia
                foreach (Noticia noticia in listaNoticias)
                {
                    noticia.Imagenes = imagenNegocio.ObtenerPorNoticia(noticia.IdNoticia);
                }
                
                repNoticias.DataSource = listaNoticias;
                repNoticias.DataBind();
            }
        }

        protected void repNoticias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Noticia noticia = (Noticia)e.Item.DataItem;
                Literal litImagen = (Literal)e.Item.FindControl("litImagen");
                
                if (litImagen != null)
                {
                    string imagenUrl = "";
                    
                    if (noticia.Imagenes != null && noticia.Imagenes.Count > 0)
                    {
                        imagenUrl = ResolveUrl(noticia.Imagenes[0].UrlImagen);
                    }
                    
                    if (string.IsNullOrEmpty(imagenUrl))
                    {
                        // Mostrar placeholder si no hay imagen
                        litImagen.Text = @"<div class=""d-flex align-items-center justify-content-center w-100 h-100 text-muted"">
                                            <div class=""text-center"">
                                                <i class=""bi bi-image fs-1""></i>
                                                <p class=""small mb-0 mt-2"">Sin imagen</p>
                                            </div>
                                         </div>";
                    }
                    else
                    {
                        litImagen.Text = $@"<img src=""{imagenUrl}"" class=""w-100 h-100"" style=""object-fit: cover; object-position: center; display: block;"" alt=""{noticia.Titulo}"" />";
                    }
                }
            }
        }

        // Método para verificar si el usuario es Administrador
        public bool EsAdmin()
        {
            if (Session["usuario"] != null)
            {
                Dominio.Usuario user = (Dominio.Usuario)Session["usuario"];
                if (user.Rol != null && user.Rol.NombreRol.ToLower() == "administrador")
                    return true;
            }
            return false;
        }

        // Evento para eliminar la noticia
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int idNoticia = int.Parse(btn.CommandArgument);

            try
            {
                NoticiaNegocio negocio = new NoticiaNegocio();
                negocio.Eliminar(idNoticia);
                
                // Recargamos la página para actualizar la lista
                Response.Redirect("Noticias.aspx", false);
            }
            catch (Exception ex)
            {
                // Puedes mostrar un mensaje de error aquí si lo deseas
                System.Diagnostics.Debug.WriteLine("Error al eliminar noticia: " + ex.Message);
            }
        }
    }
}
