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
                MostrarMensaje("Error al cargar categor&iacute;as: " + ex.Message, true);
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
                    txtPrecio.Text = producto.Precio.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    txtStock.Text = producto.Stock.ToString();
                    
                    if (producto.Marca != null)
                        ddlMarca.SelectedValue = producto.Marca.IdMarca.ToString();
                    
                    if (producto.Categoria != null)
                        ddlCategoria.SelectedValue = producto.Categoria.IdCategoria.ToString();

                    if (producto.Imagenes != null && producto.Imagenes.Count > 0)
                    {
                        repImagenesActuales.DataSource = producto.Imagenes;
                        repImagenesActuales.DataBind();
                        pnlImagenesActuales.Visible = true;
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
                    MostrarMensaje("El nombre y la descripci&oacute;n son obligatorios.", true);
                    return;
                }

                if (ddlMarca.SelectedValue == "0" || ddlCategoria.SelectedValue == "0")
                {
                    MostrarMensaje("Deb&eacute;s seleccionar una marca y una categor&iacute;a.", true);
                    return;
                }

                // 1. Normalizamos: Cambiamos coma por punto para estandarizar
                string precioTexto = txtPrecio.Text.Replace(",", ".");

                // 2. Parseamos usando InvariantCulture (que siempre usa punto para decimales)
                if (string.IsNullOrEmpty(precioTexto) ||
                    !decimal.TryParse(precioTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal precio))
                {
                    MostrarMensaje("Debés ingresar un precio válido (ej: 1200.50).", true);
                    return;
                }

                // 3. Validamos positivo
                if (precio <= 0)
                {
                    MostrarMensaje("El precio debe ser mayor a 0.", true);
                    return;
                }

                if (fileImagen.HasFile)
                {
                    HttpFileCollection archivos = Request.Files;
                    int archivosValidos = 0;
                    for (int i = 0; i < archivos.Count; i++)
                    {
                        HttpPostedFile archivo = archivos[i];
                        if (archivo != null && archivo.ContentLength > 0 && !string.IsNullOrEmpty(archivo.FileName))
                        {
                            archivosValidos++;
                            string errorValidacion = ValidarImagenArchivo(archivo);
                            if (!string.IsNullOrEmpty(errorValidacion))
                            {
                                MostrarMensaje($"Error en archivo {archivosValidos}: {errorValidacion}", true);
                                return;
                            }
                        }
                    }
                }

                int stock = 0;
                if (!string.IsNullOrEmpty(txtStock.Text) && !int.TryParse(txtStock.Text, out stock))
                {
                    MostrarMensaje("Debés ingresar un stock válido.", true);
                    return;
                }
                if (stock < 0)
                {
                    MostrarMensaje("El stock no puede ser negativo.", true);
                    return;
                }

                Producto producto = new Producto();
                producto.NombreProducto = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.Precio = precio;
                producto.Stock = stock;
                producto.Marca = new Marca { IdMarca = int.Parse(ddlMarca.SelectedValue) };
                producto.Categoria = new Categoria { IdCategoria = int.Parse(ddlCategoria.SelectedValue) };

                ProductoNegocio negocio = new ProductoNegocio();

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    producto.IdProducto = int.Parse(Request.QueryString["id"]);
                    
                    Producto productoExistente = negocio.ObtenerPorId(producto.IdProducto);
                    if (productoExistente != null && productoExistente.Imagenes != null && productoExistente.Imagenes.Count > 0)
                    {
                        producto.Imagenes = productoExistente.Imagenes;
                    }
                    else
                    {
                        producto.Imagenes = new List<ProductoImagen>();
                    }

                    negocio.Modificar(producto);

                    if (fileImagen.HasFile)
                    {
                        HttpFileCollection archivos = Request.Files;
                        ImagenNegocio imagenNegocio = new ImagenNegocio();
                        
                        for (int i = 0; i < archivos.Count; i++)
                        {
                            HttpPostedFile archivo = archivos[i];
                            if (archivo != null && archivo.ContentLength > 0 && !string.IsNullOrEmpty(archivo.FileName))
                            {
                                string nombreArchivo = GuardarImagenArchivo(archivo, producto.IdProducto);
                                if (!string.IsNullOrEmpty(nombreArchivo))
                                {
                                    imagenNegocio.Agregar(producto.IdProducto, nombreArchivo);
                                }
                            }
                        }
                    }

                    MostrarMensaje("Producto actualizado correctamente.", false);
                }
                else
                {
                    producto.Imagenes = new List<ProductoImagen>();
                    producto.IdProducto = negocio.Agregar(producto);
                    MostrarMensaje("Producto creado correctamente.", false);

                    if (fileImagen.HasFile)
                    {
                        HttpFileCollection archivos = Request.Files;
                        ImagenNegocio imagenNegocio = new ImagenNegocio();
                        
                        for (int i = 0; i < archivos.Count; i++)
                        {
                            HttpPostedFile archivo = archivos[i];
                            if (archivo != null && archivo.ContentLength > 0 && !string.IsNullOrEmpty(archivo.FileName))
                            {
                                string nombreArchivo = GuardarImagenArchivo(archivo, producto.IdProducto);
                                if (!string.IsNullOrEmpty(nombreArchivo))
                                {
                                    imagenNegocio.Agregar(producto.IdProducto, nombreArchivo);
                                }
                            }
                        }
                    }
                }

                Response.AddHeader("Refresh", "2;url=Productos.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar: " + ex.Message, true);
            }
        }

        private string ValidarImagenArchivo(HttpPostedFile archivo)
        {
            try
            {
                string extension = Path.GetExtension(archivo.FileName).ToLower();
                string[] extensionesPermitidas = { ".jpg", ".jpeg", ".png", ".gif" };
                
                if (!extensionesPermitidas.Contains(extension))
                {
                    return "Formato de imagen no v&aacute;lido. Use JPG, PNG o GIF.";
                }

                if (archivo.ContentLength > 2 * 1024 * 1024)
                {
                    return "La imagen es demasiado grande. M&aacute;ximo 2MB.";
                }

                return null;
            }
            catch (Exception ex)
            {
                return "Error al validar la imagen: " + ex.Message;
            }
        }

        private string GuardarImagenArchivo(HttpPostedFile archivo, int idProducto)
        {
            try
            {
                byte[] imagenBytes = new byte[archivo.ContentLength];
                archivo.InputStream.Position = 0;
                archivo.InputStream.Read(imagenBytes, 0, imagenBytes.Length);

                string extension = Path.GetExtension(archivo.FileName).ToLower();
                string carpetaImagenes = Server.MapPath("~/assets/img/productos/");
                if (!Directory.Exists(carpetaImagenes))
                {
                    Directory.CreateDirectory(carpetaImagenes);
                }

                string nombreArchivo = $"producto_{idProducto}_{DateTime.Now.Ticks}_{Guid.NewGuid().ToString().Substring(0, 8)}{extension}";
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

        protected void repImagenesActuales_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "EliminarImagen")
            {
                try
                {
                    int idImagen = Convert.ToInt32(e.CommandArgument);
                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    imagenNegocio.Eliminar(idImagen);

                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        int idProducto = int.Parse(Request.QueryString["id"]);
                        CargarProducto(idProducto);
                        MostrarMensaje("Imagen eliminada correctamente.", false);
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al eliminar la imagen: " + ex.Message, true);
                }
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

