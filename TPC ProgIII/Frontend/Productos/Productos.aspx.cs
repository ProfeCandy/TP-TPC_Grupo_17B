using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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
                pnlAdminActions.Visible = EsAdminOVendedor();
                
                string idCategoria = Request.QueryString["id"];
                string busqueda = Request.QueryString["q"];
                string orden = Request.QueryString["sort"];

                int idParsed = 0;
                if (idCategoria != null) int.TryParse(idCategoria, out idParsed);

                // Llama a cargar con todos los datos
                cargarProductos(idParsed, busqueda, orden);
            }
        }
        private void cargarProductos(int idCategoria = 0, string busqueda = null, string orden = "0")
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                if (idCategoria != 0)
                {
                    ListaProductos = negocio.ListarPorCategoria(idCategoria);
                }
                else if (!string.IsNullOrEmpty(busqueda))
                {
                    // Filtro por Búsqueda
                    ListaProductos = negocio.Listar(busqueda);

                    // Si termina en S , buscamos sin la S y viceversa
                    string terminoBusqueda = busqueda;
                    if (terminoBusqueda.EndsWith("s") && terminoBusqueda.Length > 3)
                    {
                        terminoBusqueda = terminoBusqueda.Substring(0, terminoBusqueda.Length - 1);
                    }   
                    if (ListaProductos.Count == 0 && busqueda.EndsWith("s"))
                    {
                        ListaProductos = negocio.Listar(busqueda.TrimEnd('s'));
                    }

                    if (ListaProductos.Count == 0)
                    {
                        lblMensaje.Text = "No se encontraron productos para: " + busqueda;
                        panelMensajes.Visible = true;
                        panelMensajes.CssClass = "alert alert-warning";
                    }
                }
                else
                {
                    // Sin filtros (Trae todo)
                    ListaProductos = negocio.Listar();
                }

                // Ordenamiento
                switch (orden)
                {
                    case "1": // Menor
                        ListaProductos = ListaProductos.OrderBy(x => x.Precio).ToList();
                        break;
                    case "2": // Mayor
                        ListaProductos = ListaProductos.OrderByDescending(x => x.Precio).ToList();
                        break;
                    case "3": // A-Z
                        ListaProductos = ListaProductos.OrderBy(x => x.NombreProducto).ToList();
                        break;
                    case "4": // Z-A
                        ListaProductos = ListaProductos.OrderByDescending(x => x.NombreProducto).ToList();
                        break;
                    default:
                        break;
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
                {
                    panelMensajes.CssClass = "alert alert-success";
                    if (this.Master is SiteMaster master)
                    {
                        master.ActualizarContadorCarrito();
                    }
                }
            }
        }
        public bool EsAdminOVendedor()
        {
            if (Session["usuario"] != null)
            {
                Usuario user = (Usuario)Session["usuario"];
                if (user.Rol != null)
                {
                    string rol = user.Rol.NombreRol.ToLower();
                    return rol == "administrador" || rol == "vendedor";
                }
            }
            return false;
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int idProducto = int.Parse(btn.CommandArgument);

            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                negocio.EliminarLogico(idProducto);
                
                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception ex)
            {
                panelMensajes.Visible = true;
                lblMensaje.Text = "Error al eliminar el producto: " + ex.Message;
                panelMensajes.CssClass = "alert alert-danger";
            }
        }
        protected void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNuevaMarca.Text))
                {
                    pnlMensajeMarca.Visible = true;
                    pnlMensajeMarca.CssClass = "alert alert-danger mb-0";
                    lblMensajeMarca.Text = "El nombre de la marca es obligatorio.";
                    return;
                }

                Marca nuevaMarca = new Marca();
                nuevaMarca.Descripcion = txtNuevaMarca.Text.Trim();

                MarcaNegocio negocio = new MarcaNegocio();
                negocio.Agregar(nuevaMarca);

                // Limpiar campo y mostrar mensaje de éxito
                txtNuevaMarca.Text = "";
                pnlMensajeMarca.Visible = true;
                pnlMensajeMarca.CssClass = "alert alert-success mb-0";
                lblMensajeMarca.Text = "Marca creada correctamente.";

                // Cerrar modal después de un breve delay
                ClientScript.RegisterStartupScript(this.GetType(), "cerrarModalMarca", 
                    "setTimeout(function() { var modal = bootstrap.Modal.getInstance(document.getElementById('modalNuevaMarca')); if (modal) modal.hide(); }, 1500);", true);
            }
            catch (Exception ex)
            {
                pnlMensajeMarca.Visible = true;
                pnlMensajeMarca.CssClass = "alert alert-danger mb-0";
                lblMensajeMarca.Text = "Error al crear la marca: " + ex.Message;
            }
        }
        protected void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNuevaCategoria.Text))
                {
                    pnlMensajeCategoria.Visible = true;
                    pnlMensajeCategoria.CssClass = "alert alert-danger mb-0";
                    lblMensajeCategoria.Text = "El nombre de la categor&iacute;a es obligatorio.";
                    return;
                }

                Categoria nuevaCategoria = new Categoria();
                nuevaCategoria.Descripcion = txtNuevaCategoria.Text.Trim();

                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.Agregar(nuevaCategoria);

                // Limpiar campo y mostrar mensaje de éxito
                txtNuevaCategoria.Text = "";
                pnlMensajeCategoria.Visible = true;
                pnlMensajeCategoria.CssClass = "alert alert-success mb-0";
                lblMensajeCategoria.Text = "Categor&iacute;a creada correctamente.";

                // Cerrar modal después de un breve delay
                ClientScript.RegisterStartupScript(this.GetType(), "cerrarModalCategoria", 
                    "setTimeout(function() { var modal = bootstrap.Modal.getInstance(document.getElementById('modalNuevaCategoria')); if (modal) modal.hide(); }, 1500);", true);
            }
            catch (Exception ex)
            {
                pnlMensajeCategoria.Visible = true;
                pnlMensajeCategoria.CssClass = "alert alert-danger mb-0";
                lblMensajeCategoria.Text = "Error al crear la categor&iacute;a: " + ex.Message;
            }
        }
        // Manejo de botones de ordenamiento
        protected void btnOrden_Click(object sender, EventArgs e)
        {
            // Agarramos el criterio nuevo
            LinkButton btn = (LinkButton)sender;
            string nuevoOrden = btn.CommandArgument;

            // Recuperamos los filtros actuales
            string idCategoria = Request.QueryString["id"];
            string busqueda = Request.QueryString["q"];

            string url = "Productos.aspx?";

            // Agregamos los parámetros que ya estaban
            if (idCategoria != null) url += "id=" + idCategoria + "&";
            if (busqueda != null) url += "q=" + busqueda + "&";

            // Agregamos el orden nuevo
            url += "sort=" + nuevoOrden;

            // Redirigimos para no tener el cartel de recarga feo
            Response.Redirect(url);
        }
    }
}