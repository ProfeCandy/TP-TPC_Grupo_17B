using Dominio;
using Negocio;
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
                        txtAltura.Text = user.Altura;
                        txtCP.Text = user.CodigoPostal;
                        txtLocalidad.Text = user.Localidad;
                        txtProvincia.Text = user.Provincia;
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
                if (string.IsNullOrEmpty(txtBancoOrigen.Text) || string.IsNullOrEmpty(txtNumeroComprobante.Text))
                    return;
            }

            try
            {
                Usuario usuarioCompra = ObtenerOCrearUsuario();
                Dominio.Carrito carrito = (Dominio.Carrito)Session["carrito"];

                Pedido pedido = new Pedido();
                pedido.Usuario = usuarioCompra;
                pedido.FechaPedido = DateTime.Now;
                pedido.Estado = "Pendiente";
                pedido.Total = carrito.Items.Sum(i => i.Producto.Precio * i.Cantidad);

                // Si es domicilio o retiro
                if (rdbDomicilio.Checked)
                {
                    pedido.MetodoEnvio = "Domicilio";
                    pedido.CostoEnvio = "0";
                    pedido.DireccionEnvio = txtCalle.Text + " " + txtAltura.Text;
                    pedido.LocalidadEnvio = txtLocalidad.Text;
                    pedido.ProvinciaEnvio = txtProvincia.Text;
                    pedido.CodigoPostal = txtCP.Text;
                }
                else
                {
                    pedido.MetodoEnvio = "Retiro";
                    pedido.CostoEnvio = "0";
                }

                if (rdbMercadoPago.Checked) pedido.MetodoPago = "MercadoPago";
                else pedido.MetodoPago = "Transferencia";

                pedido.Detalles = new List<DetallePedido>();
                foreach (var itemCarrito in carrito.Items)
                {
                    DetallePedido detalle = new DetallePedido();
                    detalle.Producto = itemCarrito.Producto;
                    detalle.Cantidad = itemCarrito.Cantidad;
                    detalle.PrecioUnitario = itemCarrito.Producto.Precio;
                    pedido.Detalles.Add(detalle);
                }

                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                pedidoNegocio.Guardar(pedido);

                Session["compraRealizada"] = carrito.Items;
                Session["carrito"] = null;

                Response.Redirect("~/PedidoExitoso.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        private Usuario ObtenerOCrearUsuario()
        {
            // Si ya está logueado, devolvemos el de la sesión
            if (Session["usuario"] != null)
            {
                return (Usuario)Session["usuario"];
            }

            // Si es invitado verificamos si existe en la BD
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            string emailIngresado = txtEmailCheckout.Text;

            Usuario userExistente = usuarioNegocio.BuscarPorEmail(emailIngresado);

            if (userExistente != null)
            {
                return userExistente;
            }

            // Si no existe,lo creamos
            Usuario nuevo = new Usuario();
            nuevo.Email = emailIngresado;
            nuevo.Nombre = txtNombreFacturacion.Text;
            nuevo.Apellido = txtApellidoFacturacion.Text;

            // Le creamos una contra por el momento
            string passwordTemporal = "Auto" + new Random().Next(1000, 9999).ToString();
            nuevo.Clave = passwordTemporal;

            nuevo.Rol = new Rol();
            nuevo.Rol.IdRol = 2;
            nuevo.Activo = true;

            // Si selecciona Domicilio le guardamos la informacion en el perfil
            if (rdbDomicilio.Checked)
            {
                nuevo.Direccion = txtCalle.Text + " " + txtAltura.Text;
                nuevo.Localidad = txtLocalidad.Text + " (" + txtCP.Text + ")";
            }
            // En caso que sea sucursal le guardamos el default
            else
            {
                nuevo.Direccion = "-";
                nuevo.Localidad = "-";
            }

            usuarioNegocio.Agregar(nuevo);
            usuarioNegocio.Loguear(nuevo);

            Session.Add("usuario", nuevo);
            Session["passTemporal"] = passwordTemporal;

            return nuevo;
        }
    }
}