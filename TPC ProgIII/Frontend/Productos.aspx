<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_ProgIII.Productos" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="mb-3 text-center">Listado de Productos</h2>

        <asp:Panel ID="panelMensajes" runat="server" Visible="false">
            <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-danger"></asp:Label>
        </asp:Panel>

        <asp:GridView ID="dgvProductos" runat="server" AutoGenerateColumns="false"
            CssClass="table table-striped table-bordered" EmptyDataText="No hay productos disponibles">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="IdProducto" />
                <asp:BoundField HeaderText="Nombre" DataField="NombreProducto" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C2}" />
                <asp:BoundField HeaderText="Stock" DataField="Stock" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                
                <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        
        <div class="row mb-4">
            <div class="col-12">
                <h2 class="text-uppercase text-danger fw-bold">Catálogo de Productos</h2>
                <p class="text-muted">Explorá nuestra variedad de repuestos y accesorios.</p>
            </div>
        </div>

        <asp:Panel ID="panelMensajes" runat="server" Visible="false">
            <div class="alert alert-danger">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
        </asp:Panel>

        <div class="row row-cols-1 row-cols-md-3 g-4">
            
            <asp:Repeater ID="repProductos" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100 shadow-sm border-0">
                            
                            <img src="<%# Eval("ImagenPrincipal") != null ? Eval("ImagenPrincipal") : "https://dummyimage.com/450x300/dee2e6/6c757d.jpg" %>" 
                                 class="card-img-top p-3" 
                                 alt="<%# Eval("NombreProducto") %>" 
                                 style="height: 250px; object-fit: contain;">
                            
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
                                        <a href="DetalleProducto.aspx?id=<%# Eval("IdProducto") %>" class="btn btn-danger">
                                            Ver Detalle
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
        </div>
</asp:Content>