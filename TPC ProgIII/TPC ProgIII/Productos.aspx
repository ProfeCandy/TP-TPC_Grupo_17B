<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_ProgIII.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C2}" />
                <asp:BoundField HeaderText="Stock" DataField="Stock" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria.Desripcion" />
                <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
