<%@ Page Title="Confirmar Email" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmarEmail.aspx.cs" Inherits="Frontend.ConfirmarEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-12 col-md-8 col-lg-6">
                
                <div class="card border-0 shadow-lg rounded-4">
                    <div class="card-body p-5">
                        
                        <div class="text-center mb-4">
                            <div class="mb-3">
                                <i class="bi bi-envelope-check text-success" style="font-size: 4rem;"></i>
                            </div>
                            <h3 class="fw-bold text-danger text-uppercase">Confirmar Email</h3>
                        </div>

                        <asp:Panel ID="panelExito" runat="server" Visible="false">
                            <div class="alert alert-success text-center mb-4">
                                <h5 class="fw-bold mb-3">¡Email Confirmado!</h5>
                                <asp:Label ID="lblMensajeExito" runat="server"></asp:Label>
                            </div>
                            <div class="d-grid gap-2">
                                <a href="Login.aspx" class="btn btn-danger btn-lg fw-bold">Ir al Login</a>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="panelError" runat="server" Visible="false">
                            <div class="alert alert-danger text-center mb-4">
                                <h5 class="fw-bold mb-3">Error al Confirmar</h5>
                                <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                            </div>
                            <div class="d-grid gap-2">
                                <a href="Register.aspx" class="btn btn-outline-danger btn-lg fw-bold">Volver al Registro</a>
                                <a href="Login.aspx" class="btn btn-danger btn-lg fw-bold">Ir al Login</a>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="panelEspera" runat="server" Visible="false">
                            <div class="alert alert-info text-center mb-4">
                                <h5 class="fw-bold mb-3">Revisa tu Email</h5>
                                <asp:Label ID="lblMensajeEspera" runat="server"></asp:Label>
                            </div>
                            <div class="d-grid gap-2">
                                <a href="Login.aspx" class="btn btn-danger btn-lg fw-bold">Ir al Login</a>
                            </div>
                        </asp:Panel>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

