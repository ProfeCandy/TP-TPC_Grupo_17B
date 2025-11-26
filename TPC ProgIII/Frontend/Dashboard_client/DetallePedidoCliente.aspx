<%@ Page Title="Detalle de Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePedidoCliente.aspx.cs" Inherits="Frontend.Dashboard_client.DetallePedidoCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        
        <div class="mb-4">
            <a href="HistorialPedidos.aspx" class="text-decoration-none text-secondary">
                <i class="bi bi-arrow-left me-1"></i>Volver a mis compras
            </a>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card border-0 shadow-sm">
                    <div class="card-body p-4">
                        
                        <div class="d-flex justify-content-between align-items-center border-bottom pb-3 mb-4">
                            <div>
                                <%--Fecha--%>
                                <h4 class="fw-bold mb-1">Pedido #<asp:Label ID="lblNroPedido" runat="server"></asp:Label></h4>
                                <span class="text-muted small">Realizado el <asp:Label ID="lblFecha" runat="server"></asp:Label></span>
                            </div>
                            <div class="text-end">
                                <asp:Label ID="lblEstado" runat="server" CssClass="badge bg-warning text-dark fs-6 px-3 py-2 rounded-pill"></asp:Label>
                            </div>
                        </div>               
                        <h6 class="text-uppercase text-muted small fw-bold mb-3">Productos</h6>
                        <div class="list-group mb-4">
                            <asp:Repeater ID="repDetalles" runat="server">
                                <ItemTemplate>
                                    <div class="list-group-item border-0 border-bottom py-3">
                                        <div class="row align-items-center">
                                            <div class="col-2 col-md-1">
                                                <%# Eval("Producto.ImagenPrincipal") != null ? 
                                                    "<img src='" + ResolveUrl(Eval("Producto.ImagenPrincipal").ToString()) + "' class='img-fluid rounded' style='width: 50px; height: 50px; object-fit: contain;' />" 
                                                    : 
                                                    "<div class='bg-light rounded d-flex align-items-center justify-content-center' style='width: 50px; height: 50px;'><i class='bi bi-box-seam text-secondary'></i></div>" 
                                                %>
                                            </div>
                                            <div class="col-6 col-md-7">
                                                <h6 class="mb-0"><%# Eval("Producto.NombreProducto") %></h6>
                                                <small class="text-muted">Marca: <%# Eval("Producto.Marca.Descripcion") %></small>
                                            </div>
                                            <div class="col-4 col-md-4 text-end">
                                                <span class="text-muted me-3"><%# Eval("Cantidad") %> un.</span>
                                                <span class="fw-bold">$<%# (Convert.ToDecimal(Eval("PrecioUnitario")) * Convert.ToInt32(Eval("Cantidad"))).ToString("N0") %></span>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <div class="row justify-content-end">
                            <div class="col-md-4">
                                <div class="d-flex justify-content-between mb-2">
                                    <span class="text-muted">Envío</span>
                                    <span class="text-success fw-bold">Gratis</span> </div>
                                <div class="d-flex justify-content-between fs-5 fw-bold text-danger pt-2 border-top">
                                    <span>Total</span>
                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row mt-5 pt-4 border-top bg-light rounded p-3 mx-0">
                            
                            <div class="col-md-6 mb-3 mb-md-0">
                                <h6 class="fw-bold small text-uppercase mb-2">Método de Envío</h6>
                                
                                <p class="mb-0 fw-bold text-dark"><asp:Label ID="lblMetodoEnvio" runat="server"></asp:Label></p>
                                
                                <asp:Panel ID="pnlDireccion" runat="server" Visible="false">
                                    <p class="mb-0 text-muted small mt-1">
                                        <i class="bi bi-geo-alt me-1"></i>
                                        <asp:Label ID="lblDireccionCompleta" runat="server"></asp:Label>
                                    </p>
                                </asp:Panel>

                                <asp:Panel ID="pnlRetiro" runat="server" Visible="false">
                                    <p class="mb-0 text-muted small mt-1">
                                        Retiro en sucursal UTN Pacheco.
                                    </p>
                                </asp:Panel>
                            </div>

                            <div class="col-md-6">
                                <h6 class="fw-bold small text-uppercase mb-2">Método de Pago</h6>
                                <p class="mb-0 text-muted"><asp:Label ID="lblPago" runat="server"></asp:Label></p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>