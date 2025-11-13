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
        <div class="container">
            <div class="row">
                <!-- Carrusel principal -->
                <div class="col-12 col-lg-8 mb-4 mb-lg-0 mt-md-4">
                    <div id="heroCarousel" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner rounded-3 shadow">
                            <div class="carousel-item active">
                                <img src="assets/img/noticias/NOT_sport.webp" class="d-block w-100" alt="Slide 1" />
                                <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded-3 p-3">
                                    <h5 class="fw-bold text-white">Líderes en venta mayorista de autopartes</h5>
                                    <a href="~/Productos.aspx" runat="server" class="btn btn-danger btn-sm mt-2">
                                        Ver Catálogo <i class="bi bi-arrow-right ms-1"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <img src="assets/img/noticias/NOT_park.webp" class="d-block w-100" alt="Slide 2" />
                                <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded-3 p-3">
                                    <h5 class="fw-bold text-white">Calidad y confianza en cada repuesto</h5>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <img src="assets/img/noticias/noti_r21994.webp" class="d-block w-100" alt="Slide 3" />
                                <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded-3 p-3">
                                    <h5 class="fw-bold text-white">Atención personalizada a talleres y minoristas</h5>
                                </div>
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#heroCarousel" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon"></span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#heroCarousel" data-bs-slide="next">
                            <span class="carousel-control-next-icon"></span>
                        </button>
                    </div>
                </div>

                <!-- Cards laterales -->
                <div class="col-12 col-lg-4 mt-lg-4">
                    <div class="row g-3">
                        <div class="col-12">
                            <div class="card border-0 shadow-sm overflow-hidden">
                                <img src="assets/img/noticias/NOT_sport.webp" class="card-img-top" alt="Card 1" />
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="card border-0 shadow-sm overflow-hidden">
                                <img src="assets/img/noticias/NOT_park.webp" class="card-img-top" alt="Card 2" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

   <%-- <!-- Noticias -->
    <section class="news py-5" id="news">
        <div class="container">
            <div class="row mb-5 text-center">
                <div class="col">
                    <h2 class="fw-bold text-uppercase text-danger">Noticias</h2>
                    <p class="text-muted">Últimas novedades del sector automotor</p>
                </div>
            </div>

            <div class="row g-4">
                <div class="col-6 col-lg-3">
                    <div class="card border-0 shadow-sm h-100">
                        <img src="assets/img/noticias/noti_r21994.webp" class="card-img-top" alt="Noticia 1" />
                        <div class="card-body">
                            <small class="text-muted d-block mb-2"><i class="bi bi-calendar4-week me-1"></i>18 Marzo, 2024</small>
                            <h6 class="fw-bold">De colección</h6>
                            <p class="small text-muted">Nuevas piezas exclusivas para vehículos clásicos.</p>
                            <a href="#" class="btn btn-outline-danger btn-sm">Leer más</a>
                        </div>
                    </div>
                </div>

                <div class="col-6 col-lg-3">
                    <div class="card border-0 shadow-sm h-100">
                        <img src="assets/img/noticias/NOT_llavemec.webp" class="card-img-top" alt="Noticia 2" />
                        <div class="card-body">
                            <small class="text-muted d-block mb-2"><i class="bi bi-calendar4-week me-1"></i>24 Marzo, 2024</small>
                            <h6 class="fw-bold">Novedades motor</h6>
                            <p class="small text-muted">Actualizaciones en líneas de motores y periféricos.</p>
                            <a href="#" class="btn btn-outline-danger btn-sm">Leer más</a>
                        </div>
                    </div>
                </div>

                <div class="col-6 col-lg-3">
                    <div class="card border-0 shadow-sm h-100">
                        <img src="assets/img/noticias/NOT_park.webp" class="card-img-top" alt="Noticia 3" />
                        <div class="card-body">
                            <small class="text-muted d-block mb-2"><i class="bi bi-calendar4-week me-1"></i>27 Marzo, 2024</small>
                            <h6 class="fw-bold">Repuestos</h6>
                            <p class="small text-muted">Amplia variedad de componentes disponibles.</p>
                            <a href="#" class="btn btn-outline-danger btn-sm">Leer más</a>
                        </div>
                    </div>
                </div>

                <div class="col-6 col-lg-3">
                    <div class="card border-0 shadow-sm h-100">
                        <img src="assets/img/noticias/NOT_sport.webp" class="card-img-top" alt="Noticia 4" />
                        <div class="card-body">
                            <small class="text-muted d-block mb-2"><i class="bi bi-calendar4-week me-1"></i>31 Mayo, 2024</small>
                            <h6 class="fw-bold">Vehículos de lujo</h6>
                            <p class="small text-muted">Lanzamientos y accesorios para autos premium.</p>
                            <a href="#" class="btn btn-outline-danger btn-sm">Leer más</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>--%>

        <!-- Marcas -->
    <%--<section class="partner pb-5" id="partner">
        <div class="container">
            <div class="row my-5">
                <div class="col-12 pb-4 border-bottom">
                    <h3 class="fs-3 text-uppercase text-danger fw-bolder">Marcas top</h3>
                </div>
            </div>

            <div class="row align-items-center text-center g-3">
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_suzuki.webp" alt="Suzuki" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_mitsu.webp" alt="Mitsubishi" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_citroen.webp" alt="Citroën" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_chevrolet.webp" alt="Chevrolet" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_peugeot.webp" alt="Peugeot" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_jeep.webp" alt="Jeep" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_audi.webp" alt="Audi" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_chery.webp" alt="Chery" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_fiat.webp" alt="Fiat" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_toyota.webp" alt="Toyota" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_volks.webp" alt="Volkswagen" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_ford.webp" alt="Ford" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_nissan.webp" alt="Nissan" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_mbenz.webp" alt="Mercedes-Benz" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_hyundai.webp" alt="Hyundai" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_renault.webp" alt="Renault" class="img-fluid" />
                </div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2">
                    <img src="~/assets/img/marcas-logos/logo_kia.webp" alt="Kia" class="img-fluid" />
                </div>
            </div>
        </div>
    </section>--%>

    <!-- Footer -->
    <footer class="footer pt-4 bg-light border-top">
        <div class="container">
            <div class="row gy-4">
                <!-- Contacto -->
                <div class="col-12 col-md-6 col-lg-4">
                    <h3 class="fs-5 mb-4 mt-lg-4 text-uppercase fw-bold text-danger">Contactanos</h3>
                    <p class="small mb-2"><i class="bi bi-geo-alt-fill me-2"></i> UTN - Gral Pacheco, Buenos Aires</p>
                    <p class="small mb-2">Av. Hipolito Yrigoyen 288, Gral. Pacheco</p>
                    <p class="small mb-2"><i class="bi bi-telephone-fill me-2"></i> (011) 4740-5040</p>
                    <p class="small mb-2"><i class="bi bi-clock-fill me-2"></i> Lunes a Viernes 8:00 a 22:00 / Sábados 9:00 a 12:00</p>
                    <p class="small"><i class="bi bi-envelope-open-fill me-2"></i> info@autoparts.com.ar</p>
                </div>

                <!-- Enlaces -->
                <div class="col-12 col-md-6 col-lg-5">
                    <h3 class="fs-5 mb-4 mt-lg-4 text-uppercase fw-bold text-danger">Información</h3>
                    <div class="row">
                        <div class="col-6">
                            <ul class="list-unstyled small">
                                <li><a href="#" class="text-decoration-none text-dark">Envíos</a></li>
                                <li><a href="#" class="text-decoration-none text-dark">Privacidad</a></li>
                                <li><a href="#" class="text-decoration-none text-dark">Preguntas frecuentes</a></li>
                            </ul>
                        </div>
                        <div class="col-6">
                            <ul class="list-unstyled small">
                                <li><a href="#" class="text-decoration-none text-dark">Mi cuenta</a></li>
                                <li><a href="#" class="text-decoration-none text-dark">Historial</a></li>
                                <li><a href="#" class="text-decoration-none text-dark">Noticias</a></li>
                            </ul>
                        </div>
                    </div>
                </div>

                <!-- Logo y redes -->
                <div class="col-12 col-md-6 col-lg-3 text-center text-lg-start">
                    <img src="~/assets/img/lg_distry/distryser_marca__footer.webp" class="img-fluid mb-3" alt="Distribuidora AutoParts" />
                    <p class="small">Desde 1995, dedicados a la excelencia en autopartes con más de 15,000 productos y atención personalizada.</p>
                    <div class="mt-3">
                        <a href="#" class="text-dark fs-5 me-3"><i class="bi bi-facebook"></i></a>
                        <a href="#" class="text-dark fs-5 me-3"><i class="bi bi-instagram"></i></a>
                        <a href="#" class="text-dark fs-5 me-3"><i class="bi bi-linkedin"></i></a>
                    </div>
                </div>
            </div>
        </div>
        <div class="text-center py-3 border-top small bg-light mt-4">
            © 2025 UTN - AutoParts - Todos los derechos reservados
        </div>
    </footer>


</asp:Content>
