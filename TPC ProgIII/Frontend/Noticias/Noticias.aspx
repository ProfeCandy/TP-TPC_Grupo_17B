<%@ Page Title="Noticias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="Frontend.Noticias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">Nuestras Noticias</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Inicio.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">Noticias</li>
                </ol>
            </nav>
        </div>
    </div>

    <!-- Contenido Principal -->
    <div class="container mb-5">
        <!-- Introducción -->
        <div class="text-center mb-5">
            <p class="fs-5 text-muted">Mantenete informado con las &uacute;ltimas novedades del mundo automotor y actualizaciones de nuestra empresa.</p>
            <asp:Panel ID="pnlAdminActions" runat="server" Visible="false" CssClass="mt-4">
                <a href="FormularioNoticia.aspx" class="btn btn-danger">
                    <i class="bi bi-plus-circle me-2"></i>Crear Nueva Noticia
                </a>
            </asp:Panel>
        </div>

        <!-- Lista de Noticias -->
        <div class="row g-4">
            
            <asp:Repeater ID="repNoticias" runat="server" OnItemDataBound="repNoticias_ItemDataBound">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card h-100 shadow-sm border-0 hover-shadow d-flex flex-column">
                            <!-- Imagen de la noticia -->
                            <div class="card-img-top" style="height: 250px; overflow: hidden; background-color: #f8f9fa; display: flex; align-items: center; justify-content: center;">
                                <asp:Literal ID="litImagen" runat="server"></asp:Literal>
                            </div>
                            <div class="card-body d-flex flex-column flex-grow-1">
                                <div class="mb-2">
                                    <span class="badge bg-danger"><%# Eval("Categoria") %></span>
                                    <small class="text-muted ms-2"><%# Convert.ToDateTime(Eval("FechaPublicacion")).ToString("dd MMM, yyyy") %></small>
                                </div>
                                <h4 class="card-title fw-bold mt-2"><%# Eval("Titulo") %></h4>
                                <p class="card-text text-secondary mt-3 flex-grow-1" style="display: -webkit-box; -webkit-line-clamp: 4; -webkit-box-orient: vertical; overflow: hidden; text-overflow: ellipsis;">
                                    <%# Eval("Cuerpo") %>
                                </p>
                                <div class="mt-auto">
                                    <a href="DetalleNoticia.aspx?id=<%# Eval("IdNoticia") %>" class="btn btn-outline-danger btn-sm mt-3">Leer m&aacute;s</a>

                                    <%-- Panel visible solo para Administradores --%>
                                    <div class="mt-3 pt-3 border-top d-flex gap-2" runat="server" visible='<%# EsAdmin() %>'>
                                        <a href="FormularioNoticia.aspx?id=<%# Eval("IdNoticia") %>" class="btn btn-warning btn-sm flex-grow-1">
                                            <i class="bi bi-pencil-square me-1"></i> Editar
                                        </a>
                                        <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm flex-grow-1" 
                                            CommandArgument='<%# Eval("IdNoticia") %>' OnClick="btnEliminar_Click"
                                            OnClientClick="return confirm('¿Est&aacute;s seguro de que deseas eliminar esta noticia?');">
                                            <i class="bi bi-trash me-1"></i> Eliminar
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>

