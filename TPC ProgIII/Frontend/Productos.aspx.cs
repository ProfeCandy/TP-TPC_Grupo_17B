using Dominio;
using Negocio;
using System;
using System.Collections.Generic;

namespace TPC_ProgIII
{
    public partial class Productos : System.Web.UI.Page
    {
        // Propiedad pública por si necesitas acceder a la lista desde el aspx (opcional)
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
                    // (Asegurate de que el ID en la URL sea un número válido)
                    int idParsed;
                    if (int.TryParse(idCategoria, out idParsed))
                    {
                        cargarProductos(idParsed);
                    }
                    else
                    {
                        // Si el ID no es un número, cargamos todo
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
                    // Usamos el nuevo método que agregaste a ProductoNegocio
                    ListaProductos = negocio.ListarPorCategoria(idCategoria);
                }
                else
                {
                    // Usamos el método clásico que trae todo
                    ListaProductos = negocio.Listar();
                }

                // Enlazamos la lista al Repeater (el visualizador de tarjetas)
                repProductos.DataSource = ListaProductos;
                repProductos.DataBind();
            }
            catch (Exception ex)
            {
                // Si falla, mostramos el error en el panel rojo
                panelMensajes.Visible = true;
                lblMensaje.Text = "Hubo un problema al cargar los productos. Detalle técnico: " + ex.Message;
            }
        }
    }
}