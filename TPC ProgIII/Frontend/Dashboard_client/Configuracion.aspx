<%@ Page Title="Configuración" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="Frontend.Dashboard_client.Configuracion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="DashboardBody" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4 class="noto-sans fw-bold m-0">Configuración de cuenta</h4>
    </div>

    <div class="row">
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
