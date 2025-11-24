using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TPC_ProgIII
{
    public partial class Productos : System.Web.UI.Page
    {
        public List<Producto> ListaProductos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Capturamos el ID de la categoría desde la URL
                string idCategoria = Request.QueryString["id"];

                if (idCategoria != null)
                {
                    // Si hay ID, cargamos filtrado
                    int idParsed;
                    if (int.TryParse(idCategoria, out idParsed))
                    {
                        cargarProductos(idParsed);
                    }
                    else
                    {
                        // Si el ID no es número, cargamos todo
                        cargarProductos(0);
                    }
                }
                else
                {
                    // Si no hay ID, cargamos todo el catálogo
                    cargarProductos(0);
                }
            }
        }

        private void cargarProductos(int idCategoria)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                if (idCategoria != 0)
                {
                    // Usamos ProductoNegocio
                    ListaProductos = negocio.ListarPorCategoria(idCategoria);
                }
                else
                {
                    // Usamos el método listar
                    ListaProductos = negocio.Listar();
                }

                // Enlazamos la lista al Repeater
                repProductos.DataSource = ListaProductos;
                repProductos.DataBind();
            }
            catch (Exception ex)
            {
                // Si falla, mostramos error 
                panelMensajes.Visible = true;
                lblMensaje.Text = "Hubo un problema al cargar los productos. Detalle técnico: " + ex.Message;
            }
        }

        protected void repProductos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                // ID del producto desde CommandArgument
                string idString = e.CommandArgument.ToString();
                int idProducto = int.Parse(idString);

                // producto de BD
                ProductoNegocio negocioProducto = new ProductoNegocio();
                Producto productoSeleccionado = negocioProducto.ObtenerPorId(idProducto);

                if (productoSeleccionado != null)
                {
                    // Obtener/Iniciar Carrito en Session
                    Carrito carritoActual;
                    if (Session["Carrito"] == null)
                    {
                        carritoActual = new Carrito();
                    }
                    else
                    {
                        carritoActual = (Carrito)Session["Carrito"];
                    }

                    // agregar item
                    CarritoNegocio negocioCarrito = new CarritoNegocio();
                    negocioCarrito.AgregarItem(carritoActual, productoSeleccionado, 1);

                    // guardar en Sesión
                    Session["Carrito"] = carritoActual;

                    // msj exito
                    lblMensaje.Text = "Producto agregado!";
                    panelMensajes.Visible = true;
                    panelMensajes.CssClass = "alert alert-success"; 
                }
            }
        }
    }
}