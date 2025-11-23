<%@ Page Title="Ingresar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Frontend.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-12 col-md-8 col-lg-6">
                
                <div class="card border-0 shadow-lg rounded-4">
                    <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnIngresar" CssClass="card-body p-5">
                        
                        <div class="text-center mb-4">
                            <h3 class="fw-bold text-danger text-uppercase">Bienvenido</h3>
                            <p class="text-muted">Ingresá tus datos para continuar</p>
                        </div>

                        <asp:Panel ID="panelError" runat="server" Visible="false" CssClass="alert alert-danger text-center mb-4">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </asp:Panel>

                        <%--/ Validacion de Mail--%>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="name@example.com" TextMode="Email"></asp:TextBox>
                            <label for="txtEmail">Correo Electrónico</label>
    
                            <asp:RequiredFieldValidator ErrorMessage="El email es requerido." ControlToValidate="txtEmail" runat="server" 
                                CssClass="text-danger small" Display="Dynamic" />
                            <asp:RegularExpressionValidator ErrorMessage="Formato de email inválido." ControlToValidate="txtEmail" runat="server" 
                                ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <%--/ Validacion de Pass--%>
                        <div class="form-floating mb-4">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Placeholder="Password" TextMode="Password"></asp:TextBox>
                            <label for="txtPassword">Contraseña</label>
    
                            <asp:RequiredFieldValidator ErrorMessage="La contraseña es requerida." ControlToValidate="txtPassword" runat="server" 
                                CssClass="text-danger small" Display="Dynamic" />
                        </div>
                        
                        <div class="mb-3 text-end">
                            <a href="RecuperarPassword.aspx" class="text-secondary text-decoration-none small">¿Olvidaste tu contraseña?</a>
                        </div>

                        <div class="d-grid gap-2 mb-4">
                            <asp:Button ID="btnIngresar" runat="server" Text="INGRESAR" OnClick="btnIngresar_Click" CssClass="btn btn-danger btn-lg fw-bold" />
                        </div>

                        <div class="text-center">
                            <a href="Register.aspx" class="text-decoration-none text-secondary small">
                                ¿No tenés cuenta? <span class="text-danger fw-bold">Registrate acá</span>
                            </a>
                        </div>

                    </asp:Panel>
                </div>

            </div>
        </div>
    </div>
</asp:Content>