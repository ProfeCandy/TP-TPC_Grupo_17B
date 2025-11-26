<%@ Page Title="Formulario Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="TPC_ProgIII.FormularioProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">
                <asp:Label ID="lblTituloPagina" runat="server" Text="Crear Producto"></asp:Label>
            </h1>
        </div>
    </div>

    <div class="container mb-5">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="card shadow border-0 p-4">
                    
                    <asp:Panel ID="panelMensaje" runat="server" Visible="false" CssClass="alert mb-4">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </asp:Panel>

                    <div class="row g-3">
                        <div class="col-12">
                            <label for="txtNombre" class="form-label fw-semibold">Nombre del Producto</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingresá el nombre del producto"></asp:TextBox>
                        </div>

                        <div class="col-12">
                            <label for="txtDescripcion" class="form-label fw-semibold">Descripción</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Descripción del producto"></asp:TextBox>
                        </div>

                        <div class="col-md-6">
                            <label for="ddlMarca" class="form-label fw-semibold">Marca</label>
                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>

                        <div class="col-md-6">
                            <label for="ddlCategoria" class="form-label fw-semibold">Categoría</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>

                        <div class="col-12">
                            <label for="txtPrecio" class="form-label fw-semibold">Precio</label>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="0.00" TextMode="Number" step="0.01"></asp:TextBox>
                        </div>

                        <div class="col-12">
                            <label for="fileImagen" class="form-label fw-semibold">Imagen del Producto</label>
                            <asp:FileUpload ID="fileImagen" runat="server" CssClass="form-control" accept="image/*" />
                            <small class="text-muted">Formatos permitidos: JPG, PNG, GIF. Tamaño máximo: 2MB. Dimensiones máximas: 1920x1080px</small>
                            
                            <asp:Panel ID="pnlImagenActual" runat="server" Visible="false" CssClass="mt-3">
                                <label class="form-label fw-semibold">Imagen actual:</label>
                                <div class="mt-2">
                                    <asp:Image ID="imgActual" runat="server" CssClass="img-thumbnail" style="max-width: 300px; max-height: 200px;" />
                                </div>
                            </asp:Panel>
                        </div>

                        <div class="col-12 d-flex gap-2">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-danger" OnClick="btnGuardar_Click" />
                            <a href="Productos.aspx" class="btn btn-outline-secondary">Cancelar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

