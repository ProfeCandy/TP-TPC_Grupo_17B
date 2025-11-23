<%@ Page Title="Detalle del Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Frontend.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .product-thumb {
            cursor: pointer;
            transition: transform 0.2s;
        }
        .product-thumb:hover {
            transform: scale(1.05);
            border-color: #dc3545;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container my-5">

        <!-- Panel de Mensajes de Error (panelMensajes, lblMensajeError) -->
        <div class="row">
            <div class="col-12">
                <asp:Panel ID="panelMensajes" runat="server" Visible="false" CssClass="alert alert-danger d-flex align-items-center" role="alert">
                    <i class="bi bi-exclamation-triangle-fill me-2"></i>
                    <div>
                        <asp:Label ID="lblMensajeError" runat="server" />
                    </div>
                </asp:Panel>
            </div>
        </div>

        <!-- Tarjeta Principal del Producto -->
        <div class="card border-0 shadow-lg overflow-hidden">
            <div class="card-body p-0">
                <div class="row g-0">

                    <!-- COLUMNA IZQUIERDA: Galería de Imágenes -->
                    <div class="col-lg-6 p-4 bg-light d-flex flex-column align-items-center justify-content-center">
                        
                        <!-- Imagen Principal -->
                        <div class="ratio ratio-1x1 w-100 mb-3 rounded shadow-sm bg-white" style="max-width: 500px;">
                            <asp:Image ID="imgProductoPrincipal" runat="server" CssClass="w-100 h-100 object-fit-contain p-3" AlternateText="Imagen del producto" />
                        </div>

                        <div class="d-flex flex-wrap justify-content-center gap-2">
                            <asp:Repeater ID="repImagenes" runat="server">
                                <ItemTemplate>
                                    <asp:Image runat="server" 
                                        ImageUrl='<%# Eval("UrlImagen") %>' 
                                        CssClass="img-thumbnail product-thumb" 
                                        Width="80" Height="80" 
                                        style="object-fit: cover;" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <!-- COLUMNA DERECHA -->
                    <div class="col-lg-6 p-5">
                        
                        <!-- Breadcrumb -->
                        <nav aria-label="breadcrumb" class="mb-3">
                            <ol class="breadcrumb small text-uppercase">
                                <li class="breadcrumb-item"><a href="../Default.aspx" class="text-decoration-none text-muted">Inicio</a></li>
                                <li class="breadcrumb-item"><a href="Productos.aspx" class="text-decoration-none text-muted">Productos</a></li>
                                <li class="breadcrumb-item active" aria-current="page">Detalle</li>
                            </ol>
                        </nav>

                        <!-- Marca (lblMarca) -->
                        <div class="mb-2">
                            <span class="badge bg-secondary text-uppercase tracking-wide">
                                <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
                            </span>
                        </div>

                        <!-- Título (lblNombreProducto) -->
                        <h1 class="display-5 fw-bold mb-3 text-dark">
                            <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre del Producto"></asp:Label>
                        </h1>

                        <!-- Precio (lblPrecio) -->
                        <div class="mb-4">
                            <h2 class="text-danger fw-bold">
                                <asp:Label ID="lblPrecio" runat="server" Text="$0.00"></asp:Label>
                            </h2>
                        </div>

                        <!-- Código (lblCodigo) -->
                        <p class="text-muted small mb-4">
                            Código de artículo: <strong class="text-dark"><asp:Label ID="lblCodigo" runat="server" /></strong>
                        </p>

                        <!-- Detalle (litDetalleCompleto) -->
                        <div class="mb-4 text-secondary" style="line-height: 1.8;">
                            <asp:Literal ID="litDetalleCompleto" runat="server"></asp:Literal>
                        </div>

                        <hr class="my-4 opacity-25" />

                        <!-- Botones de Acción -->
                        <div class="d-grid gap-2 d-md-flex justify-content-md-start">
                            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al Carrito" CssClass="btn btn-danger btn-lg px-5 rounded-pill" />
                            <a href="Productos.aspx" class="btn btn-outline-dark btn-lg px-4 rounded-pill">Volver</a>
                        </div>

                        <!-- Información Extra -->
                        <div class="row mt-5 text-muted small text-center">
                            <div class="col-4">
                                <i class="bi bi-truck fs-4 d-block mb-2"></i>
                                <span>Envío Gratis</span>
                            </div>
                            <div class="col-4">
                                <i class="bi bi-shield-check fs-4 d-block mb-2"></i>
                                <span>Garantía</span>
                            </div>
                            <div class="col-4">
                                <i class="bi bi-arrow-counterclockwise fs-4 d-block mb-2"></i>
                                <span>Devolución 30 días</span>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>