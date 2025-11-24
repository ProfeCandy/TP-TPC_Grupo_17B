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
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuarios/Login.aspx");
        }
    }
}