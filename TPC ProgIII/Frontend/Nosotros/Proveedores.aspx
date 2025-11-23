<%@ Page Title="Proveedores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_ProgIII.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">Proveedores</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Default.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">Proveedores</li>
                </ol>
            </nav>
        </div>
    </div>

    <!-- Contenido Principal -->
    <div class="container mb-5">
        <div class="card shadow border-0 p-5">
            
            <div class="row align-items-center g-5">
                <!-- Columna Texto -->
                <div class="col-lg-6">
                    <p class="text-secondary mb-4">
                        Gracias a la confianza y respaldo que nuestros proveedores nos brindan d&iacute;a a d&iacute;a, hemos consolidado ser referentes en el rubro en la regi&oacute;n.
                    </p>
                    <p class="text-secondary mb-5">
                        Esta confianza y respaldo, nos permiti&oacute; ir sumando l&iacute;neas y nuevos proveedores con el correr de los a&ntilde;os que, a su vez, nos empodera para seguir consolidando esta actitud de crecimiento.
                    </p>

                    <div class="mt-4">
                        <!-- Placeholder para el logo DISTRYSER -->
                        <img src="../assets/img/lg_distry/DISTRYSER_MARCA.png" alt="Distryser Logo" class="img-fluid" style="max-width: 250px;" onerror="this.onerror=null;this.src='https://placehold.co/250x80/fff/000?text=DISTRYSER';" />
                    </div>
                </div>

                <!-- Columna Estadísticas (Bubbles) -->
                <div class="col-lg-6">
                    <div class="row g-4 justify-content-center">
                        
                        <!-- Bubble 1 (+ de 25 años) -->
                        <div class="col-md-6 d-flex justify-content-center">
                            <div class="bg-light rounded-4 p-4 d-flex flex-column justify-content-center align-items-start w-100 shadow-sm" style="border-bottom-left-radius: 50px !important; border-top-right-radius: 50px !important; min-height: 140px;">
                                <h3 class="fw-bold mb-0 text-dark">+ de 25 a&ntilde;os</h3>
                                <span class="text-danger fw-bold small">en el mercado</span>
                            </div>
                        </div>

                        <!-- Bubble 2 (+ de 5000 ventas) -->
                        <div class="col-md-6 d-flex justify-content-center" style="margin-top: 3rem;">
                            <div class="bg-light rounded-4 p-4 d-flex flex-column justify-content-center align-items-start w-100 shadow-sm" style="border-bottom-left-radius: 50px !important; border-top-right-radius: 50px !important; min-height: 140px;">
                                <h3 class="fw-bold mb-0 text-dark">+ de 5000 ventas</h3>
                                <span class="text-danger fw-bold small">mensuales</span>
                            </div>
                        </div>

                        <!-- Bubble 3 (+ de 60 líneas) -->
                        <div class="col-md-6 d-flex justify-content-center">
                            <div class="bg-light rounded-4 p-4 d-flex flex-column justify-content-center align-items-start w-100 shadow-sm" style="border-bottom-left-radius: 50px !important; border-top-right-radius: 50px !important; min-height: 140px;">
                                <h3 class="fw-bold mb-0 text-dark">+ de 60 l&iacute;neas</h3>
                                <span class="text-danger fw-bold small">en equipo original y piezas de reposici&oacute;n</span>
                            </div>
                        </div>

                         <!-- Bubble 4 (+ de 40 proveedores) -->
                         <div class="col-md-6 d-flex justify-content-center" style="margin-top: 3rem;">
                            <div class="bg-light rounded-4 p-4 d-flex flex-column justify-content-center align-items-start w-100 shadow-sm" style="border-bottom-left-radius: 50px !important; border-top-right-radius: 50px !important; min-height: 140px;">
                                <h3 class="fw-bold mb-0 text-dark">+ de 40</h3>
                                <span class="text-danger fw-bold small">proveedores</span>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

