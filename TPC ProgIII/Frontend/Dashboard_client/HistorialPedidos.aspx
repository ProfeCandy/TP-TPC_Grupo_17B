<%@ Page Title="Historial de Pedidos" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="HistorialPedidos.aspx.cs" Inherits="Frontend.Dashboard_client.HistorialPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardBody" runat="server">

    <div class="col-12 col-md-9">
        <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4">
            
            <div class="d-flex justify-content-between align-items-center p-4 border-bottom">
                <span class="noto-sans fs-4 fw-bold text-danger">
                    <asp:Label ID="lblTitulo" runat="server" Text="Mis Compras"></asp:Label>
                </span>
                <asp:Panel ID="pnlFiltroAdmin" runat="server" Visible="false" CssClass="d-flex gap-2 align-items-center">
                    <asp:TextBox ID="txtFiltroEmail" runat="server" CssClass="form-control form-control-sm" placeholder="Filtrar por email..." style="width: 250px;"></asp:TextBox>
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-danger btn-sm" OnClick="btnFiltrar_Click" />
                    <asp:Button ID="btnLimpiarFiltro" runat="server" Text="Limpiar" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnLimpiarFiltro_Click" />
                </asp:Panel>
            </div>

            <div class="p-4">
               <%-- Historial de compras--%>
                <asp:Panel ID="pnlSinPedidos" runat="server" Visible="false">
                    <div class="text-center py-5">
                        <i class="bi bi-bag-x fs-1 text-muted mb-3 d-block"></i>
                        <%--Si no hay compras--%>
                        <h5 class="text-muted">
                            <asp:Label ID="lblMensajeSinPedidos" runat="server" Text="No tenés compras realizadas aún."></asp:Label>
                        </h5>
                        <asp:Panel ID="pnlBotonCatalogo" runat="server">
                            <a href="../../Productos/Productos.aspx" class="btn btn-danger mt-3 px-4 rounded-pill">Ir al catálogo</a>
                        </asp:Panel>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlTablaPedidos" runat="server">
                <div class="table-responsive">
                    <asp:Repeater ID="repPedidos" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover align-middle">
                                <thead class="table-light">
                                    <tr class="text-secondary small text-uppercase">
                                        <th class="ps-3">Fecha</th>
                                        <th>Pedido #</th>
                                        <th runat="server" id="thCliente" visible="false">Cliente</th> 
                                        <th>Total</th>
                                        <th class="text-center">Estado</th> <th class="text-end pe-3">Ver</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="ps-3 text-muted"><%# Convert.ToDateTime(Eval("FechaPedido")).ToString("dd/MM/yyyy") %></td>
                                <td class="fw-bold">#<%# Eval("IdPedido") %></td>
            
                                <td runat="server" id="tdCliente" visible="false" class="small text-muted">
                                    <%# Eval("Usuario.Email") %>
                                </td>

                                <td class="fw-bold text-success">$<%# Eval("Total", "{0:N0}") %></td>

                                <td class="text-center">
                
                                    <asp:PlaceHolder ID="phEstadoUsuario" runat="server">
                                        <span class='badge rounded-pill px-3 py-2 fw-normal <%# Eval("Estado").ToString() == "Entregado" ? "bg-success" : "bg-warning text-dark" %>'>
                                            <%# Eval("Estado") %>
                                        </span>
                                    </asp:PlaceHolder>

                                    <asp:PlaceHolder ID="phEstadoAdmin" runat="server" Visible="false">
                                        <div class="d-flex justify-content-center align-items-center gap-2">
                                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select form-select-sm" style="width:auto;">
                                                <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
                                                <asp:ListItem Text="Pagado" Value="Pagado"></asp:ListItem>
                                                <asp:ListItem Text="En Preparación" Value="En Preparacion"></asp:ListItem>
                                                <asp:ListItem Text="Enviado" Value="Enviado"></asp:ListItem>
                                                <asp:ListItem Text="Entregado" Value="Entregado"></asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:LinkButton ID="btnGuardar" runat="server" 
                                                CommandName="guardarCambioEstado" 
                                                CommandArgument='<%# Eval("IdPedido") %>' 
                                                CssClass="btn btn-sm btn-success" 
                                                ToolTip="Guardar Cambio">
                                                <i class="bi bi-check-lg"></i>
                                            </asp:LinkButton>
                        
                                            <asp:HiddenField ID="hfEstadoActual" runat="server" Value='<%# Eval("Estado") %>' />
                                        </div>
                                    </asp:PlaceHolder>

                                </td>

                                <td class="text-end pe-3">
                                    <a href="DetallePedidoCliente.aspx?id=<%# Eval("IdPedido") %>" class="btn btn-sm btn-outline-secondary border-0"><i class="bi bi-eye fs-5"></i></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                                </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                </asp:Panel>

            </div>
        </div>
    </div>

</asp:Content>