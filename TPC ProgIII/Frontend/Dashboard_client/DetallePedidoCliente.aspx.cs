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
    public partial class DetallePedidoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("../Usuarios/Login.aspx");
            }

            if (!IsPostBack)
            {
                string idStr = Request.QueryString["id"];
                if (string.IsNullOrEmpty(idStr))
                {
                    Response.Redirect("HistorialPedidos.aspx");
                    return;
                }

                int idPedido = int.Parse(idStr);

                PedidoNegocio negocio = new PedidoNegocio();
                Pedido pedido = negocio.ObtenerPedidoConDetalles(idPedido);

                if (pedido != null)
                {
                    lblNroPedido.Text = pedido.IdPedido.ToString();
                    lblFecha.Text = pedido.FechaPedido.ToString("dd/MM/yyyy");
                    lblEstado.Text = pedido.Estado;
                    lblTotal.Text = "$ " + pedido.Total.ToString("N0");
                    lblPago.Text = pedido.MetodoPago;

                    lblMetodoEnvio.Text = pedido.MetodoEnvio;

                    if (pedido.MetodoEnvio == "Domicilio")
                    {
                        pnlDireccion.Visible = true;
                        pnlRetiro.Visible = false;

                        string direccion = pedido.DireccionEnvio;

                        if (!string.IsNullOrEmpty(pedido.LocalidadEnvio))
                            direccion += ", " + pedido.LocalidadEnvio;

                        if (!string.IsNullOrEmpty(pedido.CodigoPostal))
                            direccion += " (" + pedido.CodigoPostal + ")";

                        if (!string.IsNullOrEmpty(pedido.ProvinciaEnvio))
                            direccion += ", " + pedido.ProvinciaEnvio;

                        lblDireccionCompleta.Text = direccion;
                    }
                    else
                    {
                        pnlDireccion.Visible = false;
                        pnlRetiro.Visible = true;
                    }
                    repDetalles.DataSource = pedido.Detalles;
                    repDetalles.DataBind();
                }
            }
        }
    }
}