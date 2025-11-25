<%@ Page Title="Compra Exitosa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidoExitoso.aspx.cs" Inherits="Frontend.PedidoExitoso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-md-8 col-lg-6">
                
                <div class="card border-0 shadow-lg rounded-4 text-center p-5">
                    
                    <div class="mb-4">
                        <i class="bi bi-check-circle-fill text-success" style="font-size: 5rem;"></i>
                    </div>

                    <h1 class="fw-bold text-dark mb-3">¡Gracias por tu compra!</h1>
                    
                    <p class="lead text-muted mb-4">
                        Tu pedido ha sido procesado exitosamente.
                    </p>

                    <div class="alert alert-light border border-secondary-subtle text-start mb-4">
                        <div class="d-flex align-items-start gap-3">
                            <i class="bi bi-envelope-check fs-4 text-danger"></i>
                            <div>
                                <h6 class="fw-bold mb-1">Comprobante enviado</h6>
                                <p class="mb-0 small text-muted">Te enviamos un email con el detalle de tu compra y la factura correspondiente.</p>
                            </div>
                        </div>
                        <hr />
                        <div class="d-flex align-items-start gap-3">
                            <i class="bi bi-box-seam fs-4 text-danger"></i>
                            <div>
                                <h6 class="fw-bold mb-1">Estado del envío</h6>
                                <p class="mb-0 small text-muted">Tu pedido ya está en preparación. Te avisaremos cuando esté en camino.</p>
                            </div>
                        </div>
                    </div>

                    <h5 class="fw-bold text-start mb-3">Resumen de items:</h5>
                    <div class="card bg-light border-0 mb-4">
                        <div class="card-body text-start">
                            <asp:Repeater ID="repDetalleCompra" runat="server">
                                <ItemTemplate>
                                    <div class="d-flex justify-content-between mb-2 small">
                                        <span><%# Eval("Producto.NombreProducto") %> <span class="text-muted">x <%# Eval("Cantidad") %></span></span>
                                        <span class="fw-bold">$<%# (Convert.ToDecimal(Eval("Producto.Precio")) * Convert.ToInt32(Eval("Cantidad"))).ToString("N0") %></span>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <hr />
                            <div class="d-flex justify-content-between fw-bold text-danger">
                                <span>Total Pagado</span>
                                <asp:Label ID="lblTotalPagado" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="d-grid gap-2">
                        <a href="Default.aspx" class="btn btn-danger btn-lg">Volver al Inicio</a>
                        <a href="MiPerfil.aspx" class="btn btn-outline-secondary">Ver mis pedidos</a>
                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>