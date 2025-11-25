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
                int idProducto = Convert.ToInt32(e.CommandArgument);

                // AGREGA PRODUCTO - DEVUELVE MENSAJE
                string mensaje = CarritoManager.Agregar(idProducto, 1, Session);

                lblMensaje.Text = mensaje;
                panelMensajes.Visible = true;

                if (mensaje.Contains("Error"))
                    panelMensajes.CssClass = "alert alert-danger";
                else
                    panelMensajes.CssClass = "alert alert-success";
            }
        }
    }
}