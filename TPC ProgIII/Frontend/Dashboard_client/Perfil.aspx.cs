using System;
using System.Web.UI;

namespace Frontend.Dashboard_client
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // --- PLACEHOLDER ---
                litRazonSocial.Text = "Mi Empresa S.A. (Demo)";
                litCuit.Text = "30-12345678-9";
                litEmail.Text = "usuario@demo.com";
                litTelefono.Text = "+54 9 11 1234-5678";
                litDireccion.Text = "Av. Corrientes 1234, CABA";
            }
        }
    }
}