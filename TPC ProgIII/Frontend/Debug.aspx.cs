using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Frontend
{
    public partial class Debug : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];

                // Mostrar panel de usuario logueado
                pnlUsuarioLogueado.Visible = true;
                pnlNoLogueado.Visible = false;

                // Rellenar datos del usuario
                lblNombre.Text = usuario.Nombre ?? "N/A";
                lblApellido.Text = usuario.Apellido ?? "N/A";
                lblEmail.Text = usuario.Email ?? "N/A";
                lblIdUsuario.Text = usuario.IdUsuario.ToString();

                // Rellenar datos del rol
                if (usuario.Rol != null)
                {
                    lblIdRol.Text = usuario.Rol.IdRol.ToString();
                    lblNombreRol.Text = usuario.Rol.NombreRol ?? "N/A";

                    // Mostrar si es admin
                    if (usuario.Rol.NombreRol.ToLower() == "admin" || usuario.Rol.NombreRol.ToLower() == "administrador")
                    {
                        pnlEsAdmin.Visible = true;
                        pnlNoAdmin.Visible = false;
                    }
                    else
                    {
                        pnlEsAdmin.Visible = false;
                        pnlNoAdmin.Visible = true;
                    }
                }
                else
                {
                    lblIdRol.Text = "Sin asignar";
                    lblNombreRol.Text = "Sin asignar";
                    pnlEsAdmin.Visible = false;
                    pnlNoAdmin.Visible = true;
                }
            }
            else
            {
                // Mostrar panel de no logueado
                pnlUsuarioLogueado.Visible = false;
                pnlNoLogueado.Visible = true;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}

