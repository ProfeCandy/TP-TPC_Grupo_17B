using System;

namespace Negocio
{
    public class ReservaStockNegocio
    {
        private const int MINUTOS_RESERVA = 30;

        public bool ReservarStock(int idProducto, int cantidad, string sessionId)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                int stockDisponible = ObtenerStockDisponible(idProducto);
                
                if (cantidad > stockDisponible)
                {
                    return false;
                }

                DateTime fechaExpiracion = DateTime.Now.AddMinutes(MINUTOS_RESERVA);

                datos.setearConsulta(@"INSERT INTO ReservaStock (IdProducto, Cantidad, SessionId, FechaReserva, FechaExpiracion) 
                                      VALUES (@IdProducto, @Cantidad, @SessionId, GETDATE(), @FechaExpiracion)");
                
                datos.setearParametro("@IdProducto", idProducto);
                datos.setearParametro("@Cantidad", cantidad);
                datos.setearParametro("@SessionId", sessionId);
                datos.setearParametro("@FechaExpiracion", fechaExpiracion);

                datos.ejecutarAccion();
                return true;
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

        public void ActualizarReserva(int idProducto, int cantidadAnterior, int cantidadNueva, string sessionId)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                EliminarReserva(idProducto, cantidadAnterior, sessionId);
                
                if (cantidadNueva > 0)
                {
                    ReservarStock(idProducto, cantidadNueva, sessionId);
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

        public void EliminarReserva(int idProducto, int cantidad, string sessionId)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"DELETE FROM ReservaStock 
                                      WHERE IdReserva IN (
                                          SELECT TOP (@Cantidad) IdReserva
                                          FROM ReservaStock 
                                          WHERE IdProducto = @IdProducto 
                                          AND SessionId = @SessionId 
                                          AND FechaExpiracion > GETDATE()
                                          ORDER BY FechaReserva ASC
                                      )");
                
                datos.setearParametro("@IdProducto", idProducto);
                datos.setearParametro("@SessionId", sessionId);
                datos.setearParametro("@Cantidad", cantidad);

                datos.ejecutarAccion();
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

        public void LiberarReservasExpiradas()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ReservaStock WHERE FechaExpiracion < GETDATE()");
                datos.ejecutarAccion();
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

        public int ObtenerStockDisponible(int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"SELECT ISNULL(P.Stock, 0) - ISNULL(SUM(R.Cantidad), 0) AS StockDisponible
                                      FROM Producto P
                                      LEFT JOIN ReservaStock R ON P.IdProducto = R.IdProducto 
                                          AND R.FechaExpiracion > GETDATE()
                                      WHERE P.IdProducto = @IdProducto
                                      GROUP BY P.Stock");
                
                datos.setearParametro("@IdProducto", idProducto);
                datos.ejecutarLectura();

                int stockDisponible = 0;
                if (datos.Lector.Read())
                {
                    stockDisponible = Convert.ToInt32(datos.Lector["StockDisponible"]);
                    if (stockDisponible < 0) stockDisponible = 0;
                }

                return stockDisponible;
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

        public void LiberarReservasPorSesion(string sessionId)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ReservaStock WHERE SessionId = @SessionId");
                datos.setearParametro("@SessionId", sessionId);
                datos.ejecutarAccion();
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

