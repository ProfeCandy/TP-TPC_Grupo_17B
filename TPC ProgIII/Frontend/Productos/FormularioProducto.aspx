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
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingres&aacute; el nombre del producto"></asp:TextBox>
                        <%--Validacion Nombre--%>
                            <asp:RequiredFieldValidator ErrorMessage="Campo Obligatorio" ControlToValidate="txtNombre" runat="server" CssClass="text-danger small" Display="Dynamic" />                 
                        </div>

                        <div class="col-12">
                            <label for="txtDescripcion" class="form-label fw-semibold">Descripci&oacute;n</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Descripci&oacute;n del producto"></asp:TextBox>
                         <%--Validacion Descripcion--%>
                            <asp:RequiredFieldValidator ErrorMessage="Campo Obligatorio" ControlToValidate="txtDescripcion" runat="server" CssClass="text-danger small" Display="Dynamic" />                        
                        </div>

                        <div class="col-md-6">
                            <label for="ddlMarca" class="form-label fw-semibold">Marca</label>
                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>

                        <div class="col-md-6">
                            <label for="ddlCategoria" class="form-label fw-semibold">Categor&iacute;a</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>

                         <%--Validacion Precio--%>
                        <div class="col-md-6">
                            <label for="txtPrecio" class="form-label fw-semibold">Precio</label>    
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="0.00"></asp:TextBox>    
                            <%--<asp:RegularExpressionValidator ErrorMessage="Solo n�meros v�lidos (ej: 1200.50)" ControlToValidate="txtPrecio" 
                            runat="server" ValidationExpression="^[0-9]+([.,][0-9]{1,2})?$" 
                            CssClass="text-danger small d-block" Display="Dynamic" />--%>
                        </div>

                        <div class="col-md-6">
                            <label for="txtStock" class="form-label fw-semibold">Stock</label>    
                            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="0" TextMode="Number"></asp:TextBox>    
                        </div>

                        <div class="col-12">
                            <label for="fileImagen" class="form-label fw-semibold">Imágenes del Producto</label>
                            <asp:FileUpload ID="fileImagen" runat="server" CssClass="form-control" accept="image/*" AllowMultiple="true" />
                            <small class="text-muted">Formatos permitidos: JPG, PNG, GIF. Tama&ntilde;o m&aacute;ximo: 2MB por imagen. Podés seleccionar m&uacute;ltiples archivos.</small>
                            
                            <asp:Panel ID="pnlImagenesActuales" runat="server" Visible="false" CssClass="mt-4">
                                <label class="form-label fw-semibold mb-3">Imágenes actuales:</label>
                                <div class="d-flex flex-wrap gap-3">
                                    <asp:Repeater ID="repImagenesActuales" runat="server" OnItemCommand="repImagenesActuales_ItemCommand">
                                        <ItemTemplate>
                                            <div class="position-relative" style="width: 150px;">
                                                <asp:Image ID="imgProducto" runat="server" 
                                                    ImageUrl='<%# ResolveUrl(Eval("UrlImagen").ToString()) %>' 
                                                    CssClass="img-thumbnail w-100" 
                                                    style="height: 150px; object-fit: cover;" />
                                                <asp:LinkButton ID="btnEliminarImagen" runat="server" 
                                                    CommandArgument='<%# Eval("IdImagen") %>'
                                                    CommandName="EliminarImagen"
                                                    CssClass="btn btn-sm btn-danger position-absolute top-0 end-0 m-1"
                                                    OnClientClick="return confirm('¿Estás seguro de que deseas eliminar esta imagen?');"
                                                    style="z-index: 10;">
                                                    <i class="bi bi-x-lg"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
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

