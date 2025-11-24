<%@ Page Title="Recuperar Contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarPassword.aspx.cs" Inherits="Frontend.RecuperarPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-12 col-md-8 col-lg-5">
                
                <div class="card border-0 shadow-lg rounded-4">
                    
                    <asp:Panel ID="pnlRecuperar" runat="server" DefaultButton="btnEnviar" CssClass="card-body p-5">
                        
                        <div class="text-center mb-4">
                            <h3 class="fw-bold text-danger text-uppercase">Recuperar Cuenta</h3>
                            <p class="text-muted small">Ingresá tu email y te enviaremos las instrucciones para restablecer tu contraseña.</p>
                        </div>

                        <asp:Label ID="lblMensaje" runat="server" Visible="false" CssClass="d-block alert alert-info text-center mb-4"></asp:Label>

                        <div class="form-floating mb-4">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="name@example.com" TextMode="Email"></asp:TextBox>
                            <label for="txtEmail">Correo Electrónico</label>
                            
                            <asp:RequiredFieldValidator ErrorMessage="El email es requerido." ControlToValidate="txtEmail" runat="server" 
                                CssClass="text-danger small" Display="Dynamic" />
                            <asp:RegularExpressionValidator ErrorMessage="Formato de email inválido." ControlToValidate="txtEmail" runat="server" 
                                ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="d-grid gap-2 mb-4">
                            <asp:Button ID="btnEnviar" runat="server" Text="ENVIAR CORREO" OnClick="btnEnviar_Click" CssClass="btn btn-danger btn-lg fw-bold" />
                        </div>

                        <div class="text-center">
                            <a href="Login.aspx" class="text-decoration-none text-secondary small">Volver al Login</a>
                        </div>

                    </asp:Panel>
                </div>

            </div>
        </div>
    </div>
</asp:Content>