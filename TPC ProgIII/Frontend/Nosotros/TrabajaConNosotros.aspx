<%@ Page Title="Trabajá con nosotros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrabajaConNosotros.aspx.cs" Inherits="TPC_ProgIII.TrabajaConNosotros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">Trabaj&aacute; con nosotros</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Inicio.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">Trabaj&aacute; con nosotros</li>
                </ol>
            </nav>
        </div>
    </div>

    <!-- Formulario -->
    <div class="container mb-5">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="card shadow border-0 p-5">
                    <div class="text-center mb-4">
                        <h2 class="fw-bold">Brindanos tu informacion!</h2>
                        <p class="text-muted">Nosotros te contactaremos a la brevedad.</p>
                    </div>

                    <div class="row g-3">
                        <!-- Nombre completo -->
                        <div class="col-12 mb-3">
                            <label for="txtNombre" class="form-label fw-semibold">Nombre completo:</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingres&aacute; tu nombre"></asp:TextBox>
                        </div>

                        <!-- Correo electrónico -->
                        <div class="col-12 mb-3">
                            <label for="txtEmail" class="form-label fw-semibold">Correo electr&oacute;nico:</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingres&aacute; tu correo electr&oacute;nico" TextMode="Email"></asp:TextBox>
                        </div>

                        <!-- Dni -->
                        <div class="col-12 mb-3">
                            <label for="txtDni" class="form-label fw-semibold">Dni:</label>
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" placeholder="Ingres&aacute; tu dni"></asp:TextBox>
                        </div>

                        <!-- Número de contacto -->
                        <div class="col-12 mb-3">
                            <label for="txtTelefono" class="form-label fw-semibold">N&uacute;mero de contacto:</label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingres&aacute; tu numero de contacto"></asp:TextBox>
                        </div>

                        <!-- Puesto -->
                        <div class="col-12 mb-3">
                            <asp:DropDownList ID="ddlPuesto" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Eleg&iacute; el puesto al que quer&eacute;s aplicar:" Value="" Selected="True" Disabled="True"></asp:ListItem>
                                <asp:ListItem Text="Ventas" Value="Ventas"></asp:ListItem>
                                <asp:ListItem Text="Administraci&oacute;n" Value="Administración"></asp:ListItem>
                                <asp:ListItem Text="Log&iacute;stica" Value="Logística"></asp:ListItem>
                                <asp:ListItem Text="Atenci&oacute;n al Cliente" Value="Atención al Cliente"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!-- CV -->
                        <div class="col-12 mb-4">
                            <label for="fileCV" class="form-label fw-semibold">Dejanos tu CV ac&aacute;:</label>
                            <asp:FileUpload ID="fileCV" runat="server" CssClass="form-control" />
                        </div>

                        <!-- Botón Enviar -->
                        <div class="col-12">
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-danger px-5" OnClick="btnEnviar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

