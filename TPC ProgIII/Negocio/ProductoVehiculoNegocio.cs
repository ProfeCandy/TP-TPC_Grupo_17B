using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoVehiculoNegocio
    {
        public List<ProductoVehiculo> ListarPorProducto(int idProducto)
        {
            List<ProductoVehiculo> lista = new List<ProductoVehiculo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Tu consulta con JOIN está PERFECTA. La dejamos.
                string consulta = @"
                SELECT 
                    PV.IdProducto, 
                    PV.IdVehiculo, 
                    V.Marca, 
                    V.Modelo, 
                    PV.DetalleCompatibilidad, 
                    PV.Observaciones 
                FROM 
                    ProductoVehiculo AS PV
                INNER JOIN 
                    Vehiculo AS V ON PV.IdVehiculo = V.IdVehiculo
                WHERE 
                    PV.IdProducto = @idProducto";

                datos.setearConsulta(consulta);
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ProductoVehiculo aux = new ProductoVehiculo();

                    // --- ESTA ES LA FORMA CORRECTA DE MAPEAR ---

                    // 1. Crear el objeto Producto y llenarlo
                    aux.Producto = new Producto();
                    aux.Producto.IdProducto = (int)datos.Lector["IdProducto"];

                    // 2. Crear el objeto Vehiculo y llenarlo
                    aux.Vehiculo = new Vehiculo
                    {
                        IdVehiculo = (int)datos.Lector["IdVehiculo"],
                        Marca = (string)datos.Lector["Marca"],
                        Modelo = (string)datos.Lector["Modelo"]
                        // Puedes agregar más campos de Vehiculo al SELECT si los necesitas
                    };

                    // 3. Llenar los campos de la tabla de unión
                    aux.DetalleCompatibilidad = datos.Lector["DetalleCompatibilidad"] is DBNull ? null : (string)datos.Lector["DetalleCompatibilidad"];
                    aux.Observaciones = datos.Lector["Observaciones"] is DBNull ? null : (string)datos.Lector["Observaciones"];

                    lista.Add(aux);
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

        public void Agregar(ProductoVehiculo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ProductoVehiculo (IdProducto, IdVehiculo, DetalleCompatibilidad, Observaciones) VALUES (@IdProducto, @IdVehiculo, @Detalle, @Obs)");

                datos.setearParametro("@IdProducto", nuevo.Producto.IdProducto);
                datos.setearParametro("@IdVehiculo", nuevo.Vehiculo.IdVehiculo);

                    
                datos.setearParametro("@Detalle", (object)nuevo.DetalleCompatibilidad ?? DBNull.Value);
                datos.setearParametro("@Obs", (object)nuevo.Observaciones ?? DBNull.Value);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(ProductoVehiculo compatibilidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ProductoVehiculo SET DetalleCompatibilidad = @Detalle, Observaciones = @Obs WHERE IdProducto = @IdProducto AND IdVehiculo = @IdVehiculo");

                datos.setearParametro("@Detalle", (object)compatibilidad.DetalleCompatibilidad ?? DBNull.Value);
                datos.setearParametro("@Obs", (object)compatibilidad.Observaciones ?? DBNull.Value);
                datos.setearParametro("@IdProducto", compatibilidad.Producto.IdProducto);
                datos.setearParametro("@IdVehiculo", compatibilidad.Vehiculo.IdVehiculo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int idProducto, int idVehiculo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ProductoVehiculo WHERE IdProducto = @IdProducto AND IdVehiculo = @IdVehiculo");

                datos.setearParametro("@IdProducto", idProducto);
                datos.setearParametro("@IdVehiculo", idVehiculo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

