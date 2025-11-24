<%@ Page Title="Términos y Condiciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Terminos.aspx.cs" Inherits="Frontend.Terminos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">T&eacute;rminos y Condiciones</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Inicio.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">T&eacute;rminos y Condiciones</li>
                </ol>
            </nav>
        </div>
    </div>

    <!-- Contenido Principal -->
    <div class="container mb-5">
        <div class="row justify-content-center">
            <div class="col-lg-10">
                <div class="card shadow border-0 p-5">
                    <div class="mb-4">
                        <p class="text-muted">&Uacute;ltima actualizaci&oacute;n: <asp:Label ID="lblFechaActualizacion" runat="server" Text=""></asp:Label></p>
                    </div>

                    <!-- Sección 1 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">1. Aceptaci&oacute;n de los T&eacute;rminos</h3>
                        <p class="text-secondary lh-lg">
                            Al acceder y utilizar este sitio web, usted acepta estar sujeto a estos t&eacute;rminos y condiciones de uso. 
                            Si no est&aacute; de acuerdo con alguna parte de estos t&eacute;rminos, no debe utilizar nuestro sitio web.
                        </p>
                    </section>

                    <!-- Sección 2 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">2. Uso del Sitio Web</h3>
                        <p class="text-secondary lh-lg mb-3">
                            Usted se compromete a utilizar este sitio web de manera legal y de acuerdo con estos t&eacute;rminos. 
                            Est&aacute; prohibido:
                        </p>
                        <ul class="text-secondary lh-lg">
                            <li>Utilizar el sitio para cualquier prop&oacute;sito ilegal o no autorizado</li>
                            <li>Intentar acceder a &aacute;reas restringidas del sitio web</li>
                            <li>Interferir con el funcionamiento normal del sitio web</li>
                            <li>Reproducir, duplicar o copiar el contenido sin autorizaci&oacute;n</li>
                        </ul>
                    </section>

                    <!-- Sección 3 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">3. Productos y Servicios</h3>
                        <p class="text-secondary lh-lg">
                            Nos reservamos el derecho de modificar, suspender o discontinuar cualquier producto o servicio en cualquier momento 
                            sin previo aviso. Los precios y disponibilidad de los productos est&aacute;n sujetos a cambios sin notificaci&oacute;n previa.
                        </p>
                    </section>

                    <!-- Sección 4 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">4. Propiedad Intelectual</h3>
                        <p class="text-secondary lh-lg">
                            Todo el contenido de este sitio web, incluyendo pero no limitado a textos, gr&aacute;ficos, logotipos, iconos, 
                            im&aacute;genes y software, es propiedad de AutoParts y est&aacute; protegido por las leyes de propiedad intelectual.
                        </p>
                    </section>

                    <!-- Sección 5 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">5. Limitaci&oacute;n de Responsabilidad</h3>
                        <p class="text-secondary lh-lg">
                            AutoParts no ser&aacute; responsable de ning&uacute;n da&ntilde;o directo, indirecto, incidental o consecuente 
                            que resulte del uso o la imposibilidad de usar este sitio web o sus servicios.
                        </p>
                    </section>

                    <!-- Sección 6 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">6. Modificaciones</h3>
                        <p class="text-secondary lh-lg">
                            Nos reservamos el derecho de modificar estos t&eacute;rminos en cualquier momento. 
                            Las modificaciones entrar&aacute;n en vigor inmediatamente despu&eacute;s de su publicaci&oacute;n en el sitio web.
                        </p>
                    </section>

                    <!-- Sección 7 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">7. Contacto</h3>
                        <p class="text-secondary lh-lg">
                            Si tiene alguna pregunta sobre estos t&eacute;rminos y condiciones, puede contactarnos a trav&eacute;s de 
                            nuestra p&aacute;gina de <a href="Contacto.aspx" class="text-danger text-decoration-none">Contacto</a>.
                        </p>
                    </section>

                    <!-- Botón Volver -->
                    <div class="text-center mt-5 pt-4 border-top">
                        <a href="../Inicio.aspx" class="btn btn-outline-secondary px-4">
                            <i class="bi bi-arrow-left me-2"></i>Volver al Inicio
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

