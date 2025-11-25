<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPC_ProgIII.Inicio" %>

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
                            <a href="~/Productos/Productos.aspx" runat="server" class="btn btn-danger btn-lg px-5 rounded-pill">
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
                            <a href="~/Nosotros/Sucursales.aspx" runat="server" class="btn btn-danger btn-lg px-5 rounded-pill">
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
                            <a href="~/Nosotros/Contacto.aspx" runat="server" class="btn btn-danger btn-lg px-5 rounded-pill">
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

    <section class="py-5">
        <div class="container">
            <h2 class="text-center fw-bold text-uppercase mb-5">Navegación Rápida</h2>
            <div class="row g-4">
                <div class="col-12 col-md-6 col-lg-3">
                    <a href="~/Productos/Productos.aspx" runat="server" class="text-decoration-none">
                        <div class="card border-0 shadow-sm h-100 hover-shadow">
                            <div class="card-body text-center p-4">
                                <div class="bg-danger bg-opacity-10 rounded-circle d-inline-flex align-items-center justify-content-center mb-3" style="width: 80px; height: 80px;">
                                    <i class="bi bi-box-seam text-danger fs-1"></i>
                                </div>
                                <h4 class="card-title fw-bold mb-3">Productos</h4>
                                <p class="card-text text-muted mb-0">Explorá nuestro catálogo completo de autopartes y accesorios</p>
                            </div>
                            <div class="card-footer bg-transparent border-0 text-center pb-4">
                                <span class="text-danger fw-semibold">Ver catálogo <i class="bi bi-arrow-right"></i></span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-12 col-md-6 col-lg-3">
                    <a href="~/Noticias/Noticias.aspx" runat="server" class="text-decoration-none">
                        <div class="card border-0 shadow-sm h-100 hover-shadow">
                            <div class="card-body text-center p-4">
                                <div class="bg-danger bg-opacity-10 rounded-circle d-inline-flex align-items-center justify-content-center mb-3" style="width: 80px; height: 80px;">
                                    <i class="bi bi-newspaper text-danger fs-1"></i>
                                </div>
                                <h4 class="card-title fw-bold mb-3">Noticias</h4>
                                <p class="card-text text-muted mb-0">Mantenete al día con las últimas novedades del sector automotriz</p>
                            </div>
                            <div class="card-footer bg-transparent border-0 text-center pb-4">
                                <span class="text-danger fw-semibold">Ver noticias <i class="bi bi-arrow-right"></i></span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-12 col-md-6 col-lg-3">
                    <a href="~/Nosotros/Sucursales.aspx" runat="server" class="text-decoration-none">
                        <div class="card border-0 shadow-sm h-100 hover-shadow">
                            <div class="card-body text-center p-4">
                                <div class="bg-danger bg-opacity-10 rounded-circle d-inline-flex align-items-center justify-content-center mb-3" style="width: 80px; height: 80px;">
                                    <i class="bi bi-geo-alt-fill text-danger fs-1"></i>
                                </div>
                                <h4 class="card-title fw-bold mb-3">Sucursales</h4>
                                <p class="card-text text-muted mb-0">Encontrá la sucursal más cercana y visitanos</p>
                            </div>
                            <div class="card-footer bg-transparent border-0 text-center pb-4">
                                <span class="text-danger fw-semibold">Ver sucursales <i class="bi bi-arrow-right"></i></span>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-12 col-md-6 col-lg-3">
                    <a href="~/Nosotros/Contacto.aspx" runat="server" class="text-decoration-none">
                        <div class="card border-0 shadow-sm h-100 hover-shadow">
                            <div class="card-body text-center p-4">
                                <div class="bg-danger bg-opacity-10 rounded-circle d-inline-flex align-items-center justify-content-center mb-3" style="width: 80px; height: 80px;">
                                    <i class="bi bi-envelope-fill text-danger fs-1"></i>
                                </div>
                                <h4 class="card-title fw-bold mb-3">Contacto</h4>
                                <p class="card-text text-muted mb-0">Escribinos y te responderemos a la brevedad</p>
                            </div>
                            <div class="card-footer bg-transparent border-0 text-center pb-4">
                                <span class="text-danger fw-semibold">Contactanos <i class="bi bi-arrow-right"></i></span>
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </section>

    <section class="py-5 bg-light">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-12 col-lg-6 mb-4 mb-lg-0">
                    <h2 class="fw-bold text-uppercase mb-4">¿Por qué elegirnos?</h2>
                    <div class="d-flex gap-3 mb-3">
                        <div class="text-danger fs-4">
                            <i class="bi bi-check-circle-fill"></i>
                        </div>
                        <div>
                            <h5 class="fw-semibold mb-2">Calidad Garantizada</h5>
                            <p class="text-muted mb-0">Trabajamos con las mejores marcas del mercado para asegurar el mejor rendimiento de tu vehículo.</p>
                        </div>
                    </div>
                    <div class="d-flex gap-3 mb-3">
                        <div class="text-danger fs-4">
                            <i class="bi bi-check-circle-fill"></i>
                        </div>
                        <div>
                            <h5 class="fw-semibold mb-2">Atención Personalizada</h5>
                            <p class="text-muted mb-0">Asesoramiento experto para talleres y particulares, adaptado a tus necesidades.</p>
                        </div>
                    </div>
                    <div class="d-flex gap-3 mb-3">
                        <div class="text-danger fs-4">
                            <i class="bi bi-check-circle-fill"></i>
                        </div>
                        <div>
                            <h5 class="fw-semibold mb-2">Múltiples Sucursales</h5>
                            <p class="text-muted mb-0">Contamos con varias ubicaciones para brindarte la mejor atención cerca de tu zona.</p>
                        </div>
                    </div>
                    <div class="mt-4">
                        <a href="~/Nosotros/QuienesSomos.aspx" runat="server" class="btn btn-danger px-4 rounded-pill">
                            Conocé más sobre nosotros <i class="bi bi-arrow-right ms-2"></i>
                        </a>
                    </div>
                </div>
                <div class="col-12 col-lg-6">
                    <div class="bg-dark rounded p-4 text-white text-center">
                        <i class="bi bi-truck fs-1 text-danger mb-3 d-block"></i>
                        <h4 class="fw-bold mb-3">Envíos a Todo el País</h4>
                        <p class="mb-4">Realizamos envíos a todas las provincias con los mejores tiempos de entrega y seguimiento en tiempo real.</p>
                        <a href="~/Nosotros/Contacto.aspx" runat="server" class="btn btn-outline-light px-4 rounded-pill">
                            Consultar envíos
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="py-5 bg-light">
        <div class="container">
            <h2 class="text-center fw-bold text-uppercase mb-5">MARCAS PRINCIPALES</h2>
            <div id="marcasCarousel" class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <div class="row g-4 align-items-center justify-content-center">
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_chevrolet.jpg") %>' alt="Chevrolet" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_renault.jpg") %>' alt="Renault" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_kia.jpg") %>' alt="Kia" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_suzuki.jpg") %>' alt="Suzuki" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_mitsu.jpg") %>' alt="Mitsubishi" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_citroen.jpg") %>' alt="Citroën" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="row g-4 align-items-center justify-content-center">
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_toyota.jpg") %>' alt="Toyota" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_ford.jpg") %>' alt="Ford" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_volks.jpg") %>' alt="Volkswagen" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_fiat.jpg") %>' alt="Fiat" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_peugeot.jpg") %>' alt="Peugeot" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_nissan.jpg") %>' alt="Nissan" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="row g-4 align-items-center justify-content-center">
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_hyundai.jpg") %>' alt="Hyundai" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_jeep.jpg") %>' alt="Jeep" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_mbenz.jpg") %>' alt="Mercedes-Benz" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                            <div class="col-6 col-md-4 col-lg-3 col-xl-2 text-center">
                                <img src='<%= ResolveUrl("~/assets/img/marcas/logo_chery.jpg") %>' alt="Chery" class="img-fluid" style="max-height: 80px; object-fit: contain; filter: grayscale(0%); opacity: 1;" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="carousel-indicators position-relative mt-4 mb-0">
                    <button type="button" data-bs-target="#marcasCarousel" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                    <button type="button" data-bs-target="#marcasCarousel" data-bs-slide-to="1" aria-label="Slide 2"></button>
                    <button type="button" data-bs-target="#marcasCarousel" data-bs-slide-to="2" aria-label="Slide 3"></button>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
