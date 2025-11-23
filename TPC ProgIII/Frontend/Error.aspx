<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Frontend.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex flex-column align-items-center justify-content-center py-5" style="min-height: 60vh;">
        <div class="text-center">
            <h1 class="display-1 fw-bold text-danger">404</h1>
            <h2 class="fs-1 fw-bold mb-3">P&aacute;gina no encontrada</h2>
            <p class="lead text-muted mb-5">
                Lo sentimos, la p&aacute;gina que est&aacute;s buscando no existe o ha sido movida.
            </p>
            <a href="Inicio.aspx" class="btn btn-danger btn-lg rounded-pill px-5">
                <i class="bi bi-arrow-left me-2"></i>Volver al Inicio
            </a>
        </div>
    </div>
</asp:Content>
