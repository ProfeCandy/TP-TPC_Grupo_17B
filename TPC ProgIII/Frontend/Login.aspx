<%@ Page Title="Ingresar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Frontend.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login">
        <div class="row justify-content-center">
            <div class="col-12 col-md-8 col-lg-5">
                
                <div class="card border-0 shadow-lg rounded-4">
                    <div class="card-body p-5">
                        
                        <div class="text-center mb-4">
                            <h3 class="fw-bold text-danger text-uppercase">Bienvenido</h3>
                            <p class="text-muted">Ingresá tus datos para continuar</p>
                        </div>

                        <asp:Panel ID="panelError" runat="server" Visible="false" CssClass="alert alert-danger text-center mb-4">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </asp:Panel>

                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="name@example.com" TextMode="Email"></asp:TextBox>
                            <label for="txtEmail">Correo Electrónico</label>
                        </div>

                        <div class="form-floating mb-4">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Placeholder="Password" TextMode="Password"></asp:TextBox>
                            <label for="txtPassword">Contraseña</label>
                        </div>

                        <div class="d-grid gap-2 mb-4">
                            <asp:Button ID="btnIngresar" runat="server" Text="INGRESAR" OnClick="btnIngresar_Click" CssClass="btn btn-danger btn-lg fw-bold" />
                        </div>

                        <div class="text-center">
                            <a href="Registro.aspx" class="text-decoration-none text-secondary small">¿No tenés cuenta? <span class="text-danger fw-bold">Registrate acá</span></a>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>