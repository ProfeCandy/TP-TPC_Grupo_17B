using System;
using System.Web.UI;

namespace Frontend
{
    public partial class Terminos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer la fecha de última actualización
                lblFechaActualizacion.Text = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy");
            }
        }
    }
}

