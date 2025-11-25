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
                if (Session["carrito"] == null)
                {
                    Response.Redirect("~/Productos/Productos.aspx");
                }

                Dominio.Carrito carrito = (Dominio.Carrito)Session["carrito"];

                if (carrito.Items == null || carrito.Items.Count == 0)
                {
                    Response.Redirect("~/Productos/Productos.aspx");
                }
                CargarResumen();
                VerificarLogin();

            }
        }
        private void CargarResumen()
        {
            // Agarramos el carrito de la sesión
            Dominio.Carrito carrito = (Dominio.Carrito)Session["carrito"];

            repResumenCarrito.DataSource = carrito.Items;
            repResumenCarrito.DataBind();

            decimal total = carrito.Items.Sum(item => item.Producto.Precio * item.Cantidad);
            lblTotal.Text = "$ " + total.ToString("N0");
        }
        private void VerificarLogin()
        {
            if (Session["usuario"] != null)
            {
                // Si esta logeado se oculta el pnl de invitado
                Usuario user = (Usuario)Session["usuario"];
                pnlIngresoGuest.Visible = false;

                //Pnl Logeado
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
        protected void btnSiguienteEnvio_Click(object sender, EventArgs e)
        {
            // Paso 1 bloqueado
            pnlContacto.Enabled = false;
            pnlContacto.CssClass = "card-body opacity-50";
            btnSiguienteEnvio.Visible = false;
            btnEditarContacto.Visible = true;

            // Paso 2 habilitado
            pnlEntrega.Visible = true;
            pnlEntregaContent.Enabled = true;
            pnlEntregaContent.CssClass = "card-body";

            if (rdbDomicilio.Checked || rdbRetiro.Checked)
            {
                btnSiguientePago.Visible = true;
            }
        }
        protected void btnEditarContacto_Click(object sender, EventArgs e)
        {
            pnlContacto.Enabled = true;
            pnlContacto.CssClass = "card-body";

            btnSiguienteEnvio.Visible = true;
            btnEditarContacto.Visible = false;

            if (pnlEntrega.Visible) 
            {
                pnlEntregaContent.Enabled = false;
                pnlEntregaContent.CssClass = "card-body opacity-50";
                btnEditarContacto.Visible = false;
            }
            pnlPago.Visible = false;
        }
        protected void MetodoEnvio_CheckedChanged(object sender, EventArgs e)
        {
            //Domicilio
            if (rdbDomicilio.Checked)
            {
                pnlDatosEnvio.Visible = true;
                btnSiguientePago.Visible = true;

                if (Session["usuario"] != null)
                {
                    Usuario user = (Usuario)Session["usuario"];
                    if (string.IsNullOrEmpty(txtCalle.Text))
                    {
                        txtCalle.Text = user.Direccion;
                        txtLocalidad.Text = user.Localidad;
                    }
                }
            //Retiro en sucursal
            }
            else if (rdbRetiro.Checked)
            {
                pnlDatosEnvio.Visible = false;
                btnSiguientePago.Visible = true;
            }
        }
        protected void btnSiguientePago_Click(object sender, EventArgs e)
        {
            if (rdbDomicilio.Checked)
            {
                if (string.IsNullOrEmpty(txtCalle.Text) || string.IsNullOrEmpty(txtCP.Text)) return;
            }

            // Ahora el Paso 2 queda en gris
            pnlEntregaContent.Enabled = false;
            pnlEntregaContent.CssClass = "card-body opacity-50";

            btnSiguientePago.Visible = false;
            btnEditarEntrega.Visible = true;

            pnlPago.Visible = true;
        }
        protected void btnEditarEntrega_Click(object sender, EventArgs e)
        {
            // Habilitamos el contenido del Paso 2
            pnlEntregaContent.Enabled = true;
            pnlEntregaContent.CssClass = "card-body";

            btnSiguientePago.Visible = true;
            btnEditarEntrega.Visible = false;

            pnlPago.Visible = false;

            // Limpiamos selección de pago
            rdbMercadoPago.Checked = false;
            rdbTransferencia.Checked = false;
            pnlInfoMP.Visible = false;
            pnlInfoTransferencia.Visible = false;
            btnFinalizar.Visible = false;
        }
        protected void lnkCambiarCuenta_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Usuarios/Login.aspx");
        }
        protected void MetodoPago_CheckedChanged(object sender, EventArgs e)
        {
            // Reseteamos visibilidad
            pnlInfoMP.Visible = false;
            pnlInfoTransferencia.Visible = false;
            btnFinalizar.Visible = true;

            if (rdbMercadoPago.Checked)
            {
                pnlInfoMP.Visible = true;
            }
            else if (rdbTransferencia.Checked)
            {
                pnlInfoTransferencia.Visible = true;
            }
        }
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (rdbTransferencia.Checked)
            {
                // Si es transferencia, carga los datos del comprobante
                if (string.IsNullOrEmpty(txtBancoOrigen.Text) || string.IsNullOrEmpty(txtNumeroComprobante.Text))
                {
                    return;
                }
            }
            // Si es MercadoPago -> Hay que simular la redirección o ir a éxito
            // Si es Transferencia -> Ir a pantalla de éxito directamente

            // Response.Redirect("PedidoExitoso.aspx"); // (hay que crear esta página)
        }
    }
}