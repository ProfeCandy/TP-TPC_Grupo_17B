using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            AccesoDatos datos = new AccesoDatos();
            List<Producto> lista = new List<Producto>();

            try
            {
                datos.setearConsulta("SELECT p.IdProducto, p.NombreProducto, p.Descripcion, m.Nombre AS Marca, p.Precio, p.Stock, c.Nombre AS Categoria, p.Activo " +
                                     "FROM Producto p " +
                                     "INNER JOIN Marcas m ON m.IdMarca = p.IdMarca " +
                                     "INNER JOIN Categorias c ON c.IdCategoria = p.IdCategoria");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto p = new Producto();
                    p.IdProducto = (int)datos.Lector["IdProducto"];
                    p.NombreProducto = (string)datos.Lector["NombreProducto"];
                    p.Descripcion = (string)datos.Lector["Descripcion"];
                    p.Marca = (string)datos.Lector["Marca"];
                    p.Precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    p.Stock = (int)datos.Lector["Stock"];
                    p.Categoria = new Categoria();
                    p.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    p.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(p);
                }

                dgvProductos.DataSource = lista;
                dgvProductos.DataBind();
            }
            catch (Exception ex)
            {
                panelMensajes.Visible = true;
                lblMensaje.Text = "Error al cargar los productos: " + ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
