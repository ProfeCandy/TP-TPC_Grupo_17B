<%@ Page Title="Configuración" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="Frontend.Dashboard_client.Configuracion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="DashboardBody" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4 class="noto-sans fw-bold m-0">Configuración de cuenta</h4>
    </div>

    <div class="row">
        
        <div class="col-12 col-lg-7">
            <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4 p-4">
                <div class="border-bottom pb-3 mb-3">
                    <h5 class="fw-bold noto-sans"><i class="bi bi-calculator me-2 text-primary"></i>Preferencias de Venta</h5>
                    <small class="text-muted">Personaliza cómo ves los precios en el catálogo.</small>
                </div>

                <div class="mb-4">
                    <label class="form-label fw-bold small">Margen de ganancia sugerido (%)</label>
                    <div class="input-group mb-2">
                        <span class="input-group-text bg-light">%</span>
                        <asp:TextBox ID="txtGanancia" runat="server" CssClass="form-control" TextMode="Number" placeholder="Ej: 30"></asp:TextBox>
                    </div>
                    <small class="text-muted font-extra-small">
                        Calcularemos automáticamente el precio de venta sugerido sumando este porcentaje al costo.
                    </small>
                </div>

                <div class="d-flex justify-content-between align-items-center bg-light p-3 rounded">
                    <div>
                        <span class="fw-bold small d-block">Visualizar precios con IVA</span>
                        <small class="text-muted font-extra-small">Incluir el 21% en los listados.</small>
                    </div>
                    <div class="form-check form-switch">
                        <input class="form-check-input fs-4" type="checkbox" role="switch" id="chkIvaSwitch" runat="server" checked>
                    </div>
                </div>
            </div>

             <%--<div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4 p-4">
                <div class="border-bottom pb-3 mb-3">
                    <h5 class="fw-bold noto-sans"><i class="bi bi-download me-2 text-success"></i>Centro de Descargas</h5>
                    <small class="text-muted">Descarga listas actualizadas para tu negocio.</small>
                </div>
                
                <div class="d-flex justify-content-between align-items-center mb-3">
                    <div class="d-flex align-items-center">
                        <i class="bi bi-file-earmark-excel fs-3 text-success me-3"></i>
                        <div class="d-flex flex-column">
                            <span class="fw-bold small">Lista de Precios Completa</span>
                            <span class="font-extra-small text-muted">Formato .XLSX - Actualizado hoy</span>
                        </div>
                    </div>
                    <button type="button" class="btn btn-outline-secondary btn-sm"><i class="bi bi-download"></i> Descargar</button>
                </div>
                 
                <div class="d-flex justify-content-between align-items-center">
                    <div class="d-flex align-items-center">
                        <i class="bi bi-file-earmark-pdf fs-3 text-danger me-3"></i>
                        <div class="d-flex flex-column">
                            <span class="fw-bold small">Catálogo Ilustrado</span>
                            <span class="font-extra-small text-muted">Formato .PDF - 15MB</span>
                        </div>
                    </div>
                    <button type="button" class="btn btn-outline-secondary btn-sm"><i class="bi bi-download"></i> Descargar</button>
                </div>
            </div>--%>
        </div>

        <div class="col-12 col-lg-5">
            
            <%--<div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4 p-4">
                <div class="border-bottom pb-3 mb-3">
                    <h5 class="fw-bold noto-sans"><i class="bi bi-bell me-2 text-warning"></i>Notificaciones</h5>
                    <small class="text-muted">Elige qué correos quieres recibir.</small>
                </div>

                <div class="form-check mb-2">
                    <asp:CheckBox ID="chkNotifPedidos" runat="server" CssClass="form-check-input" Checked="true" />
                    <label class="form-check-label small ms-2" for="<%= chkNotifPedidos.ClientID %>">Cambios de estado en mis pedidos</label>
                </div>
                <div class="form-check mb-2">
                    <asp:CheckBox ID="chkNotifOfertas" runat="server" CssClass="form-check-input" />
                    <label class="form-check-label small ms-2" for="<%= chkNotifOfertas.ClientID %>">Ofertas y promociones semanales</label>
                </div>
                 <div class="form-check">
                    <asp:CheckBox ID="chkNotifStock" runat="server" CssClass="form-check-input" />
                    <label class="form-check-label small ms-2" for="<%= chkNotifStock.ClientID %>">Avisos de reposición de stock</label>
                </div>
            </div>--%>

            <div class="d-flex flex-column theme-border-radius border border-danger bg-light mb-4 my-4 p-4">
                <h6 class="fw-bold text-danger mb-3">Zona de peligro</h6>
                <p class="font-extra-small text-muted mb-3">
                    Si desactivas tu cuenta, no podrás realizar nuevos pedidos y perderás tu historial.
                </p>
                <asp:Button ID="btnDesactivar" runat="server" Text="Desactivar cuenta" CssClass="btn btn-outline-danger btn-sm fw-bold w-100" OnClick="btnDesactivar_Click" OnClientClick="return confirm('¿Estás seguro de que deseas desactivar tu cuenta?');" />
            </div>

        </div>

        <asp:Panel ID="pnlGestionRoles" runat="server" Visible="false">
            <div class="col-12">
                <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4 p-4">
                    <div class="border-bottom pb-3 mb-3">
                        <h5 class="fw-bold noto-sans"><i class="bi bi-envelope me-2 text-danger"></i>Configuración de Correos</h5>
                        <small class="text-muted">Gestiona los correos electrónicos del sistema.</small>
                    </div>

                    <asp:Label ID="lblMensajeEmail" runat="server" CssClass="alert" Visible="false" style="display: block;"></asp:Label>

                    <div class="mb-3">
                        <label class="form-label fw-bold small">Correo de Contacto (Se muestra en las páginas)</label>
                        <asp:TextBox ID="txtEmailContacto" runat="server" CssClass="form-control" TextMode="Email" placeholder="info@autoparts.com.ar"></asp:TextBox>
                        <small class="text-muted font-extra-small">Este correo se muestra en el footer y en la página de contacto.</small>
                    </div>

                    <div class="mb-3">
                        <label class="form-label fw-bold small">Correo de Envío (Desde donde se envían los emails)</label>
                        <asp:TextBox ID="txtEmailFrom" runat="server" CssClass="form-control" TextMode="Email" placeholder="noreply@autoparts.com.ar"></asp:TextBox>
                        <small class="text-muted font-extra-small">Este correo se usa para enviar emails automáticos del sistema.</small>
                    </div>

                    <div class="d-flex justify-content-end">
                        <asp:Button ID="btnGuardarEmails" runat="server" Text="Guardar Correos" CssClass="btn btn-danger" OnClick="btnGuardarEmails_Click" />
                    </div>
                </div>
            </div>

            <div class="col-12">
                <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4 p-4">
                    <div class="border-bottom pb-3 mb-3">
                        <h5 class="fw-bold noto-sans"><i class="bi bi-people me-2 text-danger"></i>Gestión de Roles de Usuarios</h5>
                        <small class="text-muted">Modifica los roles de los usuarios del sistema.</small>
                    </div>

                    <asp:Label ID="lblMensajeRoles" runat="server" CssClass="alert" Visible="false" style="display: block;"></asp:Label>

                    <div class="table-responsive">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Usuario</th>
                                    <th>Email</th>
                                    <th>Rol Actual</th>
                                    <th>Acción</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repUsuarios" runat="server" OnItemDataBound="repUsuarios_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <strong><%# Eval("Nombre") %> <%# Eval("Apellido") %></strong>
                                            </td>
                                            <td><%# Eval("Email") %></td>
                                            <td>
                                                <asp:HiddenField ID="hfIdUsuario" runat="server" Value='<%# Eval("IdUsuario") %>' />
                                                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select form-select-sm">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnGuardarRol" runat="server" 
                                                    Text="Actualizar" 
                                                    CssClass="btn btn-danger btn-sm" 
                                                    OnClick="btnGuardarRol_Click" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

        </asp:Panel>

        <div class="col-12">
            <div class="d-flex justify-content-between align-items-center mb-4">
                <asp:Button ID="Button1" runat="server" Text="Guardar cambios" CssClass="btn btn-primary fw-bold shadow-sm" OnClick="btnGuardarTodo_Click" />
            </div>
        </div>
    </div>
</asp:Content>
