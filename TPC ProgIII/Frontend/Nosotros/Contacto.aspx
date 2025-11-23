<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Frontend.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">Pong&aacute;monos en contacto</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Default.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">Contacto</li>
                </ol>
            </nav>
        </div>
    </div>

    <!-- Subtítulo -->
    <div class="container text-center mb-5">
        <p class="fs-5 text-muted">&iquest;Quer&eacute;s contactarte con nosotros? Envianos tus consultas ac&aacute; y nos comunicaremos lo antes posible.</p>
    </div>

    <!-- Contenido Principal -->
    <div class="container mb-5">
        <div class="row g-5">
            <!-- Información de Contacto -->
            <div class="col-lg-5">
                <div class="card shadow border-0 p-4">
                    <h3 class="fw-bold mb-4">Informaci&oacute;n de contacto</h3>

                    <!-- Dirección -->
                    <div class="mb-4">
                        <h6 class="fw-bold text-danger mb-2">
                            <i class="bi bi-geo-alt me-2"></i>Direcci&oacute;n
                        </h6>
                        <p class="text-secondary mb-0">
                            Leguizam&oacute;n On&eacute;simo 459, Neuqu&eacute;n, Neuqu&eacute;n<br />
                            R&iacute;o Negro 519, Neuqu&eacute;n, Neuqu&eacute;n<br />
                            Miguel Mu&ntilde;oz 67, Cipolletti, R&iacute;o Negro
                        </p>
                    </div>

                    <!-- Teléfono -->
                    <div class="mb-4">
                        <h6 class="fw-bold text-danger mb-2">
                            <i class="bi bi-telephone me-2"></i>Llamanos a:
                        </h6>
                        <p class="text-secondary mb-2">
                            <strong>Sucursal Leguizam&oacute;n:</strong> 0299 448-1628<br />
                            <span class="small text-muted">Horario de atenci&oacute;n: 09:00 a 18:00</span>
                        </p>
                        <p class="text-secondary mb-2">
                            <strong>Sucursal R&iacute;o Negro:</strong> 0299 447-0670<br />
                            <span class="small text-muted">Horario de atenci&oacute;n: 09:00 a 18:00</span>
                        </p>
                        <p class="text-secondary mb-0">
                            <strong>Sucursal Cipolletti:</strong> 0299 477-8352<br />
                            <span class="small text-muted">Horario de atenci&oacute;n: 09:00 a 18:00</span>
                        </p>
                    </div>

                    <!-- Email -->
                    <div class="mb-4">
                        <h6 class="fw-bold text-danger mb-2">
                            <i class="bi bi-envelope me-2"></i>Envianos un correo electr&oacute;nico a:
                        </h6>
                        <p class="text-secondary mb-0">
                            <a href="mailto:info@distryser.ar" class="text-decoration-none text-primary">info@distryser.ar</a>
                        </p>
                    </div>

                    <!-- Redes Sociales -->
                    <div class="mt-5 pt-4 border-top">
                        <h6 class="fw-bold mb-3">S&iacute;guenos en:</h6>
                        <div class="d-flex gap-3">
                            <a href="#" class="text-dark text-decoration-none fs-5" title="Facebook">
                                <i class="bi bi-facebook"></i>
                            </a>
                            <a href="#" class="text-dark text-decoration-none fs-5" title="Instagram">
                                <i class="bi bi-instagram"></i>
                            </a>
                            <a href="#" class="text-dark text-decoration-none fs-5" title="WhatsApp">
                                <i class="bi bi-whatsapp"></i>
                            </a>
                            <a href="#" class="text-dark text-decoration-none fs-5" title="LinkedIn">
                                <i class="bi bi-linkedin"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Formulario de Contacto -->
            <div class="col-lg-7">
                <div class="card shadow border-0 p-4">
                    <h3 class="fw-bold mb-4">Envianos un mensaje</h3>

                    <div class="row g-3">
                        <!-- Nombre -->
                        <div class="col-12">
                            <label for="txtNombre" class="form-label fw-semibold">Tu nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingres&aacute; tu nombre ac&aacute;"></asp:TextBox>
                        </div>

                        <!-- Email -->
                        <div class="col-12">
                            <label for="txtEmail" class="form-label fw-semibold">Tu email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Ingres&aacute; tu correo electr&oacute;nico ac&aacute;"></asp:TextBox>
                        </div>

                        <!-- Teléfono -->
                        <div class="col-12">
                            <label for="txtTelefono" class="form-label fw-semibold">Tu n&uacute;mero de tel&eacute;fono</label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingres&aacute; tu n&uacute;mero de contacto ac&aacute;"></asp:TextBox>
                        </div>

                        <!-- Asunto -->
                        <div class="col-12">
                            <label for="txtAsunto" class="form-label fw-semibold">Asunto</label>
                            <asp:TextBox ID="txtAsunto" runat="server" CssClass="form-control" placeholder="&iquest;Cu&aacute;l es el motivo de tu consulta?"></asp:TextBox>
                        </div>

                        <!-- Mensaje -->
                        <div class="col-12">
                            <label for="txtMensaje" class="form-label fw-semibold">Tu mensaje</label>
                            <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Dejanos tu mensaje ac&aacute;"></asp:TextBox>
                        </div>

                        <!-- Botón Enviar -->
                        <div class="col-12">
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar Mensaje" CssClass="btn btn-danger px-5" OnClick="btnEnviar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
