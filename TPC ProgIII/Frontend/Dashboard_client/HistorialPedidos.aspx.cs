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

            Usuario user = (Usuario)Session["usuario"];
            bool esAdmin = user.Rol != null && user.Rol.NombreRol.ToLower() == "administrador";

            if (esAdmin)
            {
                lblTitulo.Text = "Todos los Pedidos";
                pnlFiltroAdmin.Visible = true;
            }
            else
            {
                lblTitulo.Text = "Mis Compras";
                pnlFiltroAdmin.Visible = false;
            }

            if (!IsPostBack)
            {
                repPedidos.ItemCreated += repPedidos_ItemCreated;
                CargarPedidos();
            }
        }
        private void CargarPedidos()
        {
            try
            {
                Usuario user = (Usuario)Session["usuario"];
                bool esAdmin = user.Rol != null && user.Rol.NombreRol.ToLower() == "administrador";

                PedidoNegocio negocio = new PedidoNegocio();
                List<Pedido> lista;

                if (esAdmin)
                {
                    // Filtro por email
                    if (!string.IsNullOrWhiteSpace(txtFiltroEmail.Text))
                    {
                        lista = negocio.ListarPorEmail(txtFiltroEmail.Text.Trim());
                    }
                    else
                    {
                        // Mostrar todos los pedidos
                        lista = negocio.ListarTodos();
                    }
                }
                else
                {
                    // Usuario normal: solo sus pedidos
                    lista = negocio.ListarPorUsuario(user.IdUsuario);
                }

                if (lista.Count > 0)
                {
                    pnlTablaPedidos.Visible = true;
                    pnlSinPedidos.Visible = false;
                    repPedidos.DataSource = lista;
                    repPedidos.DataBind();
                }
                else
                {
                    pnlTablaPedidos.Visible = false;
                    pnlSinPedidos.Visible = true;
                    if (esAdmin && !string.IsNullOrWhiteSpace(txtFiltroEmail.Text))
                    {
                        lblMensajeSinPedidos.Text = $"No se encontraron pedidos para el email: {txtFiltroEmail.Text}";
                        pnlBotonCatalogo.Visible = false;
                    }
                    else if (esAdmin)
                    {
                        lblMensajeSinPedidos.Text = "No hay pedidos registrados.";
                        pnlBotonCatalogo.Visible = false;
                    }
                    else
                    {
                        lblMensajeSinPedidos.Text = "No tenés compras realizadas aún.";
                        pnlBotonCatalogo.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../Error.aspx");
            }
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarPedidos();
        }
        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltroEmail.Text = "";
            CargarPedidos();
        }
        protected void repPedidos_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            bool esAdmin = user != null && user.Rol != null && user.Rol.NombreRol.ToLower() == "administrador";

            if (e.Item.ItemType == ListItemType.Header)
            {
                PlaceHolder phColumnaCliente = (PlaceHolder)e.Item.FindControl("phColumnaCliente");
                if (phColumnaCliente != null)
                {
                    phColumnaCliente.Visible = esAdmin;
                }
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Web.UI.HtmlControls.HtmlTableCell tdCliente = (System.Web.UI.HtmlControls.HtmlTableCell)e.Item.FindControl("tdCliente");
                if (tdCliente != null)
                {
                    tdCliente.Visible = esAdmin;
                }
            }
        }
    }
}