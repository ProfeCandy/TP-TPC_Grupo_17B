<%@ Page Title="Historial de Pedidos" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="HistorialPedidos.aspx.cs" Inherits="Frontend.Dashboard_client.HistorialPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardBody" runat="server">

    <div class="col-12 col-md-9">
        <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4">
            
            <div class="d-flex justify-content-between p-4 border-bottom">
                <span class="noto-sans fs-4 fw-bold text-danger">Mis Compras</span>
            </div>

            <div class="p-4">
               <%-- Historial de compras--%>
                <asp:Panel ID="pnlSinPedidos" runat="server" Visible="false">
                    <div class="text-center py-5">
                        <i class="bi bi-bag-x fs-1 text-muted mb-3 d-block"></i>
                        <%--Si no hay compras--%>
                        <h5 class="text-muted">No tenés compras realizadas aún.</h5>
                        <a href="../../Productos/Productos.aspx" class="btn btn-danger mt-3 px-4 rounded-pill">Ir al catálogo</a>
                    </div>
                </asp:Panel>

                <div class="table-responsive">
                    <asp:Repeater ID="repPedidos" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover align-middle">
                                <thead class="table-light">
                                    <tr class="text-secondary small text-uppercase">
                                        <th scope="col" class="py-3 ps-3">Fecha</th>
                                        <th scope="col" class="py-3">Nro. Pedido</th>
                                        <th scope="col" class="py-3">Envío</th>
                                        <th scope="col" class="py-3">Total</th>
                                        <th scope="col" class="py-3 text-center">Estado</th>
                                        <th scope="col" class="py-3 text-end pe-3">Acciones</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                                    <tr>
                                        <td class="ps-3 py-3 text-muted">
                                            <%# Convert.ToDateTime(Eval("FechaPedido")).ToString("dd/MM/yyyy") %>
                                        </td>
                                        <td class="py-3 fw-bold text-dark">
                                            #<%# Eval("IdPedido") %>
                                        </td>
                                        <td class="py-3 small text-muted">
                                            <%# Eval("MetodoEnvio") %>
                                        </td>
                                        <td class="py-3 fw-bold text-success">
                                            $<%# Eval("Total", "{0:N0}") %>
                                        </td>
                                        <td class="py-3 text-center">
                                            <span class='badge rounded-pill px-3 py-2 fw-normal 
                                                <%# Eval("Estado").ToString() == "Entregado" ? "bg-success" : "bg-warning text-dark" %>'>
                                                <%# Eval("Estado") %>
                                            </span>
                                        </td>
                                         <%--Ver Detalle--%>
                                        <td class="text-end pe-3 py-3">
                                            <a href="DetallePedidoCliente.aspx?id=<%# Eval("IdPedido") %>" 
                                               class="btn btn-sm btn-outline-secondary border-0" title="Ver Detalle">
                                                <i class="bi bi-eye fs-5"></i>
                                            </a>
                                        </td>
                                    </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                                </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

            </div>
        </div>
    </div>

</asp:Content>