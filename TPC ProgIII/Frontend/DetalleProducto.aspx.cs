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
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idProductoString = Request.QueryString["id"];

                if (idProductoString != null && int.TryParse(idProductoString, out int idProducto))
                {
                    CargarDetalleProducto(idProducto);
                }
                else
                {
                    MostrarError("No se especificó un ID de producto válido.");
                }
            }
        }

        private void CargarDetalleProducto(int id)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Producto producto = null;

            try
            {
                producto = negocio.ObtenerPorId(id);

                if (producto != null)
                {
                    lblNombreProducto.Text = producto.NombreProducto;
                    lblMarca.Text = producto.Marca.Descripcion;
                    lblCodigo.Text = producto.IdProducto.ToString();
                    lblPrecio.Text = $"${producto.Precio:N2}"; 

                    litDetalleCompleto.Text = producto.Descripcion;

                    if (producto.Imagenes != null && producto.Imagenes.Count > 0)
                    {
                        imgProductoPrincipal.ImageUrl = producto.ImagenPrincipal;

                        repImagenes.DataSource = producto.Imagenes;
                        repImagenes.DataBind();
                    }
                    else
                    {
                        imgProductoPrincipal.ImageUrl = "https://dummyimage.com/450x300/dee2e6/6c757d.jpg";
                    }
                }
                else
                {
                    MostrarError($"El producto con ID {id} no fue encontrado.");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error grave al cargar los datos del producto. Contacte al administrador. Detalle: " + ex.Message);
            }
        }

        private void MostrarError(string mensaje)
        {
            panelMensajes.Visible = true;
            lblMensajeError.Text = mensaje;
        }
    } 
}