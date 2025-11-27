<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_ProgIII.Productos" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        
        <%-- Encabezado --%>
        <div class="row mb-4">
            <div class="col-12">
                <h2 class="text-uppercase text-danger fw-bold">Catálogo de Productos</h2>
                <p class="text-muted">Explorá nuestra variedad de repuestos y accesorios.</p>
                <%--Botones de Ordenamiento--%>
                <div class="col-md-5">
                    <div class="d-flex justify-content-md-end align-items-center gap-2">
                        <span class="fw-bold small text-muted">Ordenar:</span>
        
                        <div class="btn-group" role="group">
                            <asp:LinkButton ID="btnOrdenAZ" runat="server" CssClass="btn btn-outline-secondary btn-sm" 
                                OnClick="btnOrden_Click" CommandArgument="3" ToolTip="Nombre A-Z">
                                <i class="bi bi-sort-alpha-down"></i>
                            </asp:LinkButton>
            
                            <asp:LinkButton ID="btnOrdenZA" runat="server" CssClass="btn btn-outline-secondary btn-sm" 
                                OnClick="btnOrden_Click" CommandArgument="4" ToolTip="Nombre Z-A">
                                <i class="bi bi-sort-alpha-down-alt"></i>
                            </asp:LinkButton>

                            <asp:LinkButton ID="btnOrdenPrecioMenor" runat="server" CssClass="btn btn-outline-secondary btn-sm" 
                                OnClick="btnOrden_Click" CommandArgument="1" ToolTip="Menor Precio">
                                <i class="bi bi-sort-numeric-down"></i> $
                            </asp:LinkButton>

                            <asp:LinkButton ID="btnOrdenPrecioMayor" runat="server" CssClass="btn btn-outline-secondary btn-sm" 
                                OnClick="btnOrden_Click" CommandArgument="2" ToolTip="Mayor Precio">
                                <i class="bi bi-sort-numeric-up-alt"></i> $
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlAdminActions" runat="server" Visible="false" CssClass="mt-3 d-flex gap-2 flex-wrap">
                    <a href="FormularioProducto.aspx" class="btn btn-danger">
                        <i class="bi bi-plus-circle me-2"></i>Crear Nuevo Producto
                    </a>
                    <button type="button" class="btn btn-outline-primary" data-bs-toggle="modal" data-bs-target="#modalNuevaMarca">
                        <i class="bi bi-plus-circle me-2"></i>Nueva Marca
                    </button>
                    <button type="button" class="btn btn-outline-primary" data-bs-toggle="modal" data-bs-target="#modalNuevaCategoria">
                        <i class="bi bi-plus-circle me-2"></i>Nueva Categor&iacute;a
                    </button>

                </asp:Panel>
            </div>
        </div>

        <%-- Panel de Mensajes --%>
        <asp:Panel ID="panelMensajes" runat="server" Visible="false">
            <div class="alert alert-danger">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        </asp:Panel>

        <%-- Grilla de Productos --%>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            
            <%-- IMPORTANTE: Se agregó OnItemCommand para capturar el evento del botón --%>
            <asp:Repeater ID="repProductos" runat="server" OnItemCommand="repProductos_ItemCommand">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100 shadow-sm border-0">
                            
                            <img src='<%# Eval("ImagenPrincipal") != null ? ResolveUrl(Eval("ImagenPrincipal").ToString()) : "https://dummyimage.com/450x300/dee2e6/6c757d.jpg" %>' 
                             class="card-img-top p-3" 
                             alt='<%# Eval("NombreProducto") %>' 
                             style="height: 250px; object-fit: contain;" />
                            
                            <div class="card-body d-flex flex-column">
                                <h5 class="card-title fw-bold"><%# Eval("NombreProducto") %></h5>
                                <p class="card-text text-muted small text-truncate"><%# Eval("Descripcion") %></p>
                                
                                <div class="mt-auto">
                                    <hr />

                                    <div class="d-flex justify-content-between align-items-center mb-3">
                                        <span class="badge bg-secondary"><%# Eval("Marca.Descripcion") %></span>
                                        <h4 class="text-danger fw-bold m-0">$ <%# Eval("Precio", "{0:N0}") %></h4>
                                    </div>
                                    

                                    <div class="d-grid gap-2">
                                        <a href='<%# ResolveUrl("~/Productos/DetalleProducto.aspx?id=" + Eval("IdProducto")) %>' class="btn btn-danger">
                                            Ver Detalle
                                        </a>
                                    </div>

                                    <asp:Button ID="btnAgregar" runat="server" 
                                        Text="Agregar al Carrito" 
                                        CssClass="btn btn-outline-danger w-100 mt-2" 
                                        CommandName="Agregar" 
                                        CommandArgument='<%# Eval("IdProducto") %>' />

                                    <div class="mt-3 pt-3 border-top" runat="server" visible='<%# EsAdminOVendedor() %>'>
                                        <div class="mb-2">
                                            <small class="text-muted">Stock: <strong><%# Eval("Stock") %></strong></small>
                                        </div>
                                        <div class="d-flex gap-2">
                                            <a href="FormularioProducto.aspx?id=<%# Eval("IdProducto") %>" class="btn btn-warning btn-sm flex-grow-1">
                                                <i class="bi bi-pencil-square me-1"></i> Editar
                                            </a>
                                            <asp:LinkButton ID="btnAgregarStock" runat="server" CssClass="btn btn-info btn-sm flex-grow-1" 
                                                CommandArgument='<%# Eval("IdProducto") %>' CommandName="AgregarStock">
                                                <i class="bi bi-plus-circle me-1"></i> Stock
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm flex-grow-1" 
                                                CommandArgument='<%# Eval("IdProducto") %>' OnClick="btnEliminar_Click"
                                                OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este producto?');">
                                                <i class="bi bi-trash me-1"></i> Eliminar
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

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
                    <asp:Panel ID="pnlMensajeMarca" runat="server" Visible="false" CssClass="alert mb-0">
                        <asp:Label ID="lblMensajeMarca" runat="server"></asp:Label>
                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnGuardarMarca" runat="server" Text="Guardar Marca" CssClass="btn btn-primary" OnClick="btnGuardarMarca_Click" />
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
                    <asp:Panel ID="pnlMensajeCategoria" runat="server" Visible="false" CssClass="alert mb-0">
                        <asp:Label ID="lblMensajeCategoria" runat="server"></asp:Label>
                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnGuardarCategoria" runat="server" Text="Guardar Categor&iacute;a" CssClass="btn btn-primary" OnClick="btnGuardarCategoria_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Agregar Stock -->
    <div class="modal fade" id="modalAgregarStock" tabindex="-1" aria-labelledby="modalAgregarStockLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalAgregarStockLabel">Agregar Stock</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="txtCantidadStock" class="form-label">Cantidad a agregar</label>
                        <asp:TextBox ID="txtCantidadStock" runat="server" CssClass="form-control" TextMode="Number" min="1" placeholder="Ingresá la cantidad"></asp:TextBox>
                    </div>
                    <asp:Panel ID="pnlMensajeStock" runat="server" Visible="false" CssClass="alert mb-0">
                        <asp:Label ID="lblMensajeStock" runat="server"></asp:Label>
                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnGuardarStock" runat="server" Text="Agregar Stock" CssClass="btn btn-primary" OnClick="btnGuardarStock_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>