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
    }
}
