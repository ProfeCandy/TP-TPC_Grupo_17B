using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class RestablecerPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aca validaria un token de restablecimiento
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            // Logica incompleta, aca iria la actualizacion de la clave en la base de datos.
            Response.Redirect("~/Usuarios/Login.aspx");
        }
    }
}