<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_ProgIII.Productos" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        
        <%-- Encabezado --%>
        <div class="row mb-4">
            <div class="col-12">
                <h2 class="text-uppercase text-danger fw-bold">Catálogo de Productos</h2>
                <p class="text-muted">Explorá nuestra variedad de repuestos y accesorios.</p>
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
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>