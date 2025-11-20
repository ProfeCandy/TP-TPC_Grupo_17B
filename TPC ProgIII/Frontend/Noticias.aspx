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
            
            <!-- Noticia 1 -->
            <div class="col-md-4">
                <div class="card h-100 shadow-sm border-0 hover-shadow">
                    <div class="card-body">
                        <div class="mb-2">
                            <span class="badge bg-danger">Novedades</span>
                            <small class="text-muted ms-2">20 Nov, 2023</small>
                        </div>
                        <h4 class="card-title fw-bold mt-2">Nueva sucursal en Cipolletti</h4>
                        <p class="card-text text-secondary mt-3">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                        </p>
                        <a href="#" class="btn btn-outline-danger btn-sm mt-3">Leer m&aacute;s</a>
                    </div>
                </div>
            </div>

            <!-- Noticia 2 -->
            <div class="col-md-4">
                <div class="card h-100 shadow-sm border-0 hover-shadow">
                    <div class="card-body">
                        <div class="mb-2">
                            <span class="badge bg-primary">Tecnolog&iacute;a</span>
                            <small class="text-muted ms-2">15 Nov, 2023</small>
                        </div>
                        <h4 class="card-title fw-bold mt-2">Avances en motores h&iacute;bridos</h4>
                        <p class="card-text text-secondary mt-3">
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                            Sed ut perspiciatis unde omnis iste natus error.
                        </p>
                        <a href="#" class="btn btn-outline-danger btn-sm mt-3">Leer m&aacute;s</a>
                    </div>
                </div>
            </div>

            <!-- Noticia 3 -->
            <div class="col-md-4">
                <div class="card h-100 shadow-sm border-0 hover-shadow">
                    <div class="card-body">
                        <div class="mb-2">
                            <span class="badge bg-success">Promociones</span>
                            <small class="text-muted ms-2">10 Nov, 2023</small>
                        </div>
                        <h4 class="card-title fw-bold mt-2">Descuentos de verano</h4>
                        <p class="card-text text-secondary mt-3">
                            At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.
                            Similique sunt in culpa qui officia deserunt mollitia animi.
                        </p>
                        <a href="#" class="btn btn-outline-danger btn-sm mt-3">Leer m&aacute;s</a>
                    </div>
                </div>
            </div>

        </div>

        <!-- Botón para cargar más (simulado) -->
        <div class="text-center mt-5">
            <button class="btn btn-secondary" type="button">Cargar m&aacute;s noticias</button>
        </div>
    </div>
</asp:Content>

