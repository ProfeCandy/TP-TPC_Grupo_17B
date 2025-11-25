using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_ProgIII
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMenuCategorias();
                CargarRedesSociales();
            }

            ActualizarEstadoUsuario();
            ActualizarContadorCarrito();
        }
        private void ActualizarEstadoUsuario()
        {
            if (Session["usuario"] != null)
            {
                Usuario user = (Usuario)Session["usuario"];
                lblUser.Text = user.Nombre;

                if (!string.IsNullOrEmpty(user.UrlFotoPerfil))
                {
                    imgFotoPerfilNavbar.ImageUrl = ResolveUrl(user.UrlFotoPerfil) + "?t=" + DateTime.Now.Ticks;
                }
                else
                {
                    imgFotoPerfilNavbar.ImageUrl = ResolveUrl("~/assets/images/icons/profile-icon.png");
                }

                pnlLogueado.Visible = true; 
                pnlNoLogueado.Visible = false;
                
                PlaceHolder pnlAdmin = (PlaceHolder)pnlLogueado.FindControl("pnlAdmin");
                if (pnlAdmin != null)
                {
                    if (user.Rol != null && user.Rol.NombreRol.ToLower() == "administrador")
                    {
                        pnlAdmin.Visible = true;
                    }
                    else
                    {
                        pnlAdmin.Visible = false;
                    }
                }
            }
            else
            {
                lblUser.Text = "Cuenta";
                imgFotoPerfilNavbar.ImageUrl = ResolveUrl("~/assets/images/icons/profile-icon.png");

                pnlLogueado.Visible = false;  
                pnlNoLogueado.Visible = true; 
            }
            if (Session["carrito"] != null)
                lblCantidadCarrito.Text = "1";
            else
                lblCantidadCarrito.Text = "0";
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Inicio.aspx", false);
        }
        private void CargarMenuCategorias()
        {

            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                
                repCategorias.DataSource = negocio.Listar();
                repCategorias.DataBind();
            }
            catch (Exception)
            {

            }
        }
        private void CargarRedesSociales()
        {
            try
            {
                string facebookUrl = ConfigurationManager.AppSettings["FacebookUrl"] ?? "#";
                string instagramUrl = ConfigurationManager.AppSettings["InstagramUrl"] ?? "#";
                string twitterUrl = ConfigurationManager.AppSettings["TwitterUrl"] ?? "#";
                string linkedInUrl = ConfigurationManager.AppSettings["LinkedInUrl"] ?? "#";

                System.Web.UI.HtmlControls.HtmlAnchor lnkFacebook = FindControl("lnkFacebook") as System.Web.UI.HtmlControls.HtmlAnchor;
                System.Web.UI.HtmlControls.HtmlAnchor lnkInstagram = FindControl("lnkInstagram") as System.Web.UI.HtmlControls.HtmlAnchor;
                System.Web.UI.HtmlControls.HtmlAnchor lnkTwitter = FindControl("lnkTwitter") as System.Web.UI.HtmlControls.HtmlAnchor;
                System.Web.UI.HtmlControls.HtmlAnchor lnkLinkedIn = FindControl("lnkLinkedIn") as System.Web.UI.HtmlControls.HtmlAnchor;

                if (lnkFacebook != null) lnkFacebook.HRef = facebookUrl;
                if (lnkInstagram != null) lnkInstagram.HRef = instagramUrl;
                if (lnkTwitter != null) lnkTwitter.HRef = twitterUrl;
                if (lnkLinkedIn != null) lnkLinkedIn.HRef = linkedInUrl;
            }
            catch (Exception)
            {
            }
        }
        public void ActualizarContadorCarrito()
        {
            if (Session["Carrito"] != null)
            {
                lblCantidadCarrito.Text = CarritoManager.ObtenerCantidadItems(Session).ToString();
            }
            else
            {
                lblCantidadCarrito.Text = "0";
            }
        }
    }
}