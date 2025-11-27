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
    public partial class Configuracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Usuarios/Login.aspx");
                return;
            }

            Usuario user = (Usuario)Session["usuario"];
            
            if (user.Rol == null || user.Rol.NombreRol.ToLower() != "administrador")
            {
                pnlGestionRoles.Visible = false;
            }
            else
            {
                pnlGestionRoles.Visible = true;
                if (!IsPostBack)
                {
                    CargarUsuarios();
                    CargarEmails();
                }
            }
        }

        private void CargarUsuarios()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Usuario> usuarios = negocio.Listar();
            repUsuarios.DataSource = usuarios;
            repUsuarios.DataBind();
        }

        protected void repUsuarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Usuario usuario = (Usuario)e.Item.DataItem;
                DropDownList ddlRol = (DropDownList)e.Item.FindControl("ddlRol");
                HiddenField hfIdUsuario = (HiddenField)e.Item.FindControl("hfIdUsuario");
                
                if (ddlRol != null && hfIdUsuario != null)
                {
                    hfIdUsuario.Value = usuario.IdUsuario.ToString();
                    
                    RolNegocio rolNegocio = new RolNegocio();
                    List<Rol> roles = rolNegocio.Listar();
                    
                    ddlRol.DataSource = roles;
                    ddlRol.DataTextField = "NombreRol";
                    ddlRol.DataValueField = "IdRol";
                    ddlRol.DataBind();
                    
                    if (usuario.Rol != null)
                    {
                        ddlRol.SelectedValue = usuario.Rol.IdRol.ToString();
                    }
                }
            }
        }

        protected void btnGuardarRol_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            
            HiddenField hfIdUsuario = (HiddenField)item.FindControl("hfIdUsuario");
            DropDownList ddlRol = (DropDownList)item.FindControl("ddlRol");
            
            if (hfIdUsuario != null && ddlRol != null)
            {
                try
                {
                    int idUsuario = int.Parse(hfIdUsuario.Value);
                    int idRol = int.Parse(ddlRol.SelectedValue);
                    
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario usuario = negocio.BuscarUsuarioPorId(idUsuario);
                    
                    if (usuario != null)
                    {
                        usuario.Rol = new Rol();
                        usuario.Rol.IdRol = idRol;
                        negocio.Modificar(usuario);
                        
                        lblMensajeRoles.Text = "Rol actualizado correctamente.";
                        lblMensajeRoles.CssClass = "alert alert-success";
                        lblMensajeRoles.Visible = true;
                        CargarUsuarios();
                    }
                }
                catch (Exception ex)
                {
                    lblMensajeRoles.Text = "Error al actualizar el rol: " + ex.Message;
                    lblMensajeRoles.CssClass = "alert alert-danger";
                    lblMensajeRoles.Visible = true;
                }
            }
        }

        protected void btnGuardarTodo_Click(object sender, EventArgs e)
        {
           
        }

        private void CargarEmails()
        {
            txtEmailContacto.Text = ConfigHelper.ObtenerEmailContacto();
            txtEmailFrom.Text = ConfigHelper.ObtenerEmailFrom();
        }

        protected void btnGuardarEmails_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEmailContacto.Text))
                {
                    ConfigHelper.ActualizarEmailContacto(txtEmailContacto.Text);
                }
                
                if (!string.IsNullOrEmpty(txtEmailFrom.Text))
                {
                    ConfigHelper.ActualizarEmailFrom(txtEmailFrom.Text);
                }

                lblMensajeEmail.Text = "Correos actualizados correctamente.";
                lblMensajeEmail.CssClass = "alert alert-success";
                lblMensajeEmail.Visible = true;
            }
            catch (Exception ex)
            {
                lblMensajeEmail.Text = "Error al actualizar los correos: " + ex.Message;
                lblMensajeEmail.CssClass = "alert alert-danger";
                lblMensajeEmail.Visible = true;
            }
        }
    }
}