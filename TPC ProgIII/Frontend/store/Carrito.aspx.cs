using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPC_ProgIII;

namespace Frontend.store
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }
        private void CargarCarrito()
        {
            Dominio.Carrito carrito = CarritoManager.ObtenerCarrito(Session);

            // Validamos si tiene items para mostrar u ocultar paneles
            if (carrito != null && carrito.Items.Count > 0)
            {
                pnlCarritoConItems.Visible = true;
                pnlCarritoVacio.Visible = false;

                // obtiene listado DTO 
                CarritoNegocio negocio = new CarritoNegocio();
                var listaDto = negocio.ObtenerListadoDTO(carrito);

                repCarrito.DataSource = listaDto;
                repCarrito.DataBind();

                // Calcula Total (dinera)
                decimal total = negocio.CalcularTotal(carrito);

                // Cantidad de Items
                int cantidadItems = CarritoManager.ObtenerCantidadItems(Session);

                lblCantidadItems.Text = cantidadItems.ToString();
                lblTotalHeader.Text = total.ToString("N2");
                lblSubTotal.Text = total.ToString("N2");
                lblTotalGeneral.Text = total.ToString("N2");
            }
            else
            {
                pnlCarritoConItems.Visible = false;
                pnlCarritoVacio.Visible = true;
            }
        }
        protected void RepeaterCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);

                switch (e.CommandName)
                {
                    case "eliminar":
                        CarritoManager.Eliminar(idProducto, Session);
                        break;

                    case "sumar":
                        string mensaje = CarritoManager.Agregar(idProducto, 1, Session);
                        if (mensaje.Contains("Error"))
                            panelMensajes.CssClass = "alert alert-danger";
                        else
                        {
                            panelMensajes.CssClass = "alert alert-success";
                            if (this.Master is SiteMaster master)
                            {
                                master.ActualizarContadorCarrito();
                            }
                        }
                        break;

                    case "restar":
                        CarritoManager.Restar(idProducto, Session);
                        break;
                }

                CargarCarrito();
            }
            catch (Exception ex)
            {
                Session["Error"] = "Ocurrió un error al actualizar el carrito: " + ex.Message;
            }
        }
        protected void btnIniciarCompra_Click(object sender, EventArgs e)
        {
            if (Session["carrito"] != null && ((Dominio.Carrito)Session["carrito"]).Items.Count > 0)
            {
                Response.Redirect("~/Checkout/Checkout.aspx");
            }
        }
    }
}