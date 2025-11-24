using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["carrito"] == null || ((List<CarritoItem>)Session["carrito"]).Count == 0)
                {
                    Response.Redirect("Productos.aspx");
                }

                CargarResumen();
                VerificarLogin();

            }
        }

        private void CargarResumen()
        {
            // Obtener el carrito de la sesión
            List<CarritoItem> carrito = (List<CarritoItem>)Session["carrito"];

            repResumenCarrito.DataSource = carrito;
            repResumenCarrito.DataBind();

            decimal total = carrito.Sum(item => item.Producto.Precio * item.Cantidad);
            lblTotal.Text = "$ " + total.ToString("N0");
        }

        private void VerificarLogin()
        {
            if (Session["usuario"] != null)
            {
                // Si esta logeado se oculta el pnl de invitado
                Usuario user = (Usuario)Session["usuario"];
                pnlIngresoGuest.Visible = false;

                //Panel Logeado
                pnlUsuarioLogueado.Visible = true;
                lblNombreUsuario.Text = user.Nombre + " " + user.Apellido;
                lblEmailUsuario.Text = user.Email;

                txtEmailCheckout.Text = user.Email;
                txtNombreFacturacion.Text = user.Nombre;
                txtApellidoFacturacion.Text = user.Apellido;
            }
            else
            {
                //Invitado
                pnlIngresoGuest.Visible = true;
                pnlUsuarioLogueado.Visible = false;
            }
        }
        // Paso 1 -> Ir al Paso 2
        protected void btnSiguienteEnvio_Click(object sender, EventArgs e)
        {
            pnlContacto.CssClass = "card shadow-sm mb-4 opacity-50"; // solamente da efecto de Paso 1 deshabilitado

            txtEmailCheckout.Enabled = false;
            txtNombreFacturacion.Enabled = false;
            btnSiguienteEnvio.Enabled = false;

            //Paso 2
            pnlEntrega.Visible = true;
        }
    }
}