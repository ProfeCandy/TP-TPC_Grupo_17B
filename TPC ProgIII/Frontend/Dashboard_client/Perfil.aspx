<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Frontend.Dashboard_client.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardBody" runat="server">

    <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4">
        
        <div class="d-flex justify-content-between p-3 border-bottom">
            <span class="fs-4 noto-sans fw-bold">Editar Información Personal</span>
        </div>
        
        <div class="row p-3">
            <div class="col-12 col-lg-8">
                <div class="row g-3">
                    
                    <div class="col-12 text-center mb-3">
                        <div class="mb-3">
                            <asp:Image ID="imgFotoPerfil" runat="server" 
                                CssClass="rounded-circle border border-3 border-primary" 
                                Width="150" Height="150" 
                                style="object-fit: cover;" 
                                ImageUrl="~/assets/images/icons/profile-icon.png" />
                        </div>
                        <asp:FileUpload ID="fileFotoPerfil" runat="server" 
                            CssClass="d-none" 
                            accept="image/jpeg,image/jpg,image/png,image/gif" />
                        <button type="button" id="btnSeleccionarFoto" class="btn btn-outline-primary mb-2">
                            <i class="bi bi-camera"></i> Seleccionar Foto
                        </button>
                        <asp:HiddenField ID="hiddenImagenRecortada" runat="server" />
                        <small class="text-muted d-block mt-2">
                            Formatos permitidos: JPG, PNG, GIF. Tama&ntilde;o m&aacute;ximo: 2MB. Dimensiones recomendadas: 300x300px
                        </small>
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
                                    <button type="button" class="btn btn-primary" id="btnAplicarRecorte">Aplicar Recorte</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    
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

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/cropperjs/1.5.13/cropper.min.css" />
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