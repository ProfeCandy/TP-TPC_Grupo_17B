<%@ Page Title="Carrito de Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Frontend.store.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <main class="my-4">
        <div class="container">
            <asp:Panel ID="pnlCarritoConItems" runat="server">
                <div class="row">
                    
                    <div class="col-lg-8 mb-6 mb-md-0">
                        <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4">
                            
                            <div class="d-flex justify-content-between p-3 border-bottom align-items-center">
                                <span class="fs-4 fw-bold">Orden de compra&nbsp;
                                    <span class="fs-6 theme-text-accent-one">
                                        (<asp:Label ID="lblCantidadItems" runat="server" Text="0" /> Items)
                                    </span>
                                </span>
                                <span class="fw-bold">Total <i class="bi bi-currency-dollar"></i>
                                    <asp:Label ID="lblTotalHeader" runat="server" Text="0.00" />
                                </span>
                            </div>

                            <div class="d-flex flex-column justify-content-between p-3">
                                <div class="mb-3">
                                    
                                    <asp:Repeater ID="repCarrito" runat="server" OnItemCommand="RepeaterCarrito_ItemCommand">
                                        <ItemTemplate>
                                            <div class="border list-group-item p-3 mb-3">
                                                <div class="row align-items-center">
                                                    
                                                    <%-- img --%>
                                                    <div class="col-6 col-md-2">
                                                        <img src='<%# ResolveUrl(Eval("ImagenUrl").ToString()) %>' 
                                                             alt='<%# Eval("Nombre") %>' 
                                                             class="img-fluid" 
                                                             style="max-height: 80px; object-fit: contain;">
                                                    </div>

                                                    <%-- marca --%>
                                                    <div class="col-6 col-md-6 col-lg-5">
                                                        <a href='<%# ResolveUrl("~/Productos/DetalleProducto.aspx?id=" + Eval("IdProducto")) %>' class="text-reset">
                                                            <p class="mb-0 font-small fw-bold"><%# Eval("Nombre") %></p>
                                                            <small class="text-muted"><%# Eval("Marca") %></small>
                                                        </a>
                                                    </div>

                                                    <%-- btn restar --%>
                                                    <div class="col-6 col-md-3 col-lg-3 px-0 d-flex flex-column align-items-center justify-content-center">
                                                        <div class="input-group input-spinner d-inline-flex justify-content-center">
                                                            
                                                            <asp:LinkButton ID="btnRestar" runat="server" 
                                                                CssClass="button-minus fw-bold fs-5 btn bg-danger border border-1 border-black" 
                                                                CommandName="restar" 
                                                                CommandArgument='<%# Eval("IdProducto") %>'>
                                                                -
                                                            </asp:LinkButton>

                                                            <%-- text cantidad --%>
                                                            <input type="text" value='<%# Eval("Cantidad") %>' class=" col-4 text-center fw-bold fs-6 quantity-field form-control-sm form-input" readonly />

                                                            <%-- btn sumar --%>
                                                            <asp:LinkButton ID="btnSumar" runat="server" 
                                                                CssClass="button-plus fw-bold fs-5 btn bg-danger border border-1 border-black" 
                                                                CommandName="sumar" 
                                                                CommandArgument='<%# Eval("IdProducto") %>'>
                                                                +
                                                            </asp:LinkButton>
                                                        </div>

                                                        <div class="mt-2 small lh-1">
                                                            <asp:LinkButton ID="btnEliminar" runat="server" 
                                                                CssClass="text-decoration-none text-inherit" 
                                                                CommandName="eliminar" 
                                                                CommandArgument='<%# Eval("IdProducto") %>'>
                                                                <span class="me-1 align-middle"><i class="bi bi-trash"></i></span>
                                                                <span class="text-muted font-extra-small fw-bold">Quitar</span>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>

                                                    <div class="col-6 col-md-2 text-end">
                                                        <span class="fw-bold">$<%# Eval("SubTotal", "{0:N2}") %></span>
                                                    </div>

                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4">
                        <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4">
                            
                            <div class="d-flex justify-content-between p-3 border-bottom">
                                <span class="fs-4 fw-bold">Resumen Pedido</span>
                            </div>

                            <div class="p-3">
                                <div class="pt-2">
                                    <div class="row">
                                        <div class="col-12 col-md-6 col-lg-8 font-small">
                                            <p class="mb-2">Subtotal</p>
                                        </div>
                                        <div class="col-12 col-md-6 col-lg-4 font-small">
                                            <div class="d-flex justify-content-end align-items-end">
                                                <div class="product-price mb-2">
                                                    <i class="bi bi-currency-dollar"></i>
                                                    <span class="ms-1">
                                                        <asp:Label ID="lblSubTotal" runat="server" Text="0.00" />
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="pt-2">
                                    <div class="row">
                                        <div class="col-12 col-md-6 col-lg-8 font-small">
                                            <p class="mb-2">Costo de envío</p>
                                        </div>
                                        <div class="col-12 col-md-6 col-lg-4 font-small">
                                            <div class="d-flex justify-content-end align-items-end">
                                                <div class="product-price mb-2">
                                                    <span class="text-success fw-bold">Gratis</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="pt-2 border-top mt-2">
                                    <div class="row mt-3">
                                        <div class="col-12 col-md-6 col-lg-8">
                                            <p class="mb-2 fw-bold fs-5">Total</p>
                                        </div>
                                        <div class="col-12 col-md-6 col-lg-4">
                                            <div class="d-flex justify-content-end align-items-end">
                                                <div class="product-price mb-2 fw-bold fs-5 text-danger">
                                                    <i class="bi bi-currency-dollar"></i>
                                                    <span class="ms-1">
                                                        <asp:Label ID="lblTotalGeneral" runat="server" Text="0.00" />
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            
            <asp:Panel ID="pnlCarritoVacio" runat="server" Visible="false">
                <div class="d-flex flex-column align-items-center justify-content-center theme-bg-white theme-box-shadow theme-border-radius p-5 text-center">
                    <i class="bi bi-cart-x text-danger" style="font-size: 4rem;"></i>
                    <h2 class="mt-3 fw-bold">Tu carrito está vacío</h2>
                    <p class="text-muted mb-4">¡Explora nuestro catálogo y encuentra los mejores repuestos!</p>
                    
                    <a href='<%= ResolveUrl("~/Productos/Productos.aspx") %>' class="custom-btn-primary font-small button-effect px-5 py-2 text-decoration-none d-flex align-items-center justify-content-center">
                        Ir a la Tienda
                    </a>
                </div>
            </asp:Panel>

        </div>
    </main>
</asp:Content>