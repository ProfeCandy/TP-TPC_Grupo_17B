<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_ProgIII._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Modal Logout -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content p-4 text-center">
                <h3 class="fs-4 fw-bold mb-3">¿Querés salir de tu cuenta?</h3>
                <p>Has terminado tu sesión.</p>
                <div class="d-flex justify-content-around mt-4">
                    <a data-bs-dismiss="modal" class="btn btn-danger px-4">Salir</a>
                    <a data-bs-dismiss="modal" class="btn btn-outline-secondary px-4">Seguir en la cuenta</a>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Carrito -->
    <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
        <div class="offcanvas-header border-bottom">
            <h5 id="offcanvasRightLabel" class="mb-0">Orden de compra</h5>
            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
        </div>

        <div class="offcanvas-body">
            <ul class="list-group list-group-flush">
                <li class="list-group-item d-flex align-items-center justify-content-between">
                    <div class="d-flex align-items-center">
                        <img src="~/assets/images/product/baring.jpg" alt="Producto" class="img-fluid rounded me-3" style="width:70px; height:70px;" />
                        <div>
                            <p class="mb-1 fw-semibold">Nombre del producto</p>
                            <small class="text-muted">Cantidad: 1</small>
                            <div>
                                <a href="#" class="small text-danger text-decoration-none">
                                    <i class="bi bi-trash me-1"></i> Quitar
                                </a>
                            </div>
                        </div>
                    </div>
                    <span class="fw-bold">$500.000,50</span>
                </li>
            </ul>

            <div class="mt-4 d-flex justify-content-between">
                <a href="#" class="btn btn-outline-secondary">Seguir comprando</a>
                <a href="#" class="btn btn-danger">Actualizar pedido</a>
            </div>
        </div>
    </div>

    <!-- 🔽 Contenido principal de la página de inicio -->
    <!-- Hero con carrusel -->
    <section class="offer-banner pb-4" id="offer-banner">
        <div class="container-fluid p-0">
            <div id="heroCarousel" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">
                    <!-- Slide 1 -->
                    <div class="carousel-item active" style="height: 450px;">
                        <div class="overlay"></div>
                        <img src="assets/img/Banner1.png" class="d-block w-100 h-100 object-fit-cover" alt="Banner 1" />
                        <div class="carousel-caption d-none d-md-block pb-5">
                            <h1 class="display-3 fw-bold text-uppercase mb-3">Líderes en Autopartes</h1>
                            <p class="fs-4 mb-4">Encontrá todo lo que tu vehículo necesita con la mejor calidad del mercado.</p>
                            <a href="~/Productos.aspx" runat="server" class="btn btn-danger btn-lg px-5 rounded-pill">
                                Ver Catálogo <i class="bi bi-arrow-right ms-2"></i>
                            </a>
                        </div>
                    </div>
                    <!-- Slide 2 -->
                    <div class="carousel-item" style="height: 450px;">
                        <div class="overlay"></div>
                        <img src="assets/img/Banner2.png" class="d-block w-100 h-100 object-fit-cover" alt="Banner 2" />
                        <div class="carousel-caption d-none d-md-block pb-5">
                            <h1 class="display-3 fw-bold text-uppercase mb-3">Calidad Garantizada</h1>
                            <p class="fs-4 mb-4">Trabajamos con las mejores marcas para asegurar el rendimiento de tu auto.</p>
                            <a href="~/Sucursales.aspx" runat="server" class="btn btn-danger btn-lg px-5 rounded-pill">
                                Visitar Sucursales <i class="bi bi-arrow-right ms-2"></i>
                            </a>
                        </div>
                    </div>
                    <!-- Slide 3 -->
                    <div class="carousel-item" style="height: 450px;">
                        <div class="overlay"></div>
                        <img src="assets/img/Banner3.png" class="d-block w-100 h-100 object-fit-cover" alt="Banner 3" />
                        <div class="carousel-caption d-none d-md-block pb-5">
                            <h1 class="display-3 fw-bold text-uppercase mb-3">Atención Personalizada</h1>
                            <p class="fs-4 mb-4">Asesoramiento experto para talleres y particulares.</p>
                            <a href="~/Contacto.aspx" runat="server" class="btn btn-danger btn-lg px-5 rounded-pill">
                                Contactanos
                            </a>
                        </div>
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#heroCarousel" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Anterior</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#heroCarousel" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Siguiente</span>
                </button>
            </div>
        </div>
    </section>

</asp:Content>
