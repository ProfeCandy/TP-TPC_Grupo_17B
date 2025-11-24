<%@ Page Title="Política de Privacidad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Privacidad.aspx.cs" Inherits="Frontend.Privacidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">Pol&iacute;tica de Privacidad</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Inicio.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">Pol&iacute;tica de Privacidad</li>
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
                        <h3 class="fw-bold text-danger mb-3">1. Informaci&oacute;n que Recopilamos</h3>
                        <p class="text-secondary lh-lg mb-3">
                            Recopilamos informaci&oacute;n que usted nos proporciona directamente cuando:
                        </p>
                        <ul class="text-secondary lh-lg">
                            <li>Se registra en nuestro sitio web</li>
                            <li>Realiza una compra o solicita un servicio</li>
                            <li>Se comunica con nosotros a trav&eacute;s de formularios de contacto</li>
                            <li>Se suscribe a nuestro bolet&iacute;n informativo</li>
                        </ul>
                        <p class="text-secondary lh-lg mt-3">
                            Esta informaci&oacute;n puede incluir nombre, direcci&oacute;n de correo electr&oacute;nico, 
                            n&uacute;mero de tel&eacute;fono, direcci&oacute;n postal y otra informaci&oacute;n relevante.
                        </p>
                    </section>

                    <!-- Sección 2 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">2. Uso de la Informaci&oacute;n</h3>
                        <p class="text-secondary lh-lg mb-3">
                            Utilizamos la informaci&oacute;n recopilada para:
                        </p>
                        <ul class="text-secondary lh-lg">
                            <li>Procesar y completar sus pedidos</li>
                            <li>Comunicarnos con usted sobre su cuenta y pedidos</li>
                            <li>Enviarle informaci&oacute;n sobre productos y servicios que puedan ser de su inter&eacute;s</li>
                            <li>Mejorar nuestros servicios y experiencia del usuario</li>
                            <li>Cumplir con obligaciones legales y regulatorias</li>
                        </ul>
                    </section>

                    <!-- Sección 3 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">3. Protecci&oacute;n de Datos</h3>
                        <p class="text-secondary lh-lg">
                            Implementamos medidas de seguridad t&eacute;cnicas y organizativas apropiadas para proteger 
                            su informaci&oacute;n personal contra acceso no autorizado, alteraci&oacute;n, divulgaci&oacute;n o destrucci&oacute;n.
                        </p>
                    </section>

                    <!-- Sección 4 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">4. Compartir Informaci&oacute;n</h3>
                        <p class="text-secondary lh-lg">
                            No vendemos, alquilamos ni compartimos su informaci&oacute;n personal con terceros, excepto en los siguientes casos:
                        </p>
                        <ul class="text-secondary lh-lg">
                            <li>Con proveedores de servicios que nos ayudan a operar nuestro negocio</li>
                            <li>Cuando sea necesario para cumplir con la ley o proteger nuestros derechos</li>
                            <li>Con su consentimiento expl&iacute;cito</li>
                        </ul>
                    </section>

                    <!-- Sección 5 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">5. Cookies y Tecnolog&iacute;as Similares</h3>
                        <p class="text-secondary lh-lg">
                            Utilizamos cookies y tecnolog&iacute;as similares para mejorar su experiencia en nuestro sitio web, 
                            analizar el tr&aacute;fico y personalizar el contenido. Puede configurar su navegador para rechazar cookies, 
                            aunque esto puede afectar algunas funcionalidades del sitio.
                        </p>
                    </section>

                    <!-- Sección 6 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">6. Sus Derechos</h3>
                        <p class="text-secondary lh-lg mb-3">
                            Usted tiene derecho a:
                        </p>
                        <ul class="text-secondary lh-lg">
                            <li>Acceder a su informaci&oacute;n personal</li>
                            <li>Rectificar informaci&oacute;n inexacta o incompleta</li>
                            <li>Solicitar la eliminaci&oacute;n de sus datos</li>
                            <li>Oponerse al procesamiento de sus datos</li>
                            <li>Solicitar la portabilidad de sus datos</li>
                        </ul>
                    </section>

                    <!-- Sección 7 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">7. Cambios a esta Pol&iacute;tica</h3>
                        <p class="text-secondary lh-lg">
                            Nos reservamos el derecho de actualizar esta pol&iacute;tica de privacidad en cualquier momento. 
                            Le notificaremos sobre cambios significativos publicando la nueva pol&iacute;tica en esta p&aacute;gina.
                        </p>
                    </section>

                    <!-- Sección 8 -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-3">8. Contacto</h3>
                        <p class="text-secondary lh-lg">
                            Si tiene preguntas o inquietudes sobre esta pol&iacute;tica de privacidad o sobre el tratamiento 
                            de sus datos personales, puede contactarnos a trav&eacute;s de nuestra p&aacute;gina de 
                            <a href="Contacto.aspx" class="text-danger text-decoration-none">Contacto</a>.
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

