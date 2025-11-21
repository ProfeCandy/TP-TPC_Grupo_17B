<%@ Page Title="Historial de Pedidos" Language="C#" MasterPageFile="~/Dashboard_client/Dash_client.master" AutoEventWireup="true" CodeBehind="HistorialPedidos.aspx.cs" Inherits="Frontend.Dashboard_client.HistorialPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardBody" runat="server">

    <!-- dashboard content section -->
					<div class="col-12 col-md-9">
						<!-- recent activity section -->
						<div
							class="d-flex flex-column theme-border-radius theme-bg-white theme-box-shadow mb-4"
						>
							<!-- title section -->
							<div class="d-flex justify-content-between p-3">
								<span class="noto-sans fs-4 fw-bold">Historial de Pedidos</span>
							</div>
							<!-- order history section -->
							<div class="p-3">
								<div class="row g-0">
									<table>
										<thead>
											<tr>
												<th>Fecha Pedido</th>
												<th>Nro factura</th>
												<th>Monto</th>
												<th>Detalle</th>
											</tr>
										</thead>
										<tbody>
											<tr>
												<td>2024-08-01</td>
												<td>45978856</td>
												<td>$150.00</td>
												<td>
													<a
														href="#"
														data-bs-toggle="modal"
														data-bs-target="#quickViewModal"
														>Ver Detalle</a
													>
												</td>
											</tr>
											<tr>
												<td>2024-08-05</td>
												<td>45978859</td>
												<td>$200.00</td>
												<td>
													<a
														href="#"
														data-bs-toggle="modal"
														data-bs-target="#quickViewModal"
														>Ver Detalle</a
													>
												</td>
											</tr>
										</tbody>
									</table>
								</div>
							</div>
						</div>
					</div>

</asp:Content>