<%@ Page Title="Finalizar Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Frontend.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <div class="row">
            
            <div class="col-md-8">
                
                <%--PASO 1: DATOS DE CONTACTO--%>
                <div class="card shadow-sm mb-4">
                    
                    <%--HEADER PASO 1--%>
                    <div class="card-header bg-white py-3 d-flex justify-content-between align-items-center">
                        <h5 class="mb-0 fw-bold text-danger">1. Datos de Contacto</h5>
                        <asp:LinkButton ID="btnEditarContacto" runat="server" Visible="false" OnClick="btnEditarContacto_Click" CssClass="text-decoration-none small text-danger fw-bold">Editar</asp:LinkButton>
                    </div>

                    <%--PASO 1: Formulario--%>
                    <asp:Panel ID="pnlContacto" runat="server" CssClass="card-body">
                        
                        <%--SI ES INVITADO (NO LOGUEADO)--%>
                        <asp:Panel ID="pnlIngresoGuest" runat="server">
                            <p class="small text-muted">¿Ya tenés cuenta? <a runat="server" href="~/Usuarios/Login.aspx" class="text-danger fw-bold">Iniciar Sesión</a> para autocompletar.</p>             
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtEmailCheckout" runat="server" CssClass="form-control" TextMode="Email" Placeholder="Email"></asp:TextBox>
                                <label>Correo Electrónico</label>
                                <%--Validacion Email--%>
                                <asp:RequiredFieldValidator ControlToValidate="txtEmailCheckout" runat="server" CssClass="text-danger small" ErrorMessage="Email requerido" Display="Dynamic" />
                                <asp:RequiredFieldValidator ErrorMessage="El email es requerido." ControlToValidate="txtEmailCheckout" runat="server" 
                                    CssClass="text-danger small" Display="Dynamic" />
                                <asp:RegularExpressionValidator ErrorMessage="Formato de email inválido." ControlToValidate="txtEmailCheckout" runat="server" 
                                    ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" CssClass="text-danger small" Display="Dynamic" />
                            </div>
                            
                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtNombreFacturacion" runat="server" CssClass="form-control" Placeholder="Nombre"></asp:TextBox>
                                        <label>Nombre</label>
                                        <%--Validacion Nombre--%>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNombreFacturacion" runat="server" CssClass="text-danger small" ErrorMessage="Campo Obligatorio" Display="Dynamic" />
                                            <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="txtNombreFacturacion" runat="server" CssClass="text-danger small" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtNombreFacturacion" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />
                                    </div>
                                </div>
                                <div class="col-md-6 mb-3">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtApellidoFacturacion" runat="server" CssClass="form-control" Placeholder="Apellido"></asp:TextBox>
                                        <label>Apellido</label>
                                        <%--Validacion Apellido--%>
                                            <asp:RequiredFieldValidator ControlToValidate="txtApellidoFacturacion" runat="server" CssClass="text-danger small" ErrorMessage="Campo Obligatorio" Display="Dynamic" />
                                            <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="txtApellidoFacturacion" runat="server" CssClass="text-danger small" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtApellidoFacturacion" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        <%--SI ESTÁ LOGUEADO--%>
                        <asp:Panel ID="pnlUsuarioLogueado" runat="server" Visible="false">
                            <div class="alert alert-secondary d-flex justify-content-between align-items-center">
                                <span>Estás comprando como: <strong class="text-dark"><asp:Label ID="lblNombreUsuario" runat="server"></asp:Label></strong> (<asp:Label ID="lblEmailUsuario" runat="server"></asp:Label>)</span>
                                <asp:LinkButton ID="lnkCambiarCuenta" runat="server" CssClass="btn btn-sm btn-outline-secondary" OnClick="lnkCambiarCuenta_Click" CausesValidation="false">Cambiar cuenta</asp:LinkButton>
                            </div>
                        </asp:Panel>

                        <div class="d-flex justify-content-end mt-3">
                            <asp:Button ID="btnSiguienteEnvio" runat="server" Text="Continuar a Envío" OnClick="btnSiguienteEnvio_Click" CssClass="btn btn-danger" />
                        </div>
                    </asp:Panel>
                </div>

                <%--PASO 2: ENTREGA--%>

                <asp:Panel ID="pnlEntrega" runat="server" CssClass="card shadow-sm mb-4" Visible="false">
                    
                    <%--HEADER PASO 2--%>
                    <div class="card-header bg-white py-3 d-flex justify-content-between align-items-center">
                        <h5 class="mb-0 fw-bold text-muted">2. Entrega</h5>
                        <asp:LinkButton ID="btnEditarEntrega" runat="server" Visible="false" OnClick="btnEditarEntrega_Click" CssClass="text-decoration-none small text-danger fw-bold">Editar</asp:LinkButton>
                    </div>
                    
                    <%--PASO 2: Formulario--%>
                    <asp:Panel ID="pnlEntregaContent" runat="server" CssClass="card-body">
                        
                        <%--DOMICILIO--%>
                        <div class="card mb-3 border-secondary-subtle">
                            <div class="card-body">
                                <div class="form-check">
                                    <asp:RadioButton ID="rdbDomicilio" runat="server" GroupName="TipoEnvio" 
                                        AutoPostBack="true" OnCheckedChanged="MetodoEnvio_CheckedChanged" 
                                        CssClass="form-check-input position-static" />
                                    
                                    <label class="form-check-label w-100 ms-2" for="<%= rdbDomicilio.ClientID %>">
                                        <div class="d-flex justify-content-between align-items-center">
                                            <span class="fw-bold text-dark">Envío a domicilio estándar</span>
                                            <span class="badge bg-success text-white">Coordinar con el vendedor</span>
                                        </div>
                                        <div class="text-muted small mt-1">Llega entre 5 a 10 días hábiles</div>
                                    </label>
                                </div>
                            </div>
                        </div>

                        <%--FORMULARIO DIRECCIÓN (Solo si elige Domicilio)--%>
                        <asp:Panel ID="pnlDatosEnvio" runat="server" Visible="false" CssClass="mb-4 ps-4 border-start border-3 border-danger bg-light py-3 pe-3 rounded-end">
                            <h6 class="fw-bold mb-3 text-danger">Datos del destinatario</h6>
    
                            <div class="row">
                                <div class="col-md-6 mb-2">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" Placeholder="Calle"></asp:TextBox>
                                        <label>Calle</label>
                                        <%--Validacion Calle--%>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCalle" 
                                            ValidationGroup="Entrega" ErrorMessage="Calle requerida" 
                                            CssClass="text-danger small" Display="Dynamic" />
                                        <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="txtCalle" runat="server" CssClass="text-danger small" Display="Dynamic" />
                                        <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtCalle" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />
                                    </div>
                                </div>
        
                                <div class="col-md-3 mb-2">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtAltura" runat="server" CssClass="form-control" Placeholder="Altura"></asp:TextBox>
                                        <label>Altura</label>
                                        <%--Validacion Altura--%>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAltura" 
                                            ValidationGroup="Entrega" ErrorMessage="Altura requerida" 
                                            CssClass="text-danger small" Display="Dynamic" />
                                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtAltura"
                                            ValidationGroup="Entrega" ErrorMessage="Solo números" 
                                            ValidationExpression="^[0-9]+$" CssClass="text-danger small" Display="Dynamic" />
                                    </div>
                                </div>
        
                                <div class="col-md-3 mb-2">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" Placeholder="CP"></asp:TextBox>
                                        <label>C.P.</label>
                                        <%--Validacion CP--%>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCP" 
                                            ValidationGroup="Entrega" ErrorMessage="C.P requerido" 
                                            CssClass="text-danger small" Display="Dynamic" />
                                         <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCP"
                                            ValidationGroup="Entrega" ErrorMessage="Solo números" 
                                            ValidationExpression="^[0-9]+$" CssClass="text-danger small" Display="Dynamic" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-2">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" Placeholder="Localidad"></asp:TextBox>
                                        <label>Localidad</label>
                                        <%--Validacion Localidad--%>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLocalidad" 
                                            ValidationGroup="Entrega" ErrorMessage="Localidad requerida" 
                                            CssClass="text-danger small" Display="Dynamic" />
                                        <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="txtLocalidad" runat="server" CssClass="text-danger small" Display="Dynamic" />
                                        <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtLocalidad" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />
                                    </div>
                                </div>
        
                                <div class="col-md-6 mb-2">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" Placeholder="Provincia"></asp:TextBox>
                                        <label>Provincia</label>
                                        <%--Validacion Provincia--%>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtProvincia" 
                                            ValidationGroup="Entrega" ErrorMessage="Provincia requerida" 
                                            CssClass="text-danger small" Display="Dynamic" />
                                        <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="txtProvincia" runat="server" CssClass="text-danger small" Display="Dynamic" />
                                        <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtProvincia" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        <%--RETIRO--%>
                        <div class="card mb-4 border-secondary-subtle">
                            <div class="card-body">
                                <div class="form-check">
                                    <asp:RadioButton ID="rdbRetiro" runat="server" GroupName="TipoEnvio" 
                                        AutoPostBack="true" OnCheckedChanged="MetodoEnvio_CheckedChanged"
                                        CssClass="form-check-input position-static" />
                                    
                                    <label class="form-check-label w-100 ms-2" for="<%= rdbRetiro.ClientID %>">
                                        <div class="d-flex justify-content-between align-items-center">
                                            <span class="fw-bold text-dark">Retiras en UTN - Gral Pacheco</span>
                                            <span class="fw-bold text-success">Gratis</span>
                                        </div>
                                        <div class="text-muted small mt-1">
                                            <i class="bi bi-geo-alt-fill me-1"></i>Av. Hipolito Yrigoyen 288 <br />
                                            <i class="bi bi-clock-fill me-1"></i>Lunes a Viernes de 8 a 22 hs
                                        </div>
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="d-flex justify-content-end">
                            <%--<asp:Button ID="btnSiguientePago" runat="server" Text="Continuar a Pago" OnClick="btnSiguientePago_Click" CssClass="btn btn-danger" Visible="false" />--%>
                            <asp:Button ID="btnSiguientePago" runat="server" Text="Continuar a Pago" 
                            OnClick="btnSiguientePago_Click" CssClass="btn btn-danger" Visible="false" 
                            ValidationGroup="Entrega" />
                        </div>

                    </asp:Panel>
                </asp:Panel>

                <%--PASO 3: PAGO--%>

                <asp:Panel ID="pnlPago" runat="server" CssClass="card shadow-sm mb-4" Visible="false">

                     <%--HEADER PASO 3--%>
                    <div class="card-header bg-white py-3">
                        <h5 class="mb-0 fw-bold text-muted">3. Pago</h5>
                    </div>
    
                    <asp:Panel ID="pnlPagoContent" runat="server" CssClass="card-body">
        
                        <div class="mb-3">Seleccione el método de pago:</div>

                         <%--MP--%>
                        <div class="card mb-3 border-secondary-subtle">
                            <div class="card-body">
                                <div class="form-check d-flex align-items-center">
                                    <asp:RadioButton ID="rdbMercadoPago" runat="server" GroupName="MetodoPago" 
                                        AutoPostBack="true" OnCheckedChanged="MetodoPago_CheckedChanged" 
                                        CssClass="form-check-input position-static" />
                    
                                    <label class="form-check-label w-100 ms-2 cursor-pointer" for="<%= rdbMercadoPago.ClientID %>">
                                        <div class="d-flex justify-content-between align-items-center">
                                            <span class="fw-bold text-dark">
                                                <i class="bi bi-credit-card-2-front me-2 text-primary"></i>MercadoPago
                                            </span>
                                            <img src="https://s2-epocanegocios.glbimg.com/DMXmd-WzawP_229LQYtg-xzqmB8=/0x0:2000x2000/600x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_e536e40f1baf4c1a8bf1ed12d20577fd/internal_photos/bs/2023/F/r/nmbh02SOujd76Bn8z4DQ/logo-mp-vertical.png" alt="MP" style="height: 24px;" />
                                        </div>
                                    </label>
                                </div>
                
                                <asp:Panel ID="pnlInfoMP" runat="server" Visible="false" CssClass="mt-3 ps-4 border-start border-3 border-primary bg-light py-2 pe-2">
                                    <p class="mb-0 small text-muted">
                                        Tranqui! Esto es un simuladorde compra. No te vamos a pedir la tarjeta ni a cobrarte nada real...por ahora. Tu plata está a salvo con nosotros.
                                    </p>
                                </asp:Panel>
                            </div>
                        </div>
                        <%--TRANSFERENCIA--%>
                        <div class="card mb-4 border-secondary-subtle">
                            <div class="card-body">
                                <div class="form-check d-flex align-items-center">
                                    <asp:RadioButton ID="rdbTransferencia" runat="server" GroupName="MetodoPago" 
                                        AutoPostBack="true" OnCheckedChanged="MetodoPago_CheckedChanged" 
                                        CssClass="form-check-input position-static" />
                    
                                    <label class="form-check-label w-100 ms-2 cursor-pointer" for="<%= rdbTransferencia.ClientID %>">
                                        <div class="d-flex justify-content-between align-items-center">
                                            <span class="fw-bold text-dark">
                                                <i class="bi bi-bank me-2 text-success"></i>Transferencia Bancaria
                                            </span>
                                        </div>
                                    </label>
                                </div>
                                 <%--TRANSFERENCIA INFO REF--%>
                                <asp:Panel ID="pnlInfoTransferencia" runat="server" Visible="false" CssClass="mt-3">
                    
                                    <div class="alert alert-secondary small">
                                        <h6 class="fw-bold mb-2"><i class="bi bi-info-circle me-1"></i>Datos para la transferencia:</h6>
                                        <ul class="list-unstyled mb-0">
                                            <li><strong>Banco:</strong> Santander Río</li>
                                            <li><strong>CBU:</strong> 0720117888000036092992</li>
                                            <li><strong>Alias:</strong> AUTOPARTS.VENTAS</li>
                                            <li><strong>Titular:</strong> AutoParts S.A.</li>
                                        </ul>
                                    </div>

                                    <div class="ps-3 border-start border-3 border-success">
                                        <h6 class="fw-bold mb-3 text-success">Ingresá los datos de tu pago</h6>
                                        <div class="row">
                                            <div class="col-md-6 mb-2">
                                                <div class="form-floating">
                                                    <asp:TextBox ID="txtBancoOrigen" runat="server" CssClass="form-control" Placeholder="Banco"></asp:TextBox>
                                                    <label>Tu Banco</label>
                                                    <%--Validacion Banco--%>
                                                        <asp:RequiredFieldValidator ControlToValidate="txtBancoOrigen" runat="server" CssClass="text-danger small" ErrorMessage="Campo Obligatorio" Display="Dynamic" />
                                                        <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="txtBancoOrigen" runat="server" CssClass="text-danger small" Display="Dynamic" />
                                                        <asp:RegularExpressionValidator ErrorMessage="Sin números" ControlToValidate="txtBancoOrigen" runat="server" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" CssClass="text-danger small" Display="Dynamic" />
                                                </div>
                                            </div>
                                            <div class="col-md-6 mb-2">
                                                <div class="form-floating">
                                                    <asp:TextBox ID="txtNumeroComprobante" runat="server" CssClass="form-control" Placeholder="Nro Comprobante"></asp:TextBox>
                                                    <label>Nro. Comprobante / Alias</label>
                                                    <%--Validacion Nro. Comprobante / Alias--%>
                                                        <asp:RequiredFieldValidator ControlToValidate="txtNumeroComprobante" runat="server" CssClass="text-danger small" ErrorMessage="Campo Obligatorio" Display="Dynamic" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>
                            </div>
                        </div>

                         <%-- BOTÓN FINALIZAR COMPRA--%>
                        <div class="d-grid mt-4">
                            <asp:Button ID="btnFinalizar" runat="server" Text="FINALIZAR COMPRA"
                                CssClass="btn btn-lg btn-success text-uppercase fw-bold" 
                                OnClick="btnFinalizar_Click" Visible="false" />
                        </div>

                    </asp:Panel>
                </asp:Panel>                   
            </div>

            <%--RESUMEN DEL PEDIDO--%>
            <div class="col-md-4">
                <div class="card shadow-sm border-0 bg-light sticky-top" style="top: 100px; z-index: 1;">
                    <div class="card-body">
                        <h5 class="fw-bold mb-3 border-bottom pb-2">Resumen del Pedido</h5>
                        
                        <asp:Repeater ID="repResumenCarrito" runat="server">
                            <ItemTemplate>
                                <div class="d-flex justify-content-between mb-2 small">
                                    <span><%# Eval("Producto.NombreProducto") %> <span class="text-muted">x <%# Eval("Cantidad") %></span></span>
                                    <span class="fw-bold">$<%# (Convert.ToDecimal(Eval("Producto.Precio")) * Convert.ToInt32(Eval("Cantidad"))).ToString("N0") %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <hr />
                        <div class="d-flex justify-content-between fw-bold fs-5 text-danger">
                            <span>Total</span>
                            <asp:Label ID="lblTotal" runat="server" Text="$ 0"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>