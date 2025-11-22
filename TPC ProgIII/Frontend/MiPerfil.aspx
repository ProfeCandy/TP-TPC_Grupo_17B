<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Frontend.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-12 col-md-8">
                
                <div class="card border-0 shadow rounded-4">
                    <div class="card-body p-5">
                        
                        <h3 class="fw-bold text-danger mb-4 border-bottom pb-2">Mi Perfil</h3>

                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="form-label">Apellido</label>
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Teléfono</label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Ej: 11 1234 5678"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-4">
                            <div class="col-md-6">
                                <label class="form-label">Dirección</label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Calle y número"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Localidad</label>
                                <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="d-end">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" CssClass="btn btn-danger px-4" />
                            <a href="Default.aspx" class="btn btn-outline-secondary ms-2">Volver</a>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>