using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Frontend.Dashboard_client
{
    public partial class ConfiguracionProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Usuarios/Login.aspx");
                return;
            }

            Usuario user = (Usuario)Session["usuario"];
            
            // Solo Admin y Vendedor pueden acceder
            if (user.Rol == null || (user.Rol.NombreRol.ToLower() != "administrador" && user.Rol.NombreRol.ToLower() != "vendedor"))
            {
                Response.Redirect("~/Dashboard_client/Perfil.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarCategorias();
                CargarMarcas();
            }
        }

        private void CargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            List<Categoria> categorias = negocio.Listar();
            repCategorias.DataSource = categorias;
            repCategorias.DataBind();
        }

        private void CargarMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            List<Marca> marcas = negocio.Listar();
            repMarcas.DataSource = marcas;
            repMarcas.DataBind();
        }

        protected void btnGuardarNuevaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNuevaCategoria.Text))
                {
                    pnlMensajeModalCategoria.Visible = true;
                    pnlMensajeModalCategoria.CssClass = "alert alert-danger mb-0";
                    lblMensajeModalCategoria.Text = "El nombre de la categor&iacute;a es obligatorio.";
                    return;
                }

                Categoria nuevaCategoria = new Categoria();
                nuevaCategoria.Descripcion = txtNuevaCategoria.Text.Trim();

                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.Agregar(nuevaCategoria);

                txtNuevaCategoria.Text = "";
                pnlMensajeModalCategoria.Visible = true;
                pnlMensajeModalCategoria.CssClass = "alert alert-success mb-0";
                lblMensajeModalCategoria.Text = "Categor&iacute;a creada correctamente.";

                CargarCategorias();

                ClientScript.RegisterStartupScript(this.GetType(), "cerrarModalCategoria", 
                    "setTimeout(function() { var modal = bootstrap.Modal.getInstance(document.getElementById('modalNuevaCategoria')); if (modal) modal.hide(); }, 1500);", true);
            }
            catch (Exception ex)
            {
                pnlMensajeModalCategoria.Visible = true;
                pnlMensajeModalCategoria.CssClass = "alert alert-danger mb-0";
                lblMensajeModalCategoria.Text = "Error al crear la categor&iacute;a: " + ex.Message;
            }
        }

        protected void btnGuardarNuevaMarca_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNuevaMarca.Text))
                {
                    pnlMensajeModalMarca.Visible = true;
                    pnlMensajeModalMarca.CssClass = "alert alert-danger mb-0";
                    lblMensajeModalMarca.Text = "El nombre de la marca es obligatorio.";
                    return;
                }

                Marca nuevaMarca = new Marca();
                nuevaMarca.Descripcion = txtNuevaMarca.Text.Trim();

                MarcaNegocio negocio = new MarcaNegocio();
                negocio.Agregar(nuevaMarca);

                txtNuevaMarca.Text = "";
                pnlMensajeModalMarca.Visible = true;
                pnlMensajeModalMarca.CssClass = "alert alert-success mb-0";
                lblMensajeModalMarca.Text = "Marca creada correctamente.";

                CargarMarcas();

                ClientScript.RegisterStartupScript(this.GetType(), "cerrarModalMarca", 
                    "setTimeout(function() { var modal = bootstrap.Modal.getInstance(document.getElementById('modalNuevaMarca')); if (modal) modal.hide(); }, 1500);", true);
            }
            catch (Exception ex)
            {
                pnlMensajeModalMarca.Visible = true;
                pnlMensajeModalMarca.CssClass = "alert alert-danger mb-0";
                lblMensajeModalMarca.Text = "Error al crear la marca: " + ex.Message;
            }
        }

        protected void repCategorias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem item = e.Item;
            HiddenField hfIdCategoria = (HiddenField)item.FindControl("hfIdCategoria");
            Label lblCategoriaNombre = (Label)item.FindControl("lblCategoriaNombre");
            TextBox txtCategoriaEdit = (TextBox)item.FindControl("txtCategoriaEdit");
            LinkButton btnEditarCategoria = (LinkButton)item.FindControl("btnEditarCategoria");
            LinkButton btnGuardarCategoriaEdit = (LinkButton)item.FindControl("btnGuardarCategoriaEdit");
            LinkButton btnCancelarCategoriaEdit = (LinkButton)item.FindControl("btnCancelarCategoriaEdit");

            int idCategoria = int.Parse(hfIdCategoria.Value);

            if (e.CommandName == "Editar")
            {
                lblCategoriaNombre.Visible = false;
                txtCategoriaEdit.Visible = true;
                txtCategoriaEdit.CssClass = "form-control form-control-sm";
                btnEditarCategoria.Visible = false;
                btnGuardarCategoriaEdit.Visible = true;
                btnCancelarCategoriaEdit.Visible = true;
            }
            else if (e.CommandName == "Guardar")
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtCategoriaEdit.Text))
                    {
                        lblMensajeCategoria.Text = "El nombre no puede estar vac&iacute;o.";
                        lblMensajeCategoria.CssClass = "alert alert-danger";
                        lblMensajeCategoria.Visible = true;
                        return;
                    }

                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = idCategoria;
                    categoria.Descripcion = txtCategoriaEdit.Text.Trim();

                    CategoriaNegocio negocio = new CategoriaNegocio();
                    negocio.Modificar(categoria);

                    lblMensajeCategoria.Text = "Categor&iacute;a actualizada correctamente.";
                    lblMensajeCategoria.CssClass = "alert alert-success";
                    lblMensajeCategoria.Visible = true;

                    CargarCategorias();
                }
                catch (Exception ex)
                {
                    lblMensajeCategoria.Text = "Error al actualizar la categor&iacute;a: " + ex.Message;
                    lblMensajeCategoria.CssClass = "alert alert-danger";
                    lblMensajeCategoria.Visible = true;
                }
            }
            else if (e.CommandName == "Cancelar")
            {
                CargarCategorias();
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    negocio.Eliminar(idCategoria);

                    lblMensajeCategoria.Text = "Categor&iacute;a eliminada correctamente.";
                    lblMensajeCategoria.CssClass = "alert alert-success";
                    lblMensajeCategoria.Visible = true;

                    CargarCategorias();
                }
                catch (Exception ex)
                {
                    lblMensajeCategoria.Text = "Error al eliminar la categor&iacute;a: " + ex.Message;
                    lblMensajeCategoria.CssClass = "alert alert-danger";
                    lblMensajeCategoria.Visible = true;
                }
            }
        }

        protected void repMarcas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem item = e.Item;
            HiddenField hfIdMarca = (HiddenField)item.FindControl("hfIdMarca");
            Label lblMarcaNombre = (Label)item.FindControl("lblMarcaNombre");
            TextBox txtMarcaEdit = (TextBox)item.FindControl("txtMarcaEdit");
            LinkButton btnEditarMarca = (LinkButton)item.FindControl("btnEditarMarca");
            LinkButton btnGuardarMarcaEdit = (LinkButton)item.FindControl("btnGuardarMarcaEdit");
            LinkButton btnCancelarMarcaEdit = (LinkButton)item.FindControl("btnCancelarMarcaEdit");

            int idMarca = int.Parse(hfIdMarca.Value);

            if (e.CommandName == "Editar")
            {
                lblMarcaNombre.Visible = false;
                txtMarcaEdit.Visible = true;
                txtMarcaEdit.CssClass = "form-control form-control-sm";
                btnEditarMarca.Visible = false;
                btnGuardarMarcaEdit.Visible = true;
                btnCancelarMarcaEdit.Visible = true;
            }
            else if (e.CommandName == "Guardar")
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtMarcaEdit.Text))
                    {
                        lblMensajeMarca.Text = "El nombre no puede estar vac&iacute;o.";
                        lblMensajeMarca.CssClass = "alert alert-danger";
                        lblMensajeMarca.Visible = true;
                        return;
                    }

                    Marca marca = new Marca();
                    marca.IdMarca = idMarca;
                    marca.Descripcion = txtMarcaEdit.Text.Trim();

                    MarcaNegocio negocio = new MarcaNegocio();
                    negocio.Modificar(marca);

                    lblMensajeMarca.Text = "Marca actualizada correctamente.";
                    lblMensajeMarca.CssClass = "alert alert-success";
                    lblMensajeMarca.Visible = true;

                    CargarMarcas();
                }
                catch (Exception ex)
                {
                    lblMensajeMarca.Text = "Error al actualizar la marca: " + ex.Message;
                    lblMensajeMarca.CssClass = "alert alert-danger";
                    lblMensajeMarca.Visible = true;
                }
            }
            else if (e.CommandName == "Cancelar")
            {
                CargarMarcas();
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    negocio.Eliminar(idMarca);

                    lblMensajeMarca.Text = "Marca eliminada correctamente.";
                    lblMensajeMarca.CssClass = "alert alert-success";
                    lblMensajeMarca.Visible = true;

                    CargarMarcas();
                }
                catch (Exception ex)
                {
                    lblMensajeMarca.Text = "Error al eliminar la marca: " + ex.Message;
                    lblMensajeMarca.CssClass = "alert alert-danger";
                    lblMensajeMarca.Visible = true;
                }
            }
        }
    }
}

