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
                            <label for="fileImagen" class="form-label fw-semibold">Imagen del Producto</label>
                            <asp:FileUpload ID="fileImagen" runat="server" CssClass="form-control" accept="image/*" />
                            <small class="text-muted">Formatos permitidos: JPG, PNG, GIF. Tama&ntilde;o m&aacute;ximo: 2MB.</small>
                            
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

