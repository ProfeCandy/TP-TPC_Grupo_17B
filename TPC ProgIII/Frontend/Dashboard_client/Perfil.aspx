<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Frontend.Dashboard_client.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardBody" runat="server">

    <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4">
        
        <div class="d-flex justify-content-between p-3">
            <span class="fs-4 noto-sans fw-bold">Información personal</span>
        </div>
        
        <div class="row g-0">
            <div class="col-12 col-lg-6">
                <div class="d-flex flex-column p-3">
                    
                    <span class="noto-sans small fw-bold">Razón social</span>
                    <span class="noto-sans small fw-normal">
                        <asp:Literal ID="litRazonSocial" runat="server"></asp:Literal>
                    </span>

                    <span class="noto-sans small fw-bold mt-3">CUIT</span>
                    <span class="noto-sans small fw-normal">
                        <asp:Literal ID="litCuit" runat="server"></asp:Literal>
                    </span>

                    <span class="noto-sans small fw-bold mt-3">Correo electrónico</span>
                    <span class="noto-sans small fw-normal">
                        <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                    </span>

                    <span class="noto-sans small fw-bold mt-3">Número de contacto</span>
                    <span class="noto-sans small fw-normal">
                        <asp:Literal ID="litTelefono" runat="server" Text="{Teléfono}"></asp:Literal>
                    </span>

                    <span class="noto-sans small fw-bold mt-3">Dirección</span>
                    <span class="noto-sans small fw-normal">
                        <asp:Literal ID="litDireccion" runat="server" Text="{Dirección}"></asp:Literal>
                    </span>

                </div>
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