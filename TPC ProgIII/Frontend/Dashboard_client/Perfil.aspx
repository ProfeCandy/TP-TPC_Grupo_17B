<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Frontend.Dashboard_client.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardBody" runat="server">

    <div class="row">
        <div class="col-12 col-lg-8">
            
            <div class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4">
                
                <div class="d-flex justify-content-between p-3 border-bottom">
                    <span class="fs-4 noto-sans fw-bold">Editar Información Personal</span>
                </div>
                
                <div class="p-3">
                    <%--Foto Perfil--%>
                    <div class="text-center mb-4">
                        <div class="mb-3">
                            <asp:Image ID="imgFotoPerfil" runat="server" 
                                CssClass="rounded-circle border border-3 border-primary" 
                                Width="150" Height="150" 
                                style="object-fit: cover;" 
                                ImageUrl="~/assets/images/icons/profile-icon.png" />
                        </div>
                        <asp:FileUpload ID="fileFotoPerfil" runat="server" CssClass="d-none" accept="image/jpeg,image/jpg,image/png,image/gif" />
                        <button type="button" id="btnSeleccionarFoto" class="btn btn-outline-primary mb-2">
                            <i class="bi bi-camera"></i> Seleccionar Foto
                        </button>
                        <asp:HiddenField ID="hiddenImagenRecortada" runat="server" />
                        
                        <small class="text-muted d-block mt-2">
                            Formatos: JPG, PNG, GIF. Máx: 2MB.
                        </small>
                    </div>

                    <div class="row g-3">
                        <div class="col-12 col-md-6">
                            <label class="form-label small fw-bold">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            <%--Validacion Nombre--%>
                            <asp:RequiredFieldValidator ControlToValidate="txtNombre" runat="server" CssClass="text-danger small" ErrorMessage="Requerido" Display="Dynamic" />
                            <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtNombre" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />
                        </div>
                        <div class="col-12 col-md-6">
                            <label class="form-label small fw-bold">Apellido</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            <%--Validacion Apellido--%>
                            <asp:RequiredFieldValidator ControlToValidate="txtApellido" runat="server" CssClass="text-danger small" ErrorMessage="Requerido" Display="Dynamic" />
                            <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtApellido" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="col-12">
                            <label class="form-label small fw-bold">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-6">
                            <label class="form-label small fw-bold">Teléfono</label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                            <%--Validacion Telefono--%>
                            <asp:RegularExpressionValidator ErrorMessage="Solo números" ControlToValidate="txtTelefono" runat="server" ValidationExpression="^[0-9]+$" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="col-12 col-md-6">
                            <label class="form-label small fw-bold">Dirección (Calle)</label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                           <%--Validacion Direccion--%>
                            <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtDireccion" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />                    
                        </div>
                        <div class="col-12 col-md-3">
                            <label class="form-label small fw-bold">Altura</label>
                            <asp:TextBox ID="txtAltura" runat="server" CssClass="form-control"></asp:TextBox>
                            <%--Validacion Altura--%>
                            <asp:RegularExpressionValidator ErrorMessage="Num" ControlToValidate="txtAltura" runat="server" ValidationExpression="^[0-9]+$" CssClass="text-danger small" Display="Dynamic" />
                        </div>
                        <div class="col-12 col-md-3">
                            <label class="form-label small fw-bold">C.P.</label>
                            <asp:TextBox ID="txtCP" runat="server" CssClass="form-control"></asp:TextBox>
                            <%--Validacion CP--%>
                            <asp:RegularExpressionValidator ErrorMessage="Num" ControlToValidate="txtCP" runat="server" ValidationExpression="^[0-9]+$" CssClass="text-danger small" Display="Dynamic" />
                        </div>
                        
                        <div class="col-12 col-md-6">
                            <label class="form-label small fw-bold">Localidad</label>
                            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control"></asp:TextBox>
                           <%--Validacion Localidad--%>
                            <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtLocalidad" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />                        
                        </div>
                        <div class="col-12 col-md-6">
                            <label class="form-label small fw-bold">Provincia</label>
                            <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control"></asp:TextBox>
                           <%--Validacion Provincia--%>
                            <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtProvincia" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />                        
                        </div>
                    </div>              
                    
                    <div class="mt-4 text-end">
                        <asp:Label ID="lblMensaje" runat="server" CssClass="small fw-bold me-2" Visible="false"></asp:Label>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" CssClass="btn btn-primary theme-btn-primary px-4" />
                    </div>

                    <hr class="my-5 border-secondary-subtle">

                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <span class="noto-sans fw-bold text-danger">Último pedido</span>
                        <a href="HistorialPedidos.aspx" class="text-decoration-none small text-secondary">Ver historial</a>
                    </div>

                    <asp:Panel ID="pnlSinPedidos" runat="server" Visible="false">
                        <div class="alert alert-light text-center text-muted border border-secondary-subtle rounded-3 py-4">
                            <i class="bi bi-cart-x fs-4 d-block mb-2"></i>
                            No has realizado compras todavía.
                        </div>
                    </asp:Panel>
                    <%--Ultimo Pedido--%>
                    <asp:Panel ID="pnlUltimoPedido" runat="server" Visible="false">
                        <div class="table-responsive border rounded-3">
                            <table class="table table-hover align-middle mb-0 text-nowrap">
                                <thead class="table-light">
                                    <tr class="text-secondary small text-uppercase">
                                        <th>Fecha</th>
                                        <th>Pedido</th>
                                        <th>Envío</th>
                                        <th>Total</th>
                                        <th>Estado</th>
                                        <th class="text-end">Acción</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="text-muted"><asp:Label ID="lblFecha" runat="server"></asp:Label></td>
                                        <td class="fw-bold text-dark">#<asp:Label ID="lblNroPedido" runat="server"></asp:Label></td>
                                        <td class="small text-muted"><asp:Label ID="lblEnvio" runat="server"></asp:Label></td>
                                        <td class="fw-bold text-success"><asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lblEstado" runat="server" CssClass="badge rounded-pill px-3 py-2 fw-normal"></asp:Label></td>
                                        <td class="text-end">
                                            <a href="#" id="lnkVerDetalle" runat="server" class="btn btn-sm btn-outline-secondary border-0">
                                                <i class="bi bi-eye fs-5"></i>
                                            </a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </asp:Panel>

                </div>
            </div>
        </div>
        <%--Pnl Desactivar Cuenta--%>
        <div class="col-12 col-lg-4">
            <div class="bg-light border border-danger rounded-3 p-4">
                <h6 class="fw-bold text-danger mb-3"><i class="bi bi-exclamation-triangle me-2"></i>Zona de peligro</h6>
                <p class="small text-muted mb-3">
                    Si desactivas tu cuenta, no podrás realizar nuevos pedidos y perderás el acceso a tu cuenta.
                </p>
                <p class="small text-muted mb-3">
                    Si deseas reactivar tu cuenta en el futuro deberás comunicarte con un administrador.
                </p>
                <button type="button" class="btn btn-outline-danger btn-sm fw-bold w-100" data-bs-toggle="modal" data-bs-target="#modalDesactivar">
                    Desactivar cuenta
                </button>
            </div>
        </div>

    </div>

    <div class="modal fade" id="modalDesactivar" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-danger text-white">
                    <h5 class="modal-title fw-bold"><i class="bi bi-exclamation-triangle-fill me-2"></i>Atención</h5>
                    <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p class="fw-bold text-danger">¿Está seguro que desea desactivar su cuenta?</p>
                    <p class="small text-muted">Para confirmar, por favor ingrese sus credenciales.</p>
                
                    <div class="mb-3">
                        <label class="form-label small fw-bold">Correo Electrónico</label>
                        <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="form-control" placeholder="tucorreo@ejemplo.com"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label small fw-bold">Contraseña Actual</label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="********"></asp:TextBox>
                    </div>
                
                    <asp:Panel ID="pnlErrorDesactivar" runat="server" Visible="false" CssClass="alert alert-danger p-2 small">
                        <asp:Label ID="lblErrorDesactivar" runat="server"></asp:Label>
                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnConfirmarDesactivacion" runat="server" 
                        Text="Confirmar desactivación" 
                        CssClass="btn btn-danger fw-bold" 
                        OnClick="btnConfirmarDesactivacion_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalRecortar" tabindex="-1">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Recortar Foto</h5>
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

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/cropperjs/1.5.13/cropper.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/cropperjs/1.5.13/cropper.min.js"></script>
    
    <script>
        let cropper;
        let cropperModal;

        // Al hacer click en "Seleccionar Foto", dispara el input oculto
        document.getElementById('btnSeleccionarFoto').addEventListener('click', function() {
            document.getElementById('<%= fileFotoPerfil.ClientID %>').click();
        });

        // Cuando el input cambia (se elige archivo)
        document.getElementById('<%= fileFotoPerfil.ClientID %>').addEventListener('change', function(e) {
            const file = e.target.files[0];
            if (file) {
                const reader = new FileReader();
                reader.onload = function(e) {
                    const img = document.getElementById('imagenRecortar');
                    img.src = e.target.result;
                    
                    const modalEl = document.getElementById('modalRecortar');
                    if(modalEl){
                        cropperModal = new bootstrap.Modal(modalEl);
                        cropperModal.show();
                        
                        modalEl.addEventListener('shown.bs.modal', function() {
                            if (cropper) { cropper.destroy(); }
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
                    }
                };
                reader.readAsDataURL(file);
            }
        });

        const btnAplicar = document.getElementById('btnAplicarRecorte');
        if(btnAplicar){
            btnAplicar.addEventListener('click', function() {
                if (cropper) {
                    const canvas = cropper.getCroppedCanvas({
                        width: 300, height: 300, imageSmoothingEnabled: true, imageSmoothingQuality: 'high'
                    });
                    canvas.toBlob(function(blob) {
                        const reader = new FileReader();
                        reader.onload = function(e) {
                            // Guardamos el base en el HiddenField
                            document.getElementById('<%= hiddenImagenRecortada.ClientID %>').value = e.target.result;
                            
                            // Actualizamos la vista previa
                            document.getElementById('<%= imgFotoPerfil.ClientID %>').src = e.target.result;
                            
                            if(cropperModal) cropperModal.hide();
                            if (cropper) { cropper.destroy(); cropper = null; }
                        };
                        reader.readAsDataURL(blob);
                    }, 'image/jpeg', 0.9);
                }
            });
        }
        // Script para mantener el modal de desactivar abierto si hay error en el servidor
        <% if (pnlErrorDesactivar.Visible) { %>
            window.onload = function () {
                var myModal = new bootstrap.Modal(document.getElementById('modalDesactivar'));
                myModal.show();
            };
        <% } %>
    </script>

</asp:Content>