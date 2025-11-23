<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Frontend.Dashboard_client.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardBody" runat="server">

    <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4">
        
        <div class="d-flex justify-content-between p-3 border-bottom">
            <span class="fs-4 noto-sans fw-bold">Editar Información Personal</span>
        </div>
        
        <div class="row p-3">
            <div class="col-12 col-lg-8">
                <div class="row g-3">
                    
                    <div class="col-12 col-md-6">
                        <label class="form-label small fw-bold">Nombre / Razón Social</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-12 col-md-6">
                        <label class="form-label small fw-bold">Apellido</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-12">
                        <label class="form-label small fw-bold">Correo electrónico</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>

                    <div class="col-12 col-md-6">
                        <label class="form-label small fw-bold">Número de contacto</label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-12 col-md-6">
                        <label class="form-label small fw-bold">Localidad</label>
                        <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-12">
                        <label class="form-label small fw-bold">Dirección</label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                </div>
                
                <div class="mt-4 text-end">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" CssClass="btn btn-primary theme-btn-primary" />
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" CssClass="small fw-bold mt-2 d-block" Visible="false"></asp:Label>
                </div>

            </div>
            
            <div class="col-12 col-lg-4 d-none d-lg-block bg-light theme-border-radius ms-auto">
                </div>
        </div>
    </div>

    <div class="d-flex justify-content-between p-3 mt-5">
        <span class="noto-sans fw-bold">Últimos pedidos</span>
    </div>

    <div class="p-3">
        <div class="row g-0">
            <div class="col-12 col-lg-12 mb-3">
                <div class="border px-3">
                    <div class="row g-0 align-items-center">
                        
                        <div class="col-12 col-md-6 col-lg-2">
                            <img src='<%= ResolveUrl("~/assets/images/product/baring.jpg") %>' alt="Parts" class="img-fluid" />
                        </div>
                        
                        <div class="col-12 col-md-6 col-lg-6">
                            <p class="mb-0 font-small">Rodamiento SKF 2205</p>
                            <span>
                                <small class="text-muted font-extra-small">ORD-2023-8592</small>
                            </span>
                            <div class="mt-2 small lh-1 mb-3 mb-lg-0">
                                <a href="javascript:void(0)" class="text-decoration-none text-inherit">
                                    <span class="text-muted font-small">Estado: <span class="text-success">Entregado</span></span>
                                </a>
                            </div>
                        </div>
                        
                        <div class="col-12 col-md-12 col-lg-4 text-lg-end text-start text-md-start">
                            <div class="d-flex flex-column font-small">
                                <span class="theme-text-primary">$ 150.000,00</span>
                                <span class="theme-text-accent-one mt-2">21/11/2024</span>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>