<%@ Page Title="Detalle de Noticia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleNoticia.aspx.cs" Inherits="Frontend.DetalleNoticia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container my-5">
        <div class="row justify-content-center">
            <div class="col-lg-10">
                <!-- Navegación -->
                <nav aria-label="breadcrumb" class="mb-4">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="../Inicio.aspx" class="text-decoration-none text-danger">Inicio</a></li>
                        <li class="breadcrumb-item"><a href="Noticias.aspx" class="text-decoration-none text-danger">Noticias</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Detalle</li>
                    </ol>
                </nav>

                <!-- Encabezado -->
                <div class="mb-4">
                    <span class="badge bg-danger mb-2"><asp:Label ID="lblCategoria" runat="server"></asp:Label></span>
                    <h1 class="fw-bold display-5"><asp:Label ID="lblTitulo" runat="server"></asp:Label></h1>
                    <p class="text-muted">
                        <i class="bi bi-calendar-event me-2"></i>
                        <asp:Label ID="lblFecha" runat="server"></asp:Label>
                    </p>
                </div>

                <!-- Imagen (Opcional) -->
                <div class="mb-5 text-center">
                    <asp:Image ID="imgNoticia" runat="server" CssClass="img-fluid rounded shadow-sm" Visible="false" style="max-width: 100%; height: auto; display: block; margin: 0 auto;" />
                </div>

                <!-- Cuerpo -->
                <div class="fs-5 lh-lg text-secondary mb-5">
                    <asp:Label ID="lblCuerpo" runat="server"></asp:Label>
                </div>

                <!-- Botón Volver -->
                <div class="text-center mt-5 pt-4 border-top">
                    <a href="Noticias.aspx" class="btn btn-outline-secondary px-4">
                        <i class="bi bi-arrow-left me-2"></i>Volver a Noticias
                    </a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

