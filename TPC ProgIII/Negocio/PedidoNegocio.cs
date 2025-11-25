using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidoNegocio
    {
        public void Guardar(Pedido pedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"INSERT INTO Pedido (IdUsuario, FechaPedido, Estado, Total, MetodoEnvio, CostoEnvio, DireccionEnvio, LocalidadEnvio, ProvinciaEnvio, CodigoPostal, MetodoPago) 
                                       VALUES (@IdUsuario, getdate(), 'Pendiente', @Total, @MetodoEnvio, @CostoEnvio, @DireccionEnvio, @LocalidadEnvio, @ProvinciaEnvio, @CodigoPostal, @MetodoPago); 
                                       SELECT SCOPE_IDENTITY();");

                datos.setearParametro("@IdUsuario", pedido.Usuario.IdUsuario);
                datos.setearParametro("@Total", pedido.Total);
                datos.setearParametro("@MetodoEnvio", pedido.MetodoEnvio);
                datos.setearParametro("@CostoEnvio", pedido.CostoEnvio);

                // Si es retiro en sucursal, los campos quedan nulos
                datos.setearParametro("@DireccionEnvio", (object)pedido.DireccionEnvio ?? DBNull.Value);
                datos.setearParametro("@LocalidadEnvio", (object)pedido.LocalidadEnvio ?? DBNull.Value);
                datos.setearParametro("@ProvinciaEnvio", (object)pedido.ProvinciaEnvio ?? DBNull.Value);
                datos.setearParametro("@CodigoPostal", (object)pedido.CodigoPostal ?? DBNull.Value);

                datos.setearParametro("@MetodoPago", pedido.MetodoPago);

                datos.ejecutarLectura();

                int idPedidoGenerado = 0;
                if (datos.Lector.Read())
                {
                    // Trae el resultado del scope identity como decimal y convierte a int
                    idPedidoGenerado = decimal.ToInt32((decimal)datos.Lector[0]);
                }
                datos.cerrarConexion();

                foreach (var item in pedido.Detalles)
                {
                    AccesoDatos datosDetalle = new AccesoDatos();
                    datosDetalle.setearConsulta("INSERT INTO DetallePedido (IdPedido, IdProducto, Cantidad, PrecioUnitario) VALUES (@IdPedido, @IdProducto, @Cantidad, @PrecioUnitario)");

                    datosDetalle.setearParametro("@IdPedido", idPedidoGenerado);
                    datosDetalle.setearParametro("@IdProducto", item.Producto.IdProducto);
                    datosDetalle.setearParametro("@Cantidad", item.Cantidad);
                    datosDetalle.setearParametro("@PrecioUnitario", item.PrecioUnitario);

                    datosDetalle.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Pedido> ListarPorUsuario(int idUsuario)
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdPedido, FechaPedido, Estado, Total, MetodoEnvio, MetodoPago FROM Pedido WHERE IdUsuario = @IdUsuario ORDER BY FechaPedido DESC");
                datos.setearParametro("@IdUsuario", idUsuario);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.IdPedido = (int)datos.Lector["IdPedido"];
                    pedido.FechaPedido = (DateTime)datos.Lector["FechaPedido"];
                    pedido.Estado = (string)datos.Lector["Estado"];
                    pedido.Total = (decimal)datos.Lector["Total"];

                    if (!(datos.Lector["MetodoEnvio"] is DBNull))
                        pedido.MetodoEnvio = (string)datos.Lector["MetodoEnvio"];

                    if (!(datos.Lector["MetodoPago"] is DBNull))
                        pedido.MetodoPago = (string)datos.Lector["MetodoPago"];

                    lista.Add(pedido);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Pedido ObtenerPedidoConDetalles(int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"SELECT IdPedido, FechaPedido, Estado, Total, MetodoEnvio, MetodoPago, 
                                      DireccionEnvio, LocalidadEnvio, ProvinciaEnvio, CodigoPostal 
                               FROM Pedido WHERE IdPedido = @IdPedido");

                datos.setearParametro("@IdPedido", idPedido);
                datos.ejecutarLectura();

                Pedido pedido = null;

                if (datos.Lector.Read())
                {
                    pedido = new Pedido();
                    pedido.IdPedido = (int)datos.Lector["IdPedido"];
                    pedido.FechaPedido = (DateTime)datos.Lector["FechaPedido"];
                    pedido.Estado = (string)datos.Lector["Estado"];
                    pedido.Total = (decimal)datos.Lector["Total"];

                    if (!(datos.Lector["MetodoEnvio"] is DBNull))
                        pedido.MetodoEnvio = (string)datos.Lector["MetodoEnvio"];

                    if (!(datos.Lector["MetodoPago"] is DBNull))
                        pedido.MetodoPago = (string)datos.Lector["MetodoPago"];

                    if (!(datos.Lector["DireccionEnvio"] is DBNull))
                        pedido.DireccionEnvio = (string)datos.Lector["DireccionEnvio"];

                    if (!(datos.Lector["LocalidadEnvio"] is DBNull))
                        pedido.LocalidadEnvio = (string)datos.Lector["LocalidadEnvio"];

                    if (!(datos.Lector["ProvinciaEnvio"] is DBNull))
                        pedido.ProvinciaEnvio = (string)datos.Lector["ProvinciaEnvio"];

                    if (!(datos.Lector["CodigoPostal"] is DBNull))
                        pedido.CodigoPostal = (string)datos.Lector["CodigoPostal"];

                }
                datos.cerrarConexion();

                if (pedido != null)
                {
                    pedido.Detalles = new List<DetallePedido>();

                    datos.setearConsulta(@"SELECT D.IdDetalle, D.IdProducto, D.Cantidad, D.PrecioUnitario,
                                          P.NombreProducto, M.Descripcion as Marca
                                   FROM DetallePedido D
                                   INNER JOIN Producto P ON D.IdProducto = P.IdProducto
                                   INNER JOIN Marcas M ON P.IdMarca = M.IdMarca
                                   WHERE D.IdPedido = @IdPedido");

                    datos.setearParametro("@IdPedido", idPedido);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        DetallePedido detalle = new DetallePedido();
                        detalle.IdDetalle = (int)datos.Lector["IdDetalle"];
                        detalle.IdPedido = idPedido;
                        detalle.Cantidad = (int)datos.Lector["Cantidad"];
                        detalle.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];

                        detalle.Producto = new Producto();
                        detalle.Producto.IdProducto = (int)datos.Lector["IdProducto"];
                        detalle.Producto.NombreProducto = (string)datos.Lector["NombreProducto"];
                        detalle.Producto.Marca = new Marca { Descripcion = (string)datos.Lector["Marca"] };

                        pedido.Detalles.Add(detalle);
                    }
                }

                return pedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
