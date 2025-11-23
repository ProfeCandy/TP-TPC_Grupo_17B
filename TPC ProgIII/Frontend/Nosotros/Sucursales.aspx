<%@ Page Title="Sucursales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sucursales.aspx.cs" Inherits="Frontend.Sucursales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .cursor-pointer {
            cursor: pointer;
        }
        .card.active-branch {
            border: 2px solid #dc3545 !important; 
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">Sucursales</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Default.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">Sucursales</li>
                </ol>
            </nav>
        </div>
    </div>

    <!-- Título Centrado -->
    <div class="container text-center mb-5">
        <h2 class="fw-bold display-6">Encontr&aacute; tu sucursal m&aacute;s cercana</h2>
        <p class="text-muted fs-5">Visit&aacute; nuestros puntos de venta y recib&iacute; asesoramiento personalizado. <br /> <span class="small text-danger fw-bold">Hace clic en una sucursal para verla en el mapa.</span></p>
    </div>

    <!-- Listado de Sucursales -->
    <div class="container mb-5">
        <div class="row g-4 justify-content-center">
            <!-- Sucursal Cipolletti -->
            <div class="col-md-4">
                <div class="card h-100 shadow-sm border-0 hover-shadow cursor-pointer" onclick="changeMap('-38.94183,-67.99236', this)">
                    <div class="card-body text-center p-4">
                        <div class="bg-danger text-white rounded-circle d-inline-flex align-items-center justify-content-center mb-3" style="width: 60px; height: 60px;">
                            <i class="bi bi-geo fs-3"></i>
                        </div>
                        <h4 class="fw-bold mb-3">Cipolletti</h4>
                        <p class="text-muted mb-2"><i class="bi bi-geo-alt me-2 text-danger"></i>Miguel Mu&ntilde;oz 67</p>
                        <p class="text-muted mb-2"><i class="bi bi-telephone me-2 text-danger"></i>0299 477-8352</p>
                        <p class="small text-muted"><i class="bi bi-clock me-2 text-danger"></i>Lun-Vie: 8:00 - 18:00</p>
                    </div>
                </div>
            </div>

            <!-- Sucursal General Pacheco (Ficticia/UTN) -->
            <div class="col-md-4">
                <div class="card h-100 shadow-sm border-0 hover-shadow cursor-pointer" onclick="changeMap('Av. Hipólito Yrigoyen 288, General Pacheco, Buenos Aires, Argentina', this)">
                    <div class="card-body text-center p-4">
                        <div class="bg-danger text-white rounded-circle d-inline-flex align-items-center justify-content-center mb-3" style="width: 60px; height: 60px;">
                            <i class="bi bi-building fs-3"></i>
                        </div>
                        <h4 class="fw-bold mb-3">Gral. Pacheco (UTN)</h4>
                        <p class="text-muted mb-2"><i class="bi bi-geo-alt me-2 text-danger"></i>Av. Hip&oacute;lito Yrigoyen 288</p>
                        <p class="text-muted mb-2"><i class="bi bi-telephone me-2 text-danger"></i>(011) 4740-5040</p>
                        <p class="small text-muted"><i class="bi bi-clock me-2 text-danger"></i>Lun-Vie: 8:00 - 22:00</p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Mapa de Google Maps -->
    <div class="container-fluid p-0 mb-5">
        <div class="ratio ratio-21x9 bg-light border-top border-bottom shadow-sm">
            <iframe id="google-map" src="https://maps.google.com/maps?q=-38.94183,-67.99236&t=&z=15&ie=UTF8&iwloc=&output=embed" 
                style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
    </div>

    <script>
        function changeMap(address, element) {
            var map = document.getElementById('google-map');
            // Update map src with the new address query
            map.src = "https://maps.google.com/maps?q=" + encodeURIComponent(address) + "&t=&z=15&ie=UTF8&iwloc=&output=embed";

            // Remove active class from all cards
            var cards = document.querySelectorAll('.cursor-pointer');
            cards.forEach(function(card) {
                card.classList.remove('active-branch');
            });

            // Add active class to clicked card
            if(element) {
                element.classList.add('active-branch');
            }

            // Optional: Scroll to map
            map.scrollIntoView({ behavior: 'smooth', block: 'center' });
        }
    </script>

</asp:Content>
