<%@ Page Title="Formulario Noticia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioNoticia.aspx.cs" Inherits="Frontend.FormularioNoticia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">
                <asp:Label ID="lblTituloPagina" runat="server" Text="Crear Noticia"></asp:Label>
            </h1>
        </div>
    </div>

    <!-- Contenido Principal -->
    <div class="container mb-5">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="card shadow border-0 p-4">
                    
                    <asp:Panel ID="panelMensaje" runat="server" Visible="false" CssClass="alert mb-4">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </asp:Panel>

                    <div class="row g-3">
                        <!-- T&iacute;tulo -->
                        <div class="col-12">
                            <label for="txtTitulo" class="form-label fw-semibold">T&iacute;tulo</label>
                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Ingres&aacute; el t&iacute;tulo de la noticia"></asp:TextBox>
                        </div>

                        <!-- Categor&iacute;a -->
                        <div class="col-12">
                            <label for="txtCategoria" class="form-label fw-semibold">Categor&iacute;a</label>
                            <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" placeholder="Ej: Tecnolog&iacute;a, Negocios"></asp:TextBox>
                        </div>

                        <!-- Cuerpo de la Noticia -->
                        <div class="col-12">
                            <label for="txtCuerpo" class="form-label fw-semibold">Cuerpo</label>
                            <asp:TextBox ID="txtCuerpo" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" placeholder="Escrib&iacute; el contenido de la noticia"></asp:TextBox>
                        </div>

                        <!-- Subir Imagen -->
                        <div class="col-12">
                            <label for="fileImagen" class="form-label fw-semibold">Imagen de la Noticia</label>
                            <asp:FileUpload ID="fileImagen" runat="server" CssClass="form-control" accept="image/*" />
                            <small class="text-muted">Formatos permitidos: JPG, PNG, GIF. Tama&ntilde;o m&aacute;ximo: 2MB. Dimensiones m&aacute;ximas: 1920x1080px</small>
                            
                            <!-- Vista previa de imagen actual -->
                            <asp:Panel ID="pnlImagenActual" runat="server" Visible="false" CssClass="mt-3">
                                <label class="form-label fw-semibold">Imagen actual:</label>
                                <div class="mt-2">
                                    <asp:Image ID="imgActual" runat="server" CssClass="img-thumbnail" style="max-width: 300px; max-height: 200px;" />
                                </div>
                            </asp:Panel>
                        </div>

                        <!-- Bot&oacute;nes -->
                        <div class="col-12 d-flex gap-2">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-danger" OnClick="btnGuardar_Click" />
                            <a href="Noticias.aspx" class="btn btn-outline-secondary">Cancelar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

