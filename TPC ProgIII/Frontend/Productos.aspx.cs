using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace TPC_ProgIII
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProductos();
            }
        }

        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();

            try
            {
                List<Producto> lista = negocio.Listar();
                dgvProductos.DataSource = lista;
                dgvProductos.DataBind();
            }
            catch (Exception ex)
            {
                panelMensajes.Visible = true;
                lblMensaje.Text = "Error al cargar los productos: " + ex.Message;
            }
        }
    }
}