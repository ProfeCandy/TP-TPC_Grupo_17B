<%@ Page Title="Finalizar Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Frontend.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row">
            
            <div class="col-md-8">
                
                <asp:Panel ID="pnlContacto" runat="server" CssClass="card shadow-sm mb-4">
                    <div class="card-header bg-white py-3">
                        <h5 class="mb-0 fw-bold text-danger">1. Datos de Contacto</h5>
                    </div>
                    <div class="card-body">
                        <%--Iniciar sesion o invitado--%>
                        <asp:Panel ID="pnlIngresoGuest" runat="server">
                            <p class="small text-muted">¿Ya tenés cuenta? <a href="Login.aspx?next=checkout" class="text-danger fw-bold">Iniciar Sesión</a> para autocompletar.</p>
                            
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtEmailCheckout" runat="server" CssClass="form-control" TextMode="Email" Placeholder="Email"></asp:TextBox>
                                <label>Correo Electrónico para el comprobante</label>
                                <%--Validacion--%>
                                <asp:RequiredFieldValidator ControlToValidate="txtEmailCheckout" runat="server" CssClass="text-danger small" ErrorMessage="Email requerido" Display="Dynamic" />
                            </div>
                            
                            <%--Facturacion--%>
                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtNombreFacturacion" runat="server" CssClass="form-control" Placeholder="Nombre"></asp:TextBox>
                                        <label>Nombre</label>
                                        <%--Validacion--%>
                                        <asp:RequiredFieldValidator ControlToValidate="txtNombreFacturacion" runat="server" CssClass="text-danger small" ErrorMessage="Requerido" Display="Dynamic" />
                                    </div>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtApellidoFacturacion" runat="server" CssClass="form-control" Placeholder="Apellido"></asp:TextBox>
                                        <label>Apellido</label>
                                        <%--Validacion--%>
                                        <asp:RequiredFieldValidator ControlToValidate="txtApellidoFacturacion" runat="server" CssClass="text-danger small" ErrorMessage="Requerido" Display="Dynamic" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="pnlUsuarioLogueado" runat="server" Visible="false">
                            <div class="alert alert-secondary d-flex justify-content-between align-items-center">
                                <span>Estás comprando como: <strong class="text-dark"><asp:Label ID="lblNombreUsuario" runat="server"></asp:Label></strong> (<asp:Label ID="lblEmailUsuario" runat="server"></asp:Label>)</span>
                                <a href="Logout.aspx" class="btn btn-sm btn-outline-secondary">Cambiar cuenta</a>
                            </div>
                        </asp:Panel>

                        <div class="d-flex justify-content-end mt-3">
                            <asp:Button ID="btnSiguienteEnvio" runat="server" Text="Continuar a Envío" OnClick="btnSiguienteEnvio_Click" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </asp:Panel>

                <%--Panel para entrega y pago--%>
                <asp:Panel ID="pnlEntrega" runat="server" CssClass="card shadow-sm mb-4" Visible="false">
                    <div class="card-header bg-white py-3">
                        <h5 class="mb-0 fw-bold text-muted">2. Entrega</h5>
                    </div>
                    <div class="card-body">
                        <p>Acá va la selección de envío (Domicilio vs Retiro)</p>
                        <asp:Button ID="btnSiguientePago" runat="server" Text="Continuar a Pago" CssClass="btn btn-danger" />
                    </div>
                </asp:Panel>


                <asp:Panel ID="pnlPago" runat="server" CssClass="card shadow-sm mb-4" Visible="false">
                    <div class="card-header bg-white py-3">
                        <h5 class="mb-0 fw-bold text-muted">3. Pago</h5>
                    </div>
                    <div class="card-body">
                        <p>Acá van las opciones de pago</p>
                    </div>
                </asp:Panel>

            </div>

            <%--Resumen del pedido--%>
            <div class="col-md-4">
                <div class="card shadow-sm border-0 bg-light sticky-top" style="top: 20px; z-index: 1;">
                    <div class="card-body">
                        <h5 class="fw-bold mb-3">Resumen del Pedido</h5>
                        
                        <asp:Repeater ID="repResumenCarrito" runat="server">
                            <ItemTemplate>
                                <div class="d-flex justify-content-between mb-2 small">
                                    <span><%# Eval("Producto.NombreProducto") %> x <%# Eval("Cantidad") %></span>
                                    <span class="fw-bold">$<%# Convert.ToDecimal(Eval("Producto.Precio")) * Convert.ToInt32(Eval("Cantidad")) %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <hr />
                        <div class="d-flex justify-content-between fw-bold fs-5">
                            <span>Total</span>
                            <asp:Label ID="lblTotal" runat="server" Text="$ 0"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>