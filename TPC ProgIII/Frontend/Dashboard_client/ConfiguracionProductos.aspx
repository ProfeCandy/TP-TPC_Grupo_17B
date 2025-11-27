<%@ Page Title="Configuración de Productos" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="ConfiguracionProductos.aspx.cs" Inherits="Frontend.Dashboard_client.ConfiguracionProductos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="DashboardBody" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4 class="noto-sans fw-bold m-0">Configuraci&oacute;n de Productos</h4>
    </div>

    <div class="row">
        <div class="col-12 col-lg-6">
            <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4 p-4">
                <div class="border-bottom pb-3 mb-3 d-flex justify-content-between align-items-center">
                    <div>
                        <h5 class="fw-bold noto-sans"><i class="bi bi-tags me-2 text-primary"></i>Gesti&oacute;n de Categor&iacute;as</h5>
                        <small class="text-muted">Administra las categor&iacute;as de productos.</small>
                    </div>
                    <button type="button" class="btn btn-primary btn-sm" data-bs-toggle="modal" data-bs-target="#modalNuevaCategoria">
                        <i class="bi bi-plus-circle"></i> Nueva
                    </button>
                </div>

                <asp:Label ID="lblMensajeCategoria" runat="server" CssClass="alert" Visible="false" style="display: block;"></asp:Label>

                <div class="table-responsive">
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repCategorias" runat="server" OnItemCommand="repCategorias_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCategoriaNombre" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                            <asp:TextBox ID="txtCategoriaEdit" runat="server" CssClass="form-control form-control-sm d-none" Text='<%# Eval("Descripcion") %>'></asp:TextBox>
                                            <asp:HiddenField ID="hfIdCategoria" runat="server" Value='<%# Eval("IdCategoria") %>' />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnEditarCategoria" runat="server" 
                                                CssClass="btn btn-warning btn-sm me-1" 
                                                CommandName="Editar"
                                                CommandArgument='<%# Eval("IdCategoria") %>'>
                                                <i class="bi bi-pencil"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnGuardarCategoriaEdit" runat="server" 
                                                CssClass="btn btn-success btn-sm me-1 d-none" 
                                                CommandName="Guardar"
                                                CommandArgument='<%# Eval("IdCategoria") %>'>
                                                <i class="bi bi-check"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnCancelarCategoriaEdit" runat="server" 
                                                CssClass="btn btn-secondary btn-sm me-1 d-none" 
                                                CommandName="Cancelar">
                                                <i class="bi bi-x"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnEliminarCategoria" runat="server" 
                                                CssClass="btn btn-danger btn-sm" 
                                                CommandName="Eliminar"
                                                CommandArgument='<%# Eval("IdCategoria") %>'
                                                OnClientClick="return confirm('¿Estás seguro de que deseas eliminar esta categoría?');">
                                                <i class="bi bi-trash"></i>
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <div class="col-12 col-lg-6">
            <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4 p-4">
                <div class="border-bottom pb-3 mb-3 d-flex justify-content-between align-items-center">
                    <div>
                        <h5 class="fw-bold noto-sans"><i class="bi bi-award me-2 text-success"></i>Gesti&oacute;n de Marcas</h5>
                        <small class="text-muted">Administra las marcas de productos.</small>
                    </div>
                    <button type="button" class="btn btn-success btn-sm" data-bs-toggle="modal" data-bs-target="#modalNuevaMarca">
                        <i class="bi bi-plus-circle"></i> Nueva
                    </button>
                </div>

                <asp:Label ID="lblMensajeMarca" runat="server" CssClass="alert" Visible="false" style="display: block;"></asp:Label>

                <div class="table-responsive">
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repMarcas" runat="server" OnItemCommand="repMarcas_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMarcaNombre" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                            <asp:TextBox ID="txtMarcaEdit" runat="server" CssClass="form-control form-control-sm d-none" Text='<%# Eval("Descripcion") %>'></asp:TextBox>
                                            <asp:HiddenField ID="hfIdMarca" runat="server" Value='<%# Eval("IdMarca") %>' />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnEditarMarca" runat="server" 
                                                CssClass="btn btn-warning btn-sm me-1" 
                                                CommandName="Editar"
                                                CommandArgument='<%# Eval("IdMarca") %>'>
                                                <i class="bi bi-pencil"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnGuardarMarcaEdit" runat="server" 
                                                CssClass="btn btn-success btn-sm me-1 d-none" 
                                                CommandName="Guardar"
                                                CommandArgument='<%# Eval("IdMarca") %>'>
                                                <i class="bi bi-check"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnCancelarMarcaEdit" runat="server" 
                                                CssClass="btn btn-secondary btn-sm me-1 d-none" 
                                                CommandName="Cancelar">
                                                <i class="bi bi-x"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnEliminarMarca" runat="server" 
                                                CssClass="btn btn-danger btn-sm" 
                                                CommandName="Eliminar"
                                                CommandArgument='<%# Eval("IdMarca") %>'
                                                OnClientClick="return confirm('¿Estás seguro de que deseas eliminar esta marca?');">
                                                <i class="bi bi-trash"></i>
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Nueva Categoría -->
    <div class="modal fade" id="modalNuevaCategoria" tabindex="-1" aria-labelledby="modalNuevaCategoriaLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalNuevaCategoriaLabel">Crear Nueva Categor&iacute;a</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="txtNuevaCategoria" class="form-label">Nombre de la Categor&iacute;a</label>
                        <asp:TextBox ID="txtNuevaCategoria" runat="server" CssClass="form-control" placeholder="Ej: Frenos, Motor, etc."></asp:TextBox>
                    </div>
                    <asp:Panel ID="pnlMensajeModalCategoria" runat="server" Visible="false" CssClass="alert mb-0">
                        <asp:Label ID="lblMensajeModalCategoria" runat="server"></asp:Label>
                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnGuardarNuevaCategoria" runat="server" Text="Guardar Categor&iacute;a" CssClass="btn btn-primary" OnClick="btnGuardarNuevaCategoria_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Nueva Marca -->
    <div class="modal fade" id="modalNuevaMarca" tabindex="-1" aria-labelledby="modalNuevaMarcaLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalNuevaMarcaLabel">Crear Nueva Marca</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="txtNuevaMarca" class="form-label">Nombre de la Marca</label>
                        <asp:TextBox ID="txtNuevaMarca" runat="server" CssClass="form-control" placeholder="Ej: Brembo, NGK, etc."></asp:TextBox>
                    </div>
                    <asp:Panel ID="pnlMensajeModalMarca" runat="server" Visible="false" CssClass="alert mb-0">
                        <asp:Label ID="lblMensajeModalMarca" runat="server"></asp:Label>
                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnGuardarNuevaMarca" runat="server" Text="Guardar Marca" CssClass="btn btn-success" OnClick="btnGuardarNuevaMarca_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

