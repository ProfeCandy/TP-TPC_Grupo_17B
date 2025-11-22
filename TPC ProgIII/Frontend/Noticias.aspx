<%@ Page Title="Noticias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="Frontend.Noticias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">Nuestras Noticias</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Default.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">Noticias</li>
                </ol>
            </nav>
        </div>
    </div>

    <!-- Contenido Principal -->
    <div class="container mb-5">
        <!-- Introducción -->
        <div class="text-center mb-5">
            <p class="fs-5 text-muted">Mantenete informado con las &uacute;ltimas novedades del mundo automotor y actualizaciones de nuestra empresa.</p>
        </div>

        <!-- Lista de Noticias -->
        <div class="row g-4">
            
            <asp:Repeater ID="repNoticias" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card h-100 shadow-sm border-0 hover-shadow">
                            <div class="card-body">
                                <div class="mb-2">
                                    <span class="badge bg-danger"><%# Eval("Categoria") %></span>
                                    <small class="text-muted ms-2"><%# Convert.ToDateTime(Eval("FechaPublicacion")).ToString("dd MMM, yyyy") %></small>
                                </div>
                                <h4 class="card-title fw-bold mt-2"><%# Eval("Titulo") %></h4>
                                <p class="card-text text-secondary mt-3">
                                    <%# Eval("Cuerpo") %>
                                </p>
                                <a href="DetalleNoticia.aspx?id=<%# Eval("IdNoticia") %>" class="btn btn-outline-danger btn-sm mt-3">Leer m&aacute;s</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>

