using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using Dominio;
using Negocio;

namespace TPC_ProgIII
{
    public partial class FormularioProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || (!EsAdmin() && !EsVendedor()))
            {
                Response.Redirect("Productos.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarMarcas();
                CargarCategorias();

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int idProducto = int.Parse(Request.QueryString["id"]);
                    lblTituloPagina.Text = "Editar Producto";
                    CargarProducto(idProducto);
                }
                else
                {
                    lblTituloPagina.Text = "Crear Producto";
                }
            }
        }

        private void CargarMarcas()
        {
            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                ddlMarca.DataSource = negocio.Listar();
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "IdMarca";
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("Seleccionar marca", "0"));
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar marcas: " + ex.Message, true);
            }
        }

        private void CargarCategorias()
        {
            try
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                ddlCategoria.DataSource = negocio.Listar();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, new ListItem("Seleccionar categoría", "0"));
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar categorías: " + ex.Message, true);
            }
        }

        private void CargarProducto(int id)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Producto producto = negocio.ObtenerPorId(id);

                if (producto != null)
                {
                    txtNombre.Text = producto.NombreProducto;
                    txtDescripcion.Text = producto.Descripcion;
                    txtPrecio.Text = producto.Precio.ToString("F2");
                    
                    if (producto.Marca != null)
                        ddlMarca.SelectedValue = producto.Marca.IdMarca.ToString();
                    
                    if (producto.Categoria != null)
                        ddlCategoria.SelectedValue = producto.Categoria.IdCategoria.ToString();

                    if (producto.Imagenes != null && producto.Imagenes.Count > 0)
                    {
                        string imagenUrl = producto.Imagenes[0].UrlImagen;
                        imgActual.ImageUrl = imagenUrl;
                        pnlImagenActual.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar el producto: " + ex.Message, true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    MostrarMensaje("El nombre y la descripción son obligatorios.", true);
                    return;
                }

                if (ddlMarca.SelectedValue == "0" || ddlCategoria.SelectedValue == "0")
                {
                    MostrarMensaje("Debés seleccionar una marca y una categoría.", true);
                    return;
                }

                if (string.IsNullOrEmpty(txtPrecio.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MostrarMensaje("Debés ingresar un precio válido.", true);
                    return;
                }

                Producto producto = new Producto();
                producto.NombreProducto = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.Precio = precio;
                producto.Marca = new Marca { IdMarca = int.Parse(ddlMarca.SelectedValue) };
                producto.Categoria = new Categoria { IdCategoria = int.Parse(ddlCategoria.SelectedValue) };
                producto.Imagenes = new List<ProductoImagen>();

                ProductoNegocio negocio = new ProductoNegocio();

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    producto.IdProducto = int.Parse(Request.QueryString["id"]);
                    negocio.Modificar(producto);
                    MostrarMensaje("Producto actualizado correctamente.", false);

                    if (fileImagen.HasFile)
                    {
                        AccesoDatos datosDel = new AccesoDatos();
                        datosDel.setearConsulta("DELETE FROM Imagen WHERE IdProducto = @IdProducto");
                        datosDel.setearParametro("@IdProducto", producto.IdProducto);
                        datosDel.ejecutarAccion();
                    }
                }
                else
                {
                    producto.IdProducto = negocio.Agregar(producto);
                    MostrarMensaje("Producto creado correctamente.", false);
                }

                if (fileImagen.HasFile)
                {
                    string nombreArchivo = GuardarImagen(fileImagen, producto.IdProducto);
                    if (!string.IsNullOrEmpty(nombreArchivo))
                    {
                        AccesoDatos datos = new AccesoDatos();
                        datos.setearConsulta("INSERT INTO Imagen (IdProducto, UrlImagen) VALUES (@IdProducto, @UrlImagen)");
                        datos.setearParametro("@IdProducto", producto.IdProducto);
                        datos.setearParametro("@UrlImagen", nombreArchivo);
                        datos.ejecutarAccion();
                    }
                }

                Response.AddHeader("Refresh", "2;url=Productos.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar: " + ex.Message, true);
            }
        }

        private string GuardarImagen(FileUpload fileUpload, int idProducto)
        {
            try
            {
                string extension = Path.GetExtension(fileUpload.FileName).ToLower();
                string[] extensionesPermitidas = { ".jpg", ".jpeg", ".png", ".gif" };
                
                if (!extensionesPermitidas.Contains(extension))
                {
                    MostrarMensaje("Formato de imagen no válido. Use JPG, PNG o GIF.", true);
                    return null;
                }

                if (fileUpload.PostedFile.ContentLength > 2 * 1024 * 1024)
                {
                    MostrarMensaje("La imagen es demasiado grande. Máximo 2MB.", true);
                    return null;
                }

                byte[] imagenBytes = new byte[fileUpload.PostedFile.ContentLength];
                fileUpload.PostedFile.InputStream.Read(imagenBytes, 0, imagenBytes.Length);
                
                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(ms))
                    {
                        int anchoMaximo = 1920;
                        int altoMaximo = 1080;

                        if (img.Width > anchoMaximo || img.Height > altoMaximo)
                        {
                            MostrarMensaje($"Las dimensiones de la imagen son demasiado grandes. Máximo: {anchoMaximo}x{altoMaximo}px. Tu imagen: {img.Width}x{img.Height}px", true);
                            return null;
                        }
                    }
                }

                string carpetaImagenes = Server.MapPath("~/assets/img/productos/");
                if (!Directory.Exists(carpetaImagenes))
                {
                    Directory.CreateDirectory(carpetaImagenes);
                }

                string nombreArchivo = $"producto_{idProducto}_{DateTime.Now.Ticks}{extension}";
                string rutaCompleta = Path.Combine(carpetaImagenes, nombreArchivo);

                File.WriteAllBytes(rutaCompleta, imagenBytes);

                return $"~/assets/img/productos/{nombreArchivo}";
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar la imagen: " + ex.Message, true);
                return null;
            }
        }

        private void MostrarMensaje(string mensaje, bool esError)
        {
            panelMensaje.Visible = true;
            lblMensaje.Text = mensaje;
            
            if (esError)
                panelMensaje.CssClass = "alert alert-danger";
            else
                panelMensaje.CssClass = "alert alert-success";
        }

        private bool EsAdmin()
        {
            if (Session["usuario"] != null)
            {
                Usuario user = (Usuario)Session["usuario"];
                if (user.Rol != null && user.Rol.NombreRol.ToLower() == "administrador")
                    return true;
            }
            return false;
        }

        private bool EsVendedor()
        {
            if (Session["usuario"] != null)
            {
                Usuario user = (Usuario)Session["usuario"];
                if (user.Rol != null && user.Rol.NombreRol.ToLower() == "vendedor")
                    return true;
            }
            return false;
        }
    }
}

