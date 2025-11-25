<%@ Page Title="Crear Cuenta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Frontend.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-12 col-md-8 col-lg-6">
                
                <div class="card border-0 shadow-lg rounded-4">

                    <asp:Panel ID="pnlRegistro" runat="server" DefaultButton="btnRegistrarse" CssClass="card-body p-5">
                        
                        <div class="text-center mb-4">
                            <h3 class="fw-bold text-danger text-uppercase">Crear Cuenta</h3>
                            <p class="text-muted">Completá tus datos para unirte</p>
                        </div>

                        <asp:Panel ID="panelError" runat="server" Visible="false" CssClass="alert alert-danger text-center mb-4">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </asp:Panel>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <div class="form-floating">
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre"></asp:TextBox>
                                    <label for="txtNombre">Nombre</label>
                                    <%--Validaciones Nombre--%>
                                    <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="txtNombre" runat="server" CssClass="text-danger small" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtNombre" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />
                                </div>
                            </div>
                            
                            <div class="col-md-6 mb-3">
                                <div class="form-floating">
                                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Placeholder="Apellido"></asp:TextBox>
                                    <label for="txtApellido">Apellido</label>
                                    <%--Validacion Apellido--%>
                                    <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="txtApellido" runat="server" CssClass="text-danger small" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtApellido" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />
                                </div>
                            </div>
                        </div>

                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="name@example.com" TextMode="Email"></asp:TextBox>
                            <label for="txtEmail">Correo Electrónico</label>
                             <%--Validacion Email--%>
                            <asp:RequiredFieldValidator ErrorMessage="El email es requerido" ControlToValidate="txtEmail" runat="server" CssClass="text-danger small" Display="Dynamic" />
                            <asp:RegularExpressionValidator ErrorMessage="Formato inválido" ControlToValidate="txtEmail" runat="server" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="mb-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Placeholder="Password" TextMode="Password"></asp:TextBox>
                                <label for="txtPassword">Contraseña</label>
                            </div>

                            <%-- Validaciones de contraseña --%>
                            <asp:RequiredFieldValidator ControlToValidate="txtPassword" runat="server" Display="None" ErrorMessage="La contraseña es obligatoria." />
    
                            <asp:RegularExpressionValidator ControlToValidate="txtPassword" runat="server" Display="None" ErrorMessage="La contraseña debe tener al menos 6 caracteres." ValidationExpression="^.{6,}$" />
    
                            <asp:RegularExpressionValidator ControlToValidate="txtPassword" runat="server" Display="None" ErrorMessage="La contraseña debe tener al menos una mayúscula." ValidationExpression="^.*[A-Z].*$" />
    
                            <asp:RegularExpressionValidator ControlToValidate="txtPassword" runat="server" Display="None" ErrorMessage="La contraseña debe tener al menos un número." ValidationExpression="^.*[0-9].*$" />
                        </div>
                        <%--Prueba--%>
                        <div class="text-center mb-3">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                CssClass="alert alert-danger small text-start" 
                                HeaderText="Corrija los siguientes errores:" />
                        </div>

                        <div class="d-grid gap-2 mb-4">
                            <asp:Button ID="btnRegistrarse" runat="server" Text="CREAR CUENTA" OnClick="btnRegistrarse_Click" CssClass="btn btn-danger btn-lg fw-bold" />
                        </div>

                        <div class="text-center">
                            <a href="Login.aspx" class="text-decoration-none text-secondary small">&iquest;Ya ten&eacute;s cuenta? <span class="text-danger fw-bold">Ingres&aacute; ac&aacute;</span></a>
                        </div>

                    </asp:Panel>
                </div>

            </div>
        </div>
    </div>
</asp:Content>