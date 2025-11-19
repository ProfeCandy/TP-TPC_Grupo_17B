using System;
using System.Collections.Generic;
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
            }
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

    }
}