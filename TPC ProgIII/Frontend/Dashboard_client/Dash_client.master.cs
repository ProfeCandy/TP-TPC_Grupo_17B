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
            // --- DATOS PLACEHOLDER ---
            litUserName.Text = "Usuario de Prueba";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
        }
    }
}