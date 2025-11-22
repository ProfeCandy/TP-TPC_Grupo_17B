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
                NoticiaNegocio negocio = new NoticiaNegocio();
                repNoticias.DataSource = negocio.Listar();
                repNoticias.DataBind();
            }
        }
    }
}
