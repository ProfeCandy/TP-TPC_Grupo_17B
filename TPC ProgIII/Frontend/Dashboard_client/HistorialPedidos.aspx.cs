using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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

            repPedidos.ItemDataBound += repPedidos_ItemDataBound;
            repPedidos.ItemCommand += repPedidos_ItemCommand;

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
        protected void repPedidos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // es admin?
            Usuario user = (Usuario)Session["usuario"];
            bool esAdmin = user != null && user.Rol != null && user.Rol.NombreRol.ToLower() == "administrador";

            // configura th
            if (e.Item.ItemType == ListItemType.Header)
            {
                // muestra columna "Cliente" solo a admins
                HtmlTableCell thCliente = (HtmlTableCell)e.Item.FindControl("thCliente");
                if (thCliente != null) thCliente.Visible = esAdmin;
            }

            // Configura td
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Columna Cliente (solo para admin)
                HtmlTableCell tdCliente = (HtmlTableCell)e.Item.FindControl("tdCliente");
                if (tdCliente != null) tdCliente.Visible = esAdmin;

                // ESTADO (Dropdown vs Badge)
                PlaceHolder phUser = (PlaceHolder)e.Item.FindControl("phEstadoUsuario");
                PlaceHolder phAdmin = (PlaceHolder)e.Item.FindControl("phEstadoAdmin");

                if (esAdmin)
                {
                    // admin: ve DropDown y botón Guardar
                    if (phUser != null) phUser.Visible = false;
                    if (phAdmin != null) phAdmin.Visible = true;

                    // muestra valor actual en el DropDown
                    DropDownList ddl = (DropDownList)e.Item.FindControl("ddlEstado");
                    HiddenField hf = (HiddenField)e.Item.FindControl("hfEstadoActual");

                    if (ddl != null && hf != null && !string.IsNullOrEmpty(hf.Value))
                    {
                        ListItem item = ddl.Items.FindByValue(hf.Value);
                        if (item != null)
                        {
                            item.Selected = true;
                        }
                    }
                }
                else
                {
                    // user: ve solo badge de color
                    if (phUser != null) phUser.Visible = true;
                    if (phAdmin != null) phAdmin.Visible = false;
                }
            }
        }
        protected void repPedidos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "guardarCambioEstado")
            {
                try
                {
                    // id del Pedido
                    int idPedido = Convert.ToInt32(e.CommandArgument);

                    // Buscar DropDownList donde se hizo click
                    DropDownList ddl = (DropDownList)e.Item.FindControl("ddlEstado");

                    if (ddl != null)
                    {
                        string nuevoEstado = ddl.SelectedValue;

                        // actualizar bd
                        PedidoNegocio negocio = new PedidoNegocio();
                        negocio.ActualizarEstadoPedido(idPedido, nuevoEstado);

                        // recargar tabla
                        CargarPedidos();
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
}