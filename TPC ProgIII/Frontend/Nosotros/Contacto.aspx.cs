using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class Contacto : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRedesSociales();
            }
        }

        private void CargarRedesSociales()
        {
            try
            {
                // Cargar URLs desde Web.config
                string facebookUrl = ConfigurationManager.AppSettings["FacebookUrl"] ?? "#";
                string instagramUrl = ConfigurationManager.AppSettings["InstagramUrl"] ?? "#";
                string whatsAppUrl = ConfigurationManager.AppSettings["WhatsAppUrl"] ?? "#";
                string linkedInUrl = ConfigurationManager.AppSettings["LinkedInUrl"] ?? "#";

                System.Web.UI.HtmlControls.HtmlAnchor lnkFacebookContacto = FindControl("lnkFacebookContacto") as System.Web.UI.HtmlControls.HtmlAnchor;
                System.Web.UI.HtmlControls.HtmlAnchor lnkInstagramContacto = FindControl("lnkInstagramContacto") as System.Web.UI.HtmlControls.HtmlAnchor;
                System.Web.UI.HtmlControls.HtmlAnchor lnkWhatsAppContacto = FindControl("lnkWhatsAppContacto") as System.Web.UI.HtmlControls.HtmlAnchor;
                System.Web.UI.HtmlControls.HtmlAnchor lnkLinkedInContacto = FindControl("lnkLinkedInContacto") as System.Web.UI.HtmlControls.HtmlAnchor;

                if (lnkFacebookContacto != null) lnkFacebookContacto.HRef = facebookUrl;
                if (lnkInstagramContacto != null) lnkInstagramContacto.HRef = instagramUrl;
                if (lnkWhatsAppContacto != null) lnkWhatsAppContacto.HRef = whatsAppUrl;
                if (lnkLinkedInContacto != null) lnkLinkedInContacto.HRef = linkedInUrl;
            }
            catch (Exception)
            {
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            // Logic for sending email will go here
        }
    }
}

