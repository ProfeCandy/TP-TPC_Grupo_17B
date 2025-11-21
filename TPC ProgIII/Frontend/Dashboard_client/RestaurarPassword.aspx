<%@ Page Title="Restaurar Password" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="RestaurarPassword.aspx.cs" Inherits="Frontend.Dashboard_client.RestaurarPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardBody" runat="server">

    <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4">
        
        <div class="border-bottom p-3">
            <h4 class="noto-sans fw-bold m-0"><i class="bi bi-shield-lock me-2 theme-text-accent-one"></i>Cambiar Contraseña</h4>
        </div>

        <div class="p-4">
            <div class="row">
                
                <div class="col-12 col-lg-7">
                    
                    <asp:Panel ID="pnlMensaje" runat="server" Visible="false" CssClass="alert alert-danger mb-4" role="alert">
                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                    </asp:Panel>

                    <div class="mb-3">
                        <label for="txtPassActual" class="form-label fw-bold small">Contraseña actual</label>
                        <asp:TextBox ID="txtPassActual" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingresa tu contraseña actual"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="txtPassNueva" class="form-label fw-bold small">Nueva contraseña</label>
                        <asp:TextBox ID="txtPassNueva" runat="server" CssClass="form-control" TextMode="Password" placeholder="Mínimo 8 caracteres"></asp:TextBox>
                    </div>

                    <div class="mb-4">
                        <label for="txtPassConfirmar" class="form-label fw-bold small">Confirmar nueva contraseña</label>
                        <asp:TextBox ID="txtPassConfirmar" runat="server" CssClass="form-control" TextMode="Password" placeholder="Repite la nueva contraseña"></asp:TextBox>
                    </div>

                    <div class="d-grid gap-2 d-md-flex justify-content-md-start">
                        <asp:Button ID="btnCambiarPass" runat="server" Text="Actualizar contraseña" OnClick="btnCambiarPass_Click" CssClass="btn btn-primary fw-bold px-4" />
                    </div>

                </div>

                <div class="col-12 col-lg-5 mt-4 mt-lg-0">
                    <div class="bg-light p-3 rounded border">
                        <h6 class="fw-bold noto-sans mb-3 text-primary">Requisitos de seguridad</h6>
                        <ul class="small text-muted ps-3 mb-0">
                            <li class="mb-1">Mínimo 8 caracteres.</li>
                            <li class="mb-1">Al menos una letra mayúscula.</li>
                            <li class="mb-1">Al menos un número.</li>
                            <li>No puede ser igual a la anterior.</li>
                        </ul>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>