<%@ Page Title="Debug - Sesi&#243;n" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Debug.aspx.cs" Inherits="Frontend.Debug" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-12 col-md-10 col-lg-8">
                
                <!-- Título -->
                <div class="mb-5">
                    <h1 class="fw-bold text-danger mb-2">&#128269; Debug - Informaci&#243;n de Sesi&#243;n</h1>
                    <p class="text-muted">Esta p&#225;gina muestra los datos actuales de la sesi&#243;n del usuario logueado.</p>
                </div>

                <!-- Alert de advertencia -->
                <div class="alert alert-warning alert-dismissible fade show" role="alert">
                    <i class="bi bi-exclamation-triangle me-2"></i>
                    <strong>Nota:</strong> Esta p&#225;gina es solo para desarrollo. Elimina antes de ir a producci&#243;n.
                    <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                </div>

                <!-- Card de Usuario -->
                <div class="card border-0 shadow-lg mb-4">
                    <div class="card-header bg-danger bg-gradient text-white py-3">
                        <h5 class="mb-0"><i class="bi bi-person-fill me-2"></i>Estado del Usuario</h5>
                    </div>
                    <div class="card-body">
                        <asp:Panel ID="pnlUsuarioLogueado" runat="server" Visible="false">
                            <div class="row g-3">
                                <div class="col-md-6">
                                    <label class="form-label fw-bold text-secondary">Nombre:</label>
                                    <p class="border border-light rounded p-2 bg-light">
                                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                                    </p>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label fw-bold text-secondary">Apellido:</label>
                                    <p class="border border-light rounded p-2 bg-light">
                                        <asp:Label ID="lblApellido" runat="server"></asp:Label>
                                    </p>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label fw-bold text-secondary">Email:</label>
                                    <p class="border border-light rounded p-2 bg-light">
                                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                    </p>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label fw-bold text-secondary">ID Usuario:</label>
                                    <p class="border border-light rounded p-2 bg-light">
                                        <asp:Label ID="lblIdUsuario" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>

                            <!-- Separador -->
                            <hr class="my-4" />

                            <!-- Información del Rol -->
                            <div class="row g-3">
                                <div class="col-md-6">
                                    <label class="form-label fw-bold text-secondary">ID Rol:</label>
                                    <p class="border border-light rounded p-2 bg-light">
                                        <asp:Label ID="lblIdRol" runat="server"></asp:Label>
                                    </p>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label fw-bold text-secondary">Nombre Rol:</label>
                                    <p class="border border-light rounded p-2 bg-light">
                                        <asp:Label ID="lblNombreRol" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>

                            <!-- Badge de Admin -->
                            <div class="mt-4">
                                <asp:Panel ID="pnlEsAdmin" runat="server" Visible="false">
                                    <span class="badge bg-success fs-6">
                                        <i class="bi bi-check-circle me-1"></i> Es Administrador
                                    </span>
                                </asp:Panel>
                                <asp:Panel ID="pnlNoAdmin" runat="server" Visible="false">
                                    <span class="badge bg-info fs-6">
                                        <i class="bi bi-info-circle me-1"></i> No es Administrador
                                    </span>
                                </asp:Panel>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="pnlNoLogueado" runat="server" Visible="false">
                            <div class="alert alert-info mb-0">
                                <i class="bi bi-exclamation-circle me-2"></i>
                                <strong>No hay usuario logueado.</strong> 
                                <a href="Login.aspx" class="alert-link">Haz login aqu&#237;</a>
                            </div>
                        </asp:Panel>
                    </div>
                </div>

                <!-- Botones de Acción -->
                <div class="d-grid gap-2 d-md-flex justify-content-md-center">
                    <a href="Inicio.aspx" class="btn btn-outline-secondary">
                        <i class="bi bi-arrow-left me-2"></i> Volver al Inicio
                    </a>
                    <asp:LinkButton ID="btnRefresh" runat="server" CssClass="btn btn-danger" OnClick="btnRefresh_Click">
                        <i class="bi bi-arrow-clockwise me-2"></i> Actualizar
                    </asp:LinkButton>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
