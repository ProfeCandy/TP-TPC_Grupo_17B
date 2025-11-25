using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.store
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //si cliente no tiene carrito, crea uno nuevo en session, ¡vacío!" --> evita NullReferenceException
                if (Session["Carrito"] == null)
                {
                    Session["Carrito"] = new Dominio.Carrito();
                }
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            // traer carrito de session
            Dominio.Carrito carrito = (Dominio.Carrito)Session["Carrito"];

            if (carrito != null && carrito.Items.Count > 0)
            {
                // mostrar solo carrito lleno --
                pnlCarritoConItems.Visible = true;
                pnlCarritoVacio.Visible = false;

                // Listado DTO
                CarritoNegocio negocio = new CarritoNegocio();
                var listaDto = negocio.ObtenerListadoDTO(carrito);

                repCarrito.DataSource = listaDto;
                repCarrito.DataBind();

                // total carrito
                decimal total = negocio.CalcularTotal(carrito);
                int cantidadItems = carrito.Items.Sum(x => x.Cantidad);

                lblCantidadItems.Text = cantidadItems.ToString();

                // formato moneda (N2 --> puntos de mil y 2 decimales)
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
            // Logica: eliminar/sumar/restar
            try
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);
                Dominio.Carrito carrito = (Dominio.Carrito)Session["Carrito"];
                Dominio.CarritoItem item = carrito.Items.Find(x => x.Producto.IdProducto == idProducto);

                if (item != null)
                {
                    if (e.CommandName == "eliminar")
                    {
                        carrito.Items.Remove(item);
                    }
                    else if (e.CommandName == "sumar")
                    {
                        item.Cantidad++;
                    }
                    else if (e.CommandName == "restar")
                    {
                        if (item.Cantidad > 1) item.Cantidad--;
                    }

                    Session["Carrito"] = carrito;
                    CargarCarrito();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnIniciarCompra_Click(object sender, EventArgs e)
        {
            if (Session["carrito"] != null && ((Dominio.Carrito)Session["carrito"]).Items.Count > 0)
            {
                Response.Redirect("~/Checkout.aspx");
            }
        }

    }
}