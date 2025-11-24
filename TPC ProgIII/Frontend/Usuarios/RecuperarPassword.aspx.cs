using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            // Logica incompleta, solo muestra mensaje.
            lblMensaje.Visible = true;
            lblMensaje.Text = "Hemos recibido una solicitud para reestablecer tu contraseña, revisá tu bandeja de entrada.";
            lblMensaje.CssClass = "alert alert-success text-center mb-4 d-block";
            txtEmail.Enabled = false;
            btnEnviar.Enabled = false;
        }
    }
}