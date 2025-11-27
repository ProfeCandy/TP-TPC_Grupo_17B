<%@ Page Title="Nueva Contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RestablecerPassword.aspx.cs" Inherits="Frontend.RestablecerPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-12 col-md-8 col-lg-5">
                
                <div class="card border-0 shadow-lg rounded-4">
                    
                    <asp:Panel ID="pnlRestablecer" runat="server" DefaultButton="btnCambiar" CssClass="card-body p-5">
                        
                        <div class="text-center mb-4">
                            <h3 class="fw-bold text-danger text-uppercase">Nueva Contraseña</h3>
                            <p class="text-muted small">Ingresá tu nueva clave segura.</p>
                        </div>

                        <asp:Label ID="lblMensaje" runat="server" Visible="false" CssClass="d-block alert alert-info text-center mb-4"></asp:Label>

                        <div class="mb-3">
                            <div class="form-floating">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Placeholder="Nueva Contraseña" TextMode="Password"></asp:TextBox>
                                <label>Nueva Contraseña</label>
                            </div>
                            <%--Validacion Pass--%>
                            <asp:RequiredFieldValidator ControlToValidate="txtPassword" runat="server" Display="None" ErrorMessage="La contraseña es obligatoria." />
                            <asp:RegularExpressionValidator ControlToValidate="txtPassword" runat="server" Display="None" ErrorMessage="La contraseña nueva debe tener al menos 6 caracteres." ValidationExpression="^.{6,}$" />
                            <asp:RegularExpressionValidator ControlToValidate="txtPassword" runat="server" Display="None" ErrorMessage="La contraseña nueva debe tener al menos una mayúscula." ValidationExpression="^.*[A-Z].*$" />
                            <asp:RegularExpressionValidator ControlToValidate="txtPassword" runat="server" Display="None" ErrorMessage="La contraseña nueva debe tener al menos un número." ValidationExpression="^.*[0-9].*$" />
                        </div>

                        <div class="mb-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtConfirmar" runat="server" CssClass="form-control" Placeholder="Repetir Contraseña" TextMode="Password"></asp:TextBox>
                                <label>Repetir Contraseña</label>
                            </div>
                             <%--Validacion Repetir Pass--%>
                            <asp:RequiredFieldValidator ControlToValidate="txtConfirmar" runat="server" Display="None" ErrorMessage="Repetir contraseña es obligatorio." />
                            <asp:CompareValidator ControlToValidate="txtConfirmar" ControlToCompare="txtPassword" runat="server" 
                                Display="None" ErrorMessage="Las contraseñas no coinciden." Operator="Equal" />
                        </div>

                        <div class="text-center mb-3">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger small text-start" HeaderText="Errores:" />
                        </div>

                        <div class="d-grid gap-2 mb-4">
                            <asp:Button ID="btnCambiar" runat="server" Text="RESTABLECER" OnClick="btnCambiar_Click" CssClass="btn btn-danger btn-lg fw-bold" />
                        </div>

                    </asp:Panel>
                </div>

            </div>
        </div>
    </div>
</asp:Content>