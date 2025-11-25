using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.Dashboard_client
{
    public partial class HistorialPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("../Usuarios/Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarPedidos();
            }
        }

        private void CargarPedidos()
        {
            try
            {
                Usuario user = (Usuario)Session["usuario"];

                PedidoNegocio negocio = new PedidoNegocio();
                List<Pedido> lista = negocio.ListarPorUsuario(user.IdUsuario);

                if (lista.Count > 0)
                {
                    repPedidos.DataSource = lista;
                    repPedidos.DataBind();
                }
                else
                {
                    pnlSinPedidos.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../Error.aspx");
            }
        }
    }
}