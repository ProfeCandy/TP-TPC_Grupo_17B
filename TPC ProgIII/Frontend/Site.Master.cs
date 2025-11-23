using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_ProgIII
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMenuCategorias();
            }

            ActualizarEstadoUsuario();
        }
        private void ActualizarEstadoUsuario()
        {
            if (Session["usuario"] != null)
            {
                Usuario user = (Usuario)Session["usuario"];
                lblUser.Text = user.Nombre;

                pnlLogueado.Visible = true; 
                pnlNoLogueado.Visible = false;
                
                // Mostrar opción de Configuración solo si es admin
                PlaceHolder pnlAdmin = (PlaceHolder)pnlLogueado.FindControl("pnlAdmin");
                if (pnlAdmin != null)
                {
                    if (user.Rol != null && user.Rol.NombreRol.ToLower() == "admin")
                    {
                        pnlAdmin.Visible = true;
                    }
                    else
                    {
                        pnlAdmin.Visible = false;
                    }
                }
            }
            else
            {
                lblUser.Text = "Cuenta";

                pnlLogueado.Visible = false;  
                pnlNoLogueado.Visible = true; 
            }
            if (Session["carrito"] != null)
                lblCantidadCarrito.Text = "1";
            else
                lblCantidadCarrito.Text = "0";
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Inicio.aspx");
        }
        private void CargarMenuCategorias()
        {

            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                
                repCategorias.DataSource = negocio.Listar();
                repCategorias.DataBind();
            }
            catch (Exception)
            {

            }
        }

    }
}