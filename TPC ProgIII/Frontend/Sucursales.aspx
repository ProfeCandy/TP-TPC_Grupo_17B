<%@ Page Title="Sucursales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sucursales.aspx.cs" Inherits="TPC_ProgIII.Sucursales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">Sucursales</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Default.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">Sucursales</li>
                </ol>
            </nav>
        </div>
    </div>

    <!-- Título Centrado -->
    <div class="container text-center mb-5">
        <h2 class="fw-bold display-6">Nuestras sucursales:</h2>
    </div>

    <!-- Espacio para el Mapa (Placeholder) -->
    <div class="container-fluid p-0 mb-5">
        <div class="ratio ratio-21x9 bg-light border-top border-bottom">
            <div class="d-flex align-items-center justify-content-center text-muted">
                <div class="text-center">
                    <i class="bi bi-geo-alt fs-1"></i>
                    <p class="fs-5 mt-2">Mapa de Sucursales (Proximamente)</p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

