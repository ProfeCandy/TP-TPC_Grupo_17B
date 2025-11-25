using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.Dashboard_client
{
    public partial class Dash_client : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Dominio.Usuario user = (Dominio.Usuario)Session["usuario"];
                litUserName.Text = user.Nombre;

                if (!string.IsNullOrEmpty(user.UrlFotoPerfil))
                {
                    imgFotoPerfilSidebar.ImageUrl = ResolveUrl(user.UrlFotoPerfil) + "?t=" + DateTime.Now.Ticks;
                    imgFotoPerfilSidebar.Visible = true;
                }
                else
                {
                    imgFotoPerfilSidebar.Visible = false;
                }
            }
            else
            {
                litUserName.Text = "Usuario";
                imgFotoPerfilSidebar.Visible = false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Inicio.aspx", false);
        }
    }
}