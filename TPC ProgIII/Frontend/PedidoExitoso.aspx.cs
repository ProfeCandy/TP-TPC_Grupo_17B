using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Frontend
{
    public partial class PedidoExitoso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["compraRealizada"] != null)
                {
                    List<CarritoItem> itemsComprados = (List<CarritoItem>)Session["compraRealizada"];

                    repDetalleCompra.DataSource = itemsComprados;
                    repDetalleCompra.DataBind();

                    decimal total= itemsComprados.Sum(item => item.Producto.Precio * item.Cantidad);
                    lblTotalPagado.Text = "$ " + total.ToString("N0");
                 
                    //Para recargar y que no falle
                    Session["compraRealizada"] = null;
                }
                else
                {
                    Response.Redirect("~/Productos/Productos.aspx");
                }
            }
        }
    }
}