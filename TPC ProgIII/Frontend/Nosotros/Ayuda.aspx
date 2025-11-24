<%@ Page Title="Ayuda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ayuda.aspx.cs" Inherits="Frontend.Ayuda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">Centro de Ayuda</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Inicio.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">Ayuda</li>
                </ol>
            </nav>
        </div>
    </div>

    <!-- Contenido Principal -->
    <div class="container mb-5">
        <div class="row justify-content-center">
            <div class="col-lg-10">
                <div class="card shadow border-0 p-5">
                    <!-- Introducción -->
                    <div class="text-center mb-5">
                        <h2 class="fw-bold mb-3">&iquest;C&oacute;mo podemos ayudarte?</h2>
                        <p class="text-secondary fs-5">
                            Estamos aqu&iacute; para resolver todas tus dudas y brindarte el mejor servicio posible.
                        </p>
                    </div>

                    <!-- Preguntas Frecuentes -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-4">
                            <i class="bi bi-question-circle me-2"></i>Preguntas Frecuentes
                        </h3>

                        <div class="accordion" id="accordionAyuda">
                            <!-- FAQ 1 -->
                            <div class="accordion-item mb-3 border rounded">
                                <h2 class="accordion-header" id="headingOne">
                                    <button class="accordion-button collapsed fw-semibold" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                                        &iquest;C&oacute;mo puedo realizar una compra?
                                    </button>
                                </h2>
                                <div id="collapseOne" class="accordion-collapse collapse" aria-labelledby="headingOne" data-bs-parent="#accordionAyuda">
                                    <div class="accordion-body text-secondary">
                                        Para realizar una compra, primero debes registrarte en nuestro sitio web. Una vez registrado, 
                                        puedes navegar por nuestro cat&aacute;logo de productos, agregar los art&iacute;culos que deseas 
                                        a tu carrito y proceder al checkout. Si tienes alguna duda sobre un producto, no dudes en contactarnos.
                                    </div>
                                </div>
                            </div>

                            <!-- FAQ 2 -->
                            <div class="accordion-item mb-3 border rounded">
                                <h2 class="accordion-header" id="headingTwo">
                                    <button class="accordion-button collapsed fw-semibold" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                        &iquest;Qu&eacute; m&eacute;todos de pago aceptan?
                                    </button>
                                </h2>
                                <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#accordionAyuda">
                                    <div class="accordion-body text-secondary">
                                        Aceptamos diversos m&eacute;todos de pago incluyendo tarjetas de cr&eacute;dito y d&eacute;bito, 
                                        transferencias bancarias y efectivo en nuestras sucursales. Para m&aacute;s informaci&oacute;n sobre 
                                        los m&eacute;todos de pago disponibles, puedes contactarnos directamente.
                                    </div>
                                </div>
                            </div>

                            <!-- FAQ 3 -->
                            <div class="accordion-item mb-3 border rounded">
                                <h2 class="accordion-header" id="headingThree">
                                    <button class="accordion-button collapsed fw-semibold" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                        &iquest;Hacen env&iacute;os a domicilio?
                                    </button>
                                </h2>
                                <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree" data-bs-parent="#accordionAyuda">
                                    <div class="accordion-body text-secondary">
                                        S&iacute;, realizamos env&iacute;os a domicilio dentro de nuestra zona de cobertura. 
                                        Los costos y tiempos de entrega var&iacute;an seg&uacute;n la ubicaci&oacute;n. 
                                        Puedes consultar la disponibilidad de env&iacute;o durante el proceso de compra o contactarnos 
                                        para m&aacute;s detalles.
                                    </div>
                                </div>
                            </div>

                            <!-- FAQ 4 -->
                            <div class="accordion-item mb-3 border rounded">
                                <h2 class="accordion-header" id="headingFour">
                                    <button class="accordion-button collapsed fw-semibold" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                                        &iquest;Puedo retirar mi pedido en una sucursal?
                                    </button>
                                </h2>
                                <div id="collapseFour" class="accordion-collapse collapse" aria-labelledby="headingFour" data-bs-parent="#accordionAyuda">
                                    <div class="accordion-body text-secondary">
                                        Por supuesto. Ofrecemos la opci&oacute;n de retiro en nuestras sucursales. 
                                        Una vez que tu pedido est&eacute; listo, recibir&aacute;s una notificaci&oacute;n para que puedas 
                                        retirarlo en el horario de atenci&oacute;n. Puedes ver nuestras sucursales en la 
                                        <a href="Sucursales.aspx" class="text-danger text-decoration-none">p&aacute;gina de Sucursales</a>.
                                    </div>
                                </div>
                            </div>

                            <!-- FAQ 5 -->
                            <div class="accordion-item mb-3 border rounded">
                                <h2 class="accordion-header" id="headingFive">
                                    <button class="accordion-button collapsed fw-semibold" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFive" aria-expanded="false" aria-controls="collapseFive">
                                        &iquest;Cu&aacute;l es la pol&iacute;tica de devoluciones?
                                    </button>
                                </h2>
                                <div id="collapseFive" class="accordion-collapse collapse" aria-labelledby="headingFive" data-bs-parent="#accordionAyuda">
                                    <div class="accordion-body text-secondary">
                                        Aceptamos devoluciones dentro de los 30 d&iacute;as posteriores a la compra, siempre que el producto 
                                        est&eacute; en su estado original y con su empaque. Para iniciar una devoluci&oacute;n, 
                                        contacta con nuestro equipo de atenci&oacute;n al cliente.
                                    </div>
                                </div>
                            </div>

                            <!-- FAQ 6 -->
                            <div class="accordion-item mb-3 border rounded">
                                <h2 class="accordion-header" id="headingSix">
                                    <button class="accordion-button collapsed fw-semibold" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSix" aria-expanded="false" aria-controls="collapseSix">
                                        &iquest;C&oacute;mo puedo rastrear mi pedido?
                                    </button>
                                </h2>
                                <div id="collapseSix" class="accordion-collapse collapse" aria-labelledby="headingSix" data-bs-parent="#accordionAyuda">
                                    <div class="accordion-body text-secondary">
                                        Una vez que tu pedido haya sido procesado y enviado, recibir&aacute;s un n&uacute;mero de seguimiento 
                                        por correo electr&oacute;nico. Puedes usar este n&uacute;mero para rastrear el estado de tu env&iacute;o 
                                        en tu cuenta o contactarnos directamente.
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>

                    <!-- Información de Contacto -->
                    <section class="mb-5">
                        <h3 class="fw-bold text-danger mb-4">
                            <i class="bi bi-telephone me-2"></i>&iquest;Necesitas m&aacute;s ayuda?
                        </h3>
                        <div class="row g-4">
                            <div class="col-md-6">
                                <div class="card border-0 bg-light p-4 h-100">
                                    <h5 class="fw-bold mb-3">
                                        <i class="bi bi-envelope text-danger me-2"></i>Env&iacute;anos un mensaje
                                    </h5>
                                    <p class="text-secondary mb-3">
                                        Completa nuestro formulario de contacto y te responderemos lo antes posible.
                                    </p>
                                    <a href="Contacto.aspx" class="btn btn-danger">Ir a Contacto</a>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="card border-0 bg-light p-4 h-100">
                                    <h5 class="fw-bold mb-3">
                                        <i class="bi bi-telephone text-danger me-2"></i>Ll&aacute;manos
                                    </h5>
                                    <p class="text-secondary mb-2">
                                        <strong>Leguizam&oacute;n:</strong> 0299 448-1628<br />
                                        <strong>R&iacute;o Negro:</strong> 0299 447-0670<br />
                                        <strong>Cipolletti:</strong> 0299 477-8352
                                    </p>
                                    <p class="text-muted small mb-0">Horario: 09:00 a 18:00</p>
                                </div>
                            </div>
                        </div>
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

