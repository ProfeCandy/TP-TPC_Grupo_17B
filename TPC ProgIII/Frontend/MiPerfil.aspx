<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Frontend.MiPerfil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/cropperjs/1.5.13/cropper.min.css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-12 col-md-8">
                
                <div class="card border-0 shadow rounded-4">
                    <div class="card-body p-5">
                        
                        <h3 class="fw-bold text-danger mb-4 border-bottom pb-2">Mi Perfil</h3>

                        <asp:Panel ID="panelMensaje" runat="server" Visible="false" CssClass="alert mb-4">
                            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        </asp:Panel>

                        <div class="row mb-4">
                            <div class="col-12 text-center">
                                <div class="mb-3">
                                    <asp:Image ID="imgFotoPerfil" runat="server" 
                                        CssClass="rounded-circle border border-3 border-danger" 
                                        Width="150" Height="150" 
                                        style="object-fit: cover;" 
                                        ImageUrl="~/assets/images/icons/profile-icon.png" />
                                </div>
                                <asp:FileUpload ID="fileFotoPerfil" runat="server" 
                                    CssClass="d-none" 
                                    accept="image/jpeg,image/jpg,image/png,image/gif" />
                                <button type="button" id="btnSeleccionarFoto" class="btn btn-outline-danger mb-2">
                                    <i class="bi bi-camera"></i> Seleccionar Foto
                                </button>
                                <asp:HiddenField ID="hiddenImagenRecortada" runat="server" />
                                <small class="text-muted d-block mt-2">
                                    Formatos permitidos: JPG, PNG, GIF. Tama&ntilde;o m&aacute;ximo: 2MB. Dimensiones recomendadas: 300x300px
                                </small>
                            </div>
                        </div>

                        <div class="modal fade" id="modalRecortar" tabindex="-1">
                            <div class="modal-dialog modal-lg">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Recortar Foto de Perfil</h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                                    </div>
                                    <div class="modal-body text-center">
                                        <img id="imagenRecortar" style="max-width: 100%; max-height: 500px;">
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                        <button type="button" class="btn btn-danger" id="btnAplicarRecorte">Aplicar Recorte</button>
                                    </div>
                                </div>
                            </div>
                        </div>

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
                            <a href="Inicio.aspx" class="btn btn-outline-secondary ms-2">Volver</a>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/cropperjs/1.5.13/cropper.min.js"></script>
    <script>
        let cropper;
        let cropperModal;

        document.getElementById('btnSeleccionarFoto').addEventListener('click', function() {
            document.getElementById('<%= fileFotoPerfil.ClientID %>').click();
        });

        document.getElementById('<%= fileFotoPerfil.ClientID %>').addEventListener('change', function(e) {
            const file = e.target.files[0];
            if (file) {
                const reader = new FileReader();
                reader.onload = function(e) {
                    const img = document.getElementById('imagenRecortar');
                    img.src = e.target.result;
                    
                    cropperModal = new bootstrap.Modal(document.getElementById('modalRecortar'));
                    cropperModal.show();
                    
                    document.getElementById('modalRecortar').addEventListener('shown.bs.modal', function() {
                        if (cropper) {
                            cropper.destroy();
                        }
                        cropper = new Cropper(img, {
                            aspectRatio: 1,
                            viewMode: 1,
                            autoCropArea: 0.8,
                            responsive: true,
                            guides: true,
                            center: true,
                            highlight: false,
                            cropBoxMovable: true,
                            cropBoxResizable: true,
                            toggleDragModeOnDblclick: false,
                        });
                    }, { once: true });
                };
                reader.readAsDataURL(file);
            }
        });

        document.getElementById('btnAplicarRecorte').addEventListener('click', function() {
            if (cropper) {
                const canvas = cropper.getCroppedCanvas({
                    width: 300,
                    height: 300,
                    imageSmoothingEnabled: true,
                    imageSmoothingQuality: 'high'
                });
                
                canvas.toBlob(function(blob) {
                    const reader = new FileReader();
                    reader.onload = function(e) {
                        document.getElementById('<%= hiddenImagenRecortada.ClientID %>').value = e.target.result;
                        
                        const preview = document.getElementById('<%= imgFotoPerfil.ClientID %>');
                        preview.src = e.target.result;
                        
                        cropperModal.hide();
                        if (cropper) {
                            cropper.destroy();
                            cropper = null;
                        }
                    };
                    reader.readAsDataURL(blob);
                }, 'image/jpeg', 0.9);
            }
        });
    </script>
</asp:Content>