using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VehiculoNegocio
    {
        public List<Vehiculo> Listar()
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("SELECT IdVehiculo, Marca, Modelo, AñoDesde, AñoHasta, Motor, Tipo FROM Vehiculos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Vehiculo veh = new Vehiculo();
                    veh.IdVehiculo = (int)datos.Lector["IdVehiculo"];
                    veh.Marca = (string)datos.Lector["Marca"];
                    veh.Modelo = (string)datos.Lector["Modelo"];
                    veh.AñoDesde = (short)datos.Lector["AñoDesde"];

                    if (!(datos.Lector["AñoHasta"] is DBNull))
                    {
                        veh.AñoHasta = (short)datos.Lector["AñoHasta"];
                    }
                    else
                    {
                        veh.AñoHasta = null;
                    }

                    veh.Motor = (string)datos.Lector["Motor"];
                    veh.Tipo = (string)datos.Lector["Tipo"];

                    lista.Add(veh);
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

        public void Agregar(Vehiculo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO Vehiculos (Marca, Modelo, AñoDesde, AñoHasta, Motor, Tipo) 
                                       VALUES (@Marca, @Modelo, @AñoDesde, @AñoHasta, @Motor, @Tipo);
                                       SELECT SCOPE_IDENTITY();"); 

                datos.setearParametro("@Marca", nuevo.Marca);
                datos.setearParametro("@Modelo", nuevo.Modelo);
                datos.setearParametro("@AñoDesde", nuevo.AñoDesde);

                
                datos.setearParametro("@AñoHasta", (object)nuevo.AñoHasta ?? DBNull.Value);

                datos.setearParametro("@Motor", nuevo.Motor);
                datos.setearParametro("@Tipo", nuevo.Tipo);


                datos.ejecutarLectura();


                if (datos.Lector.Read())
                {
                    nuevo.IdVehiculo = Convert.ToInt32(datos.Lector[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(Vehiculo vehiculo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"UPDATE Vehiculos 
                                       SET Marca = @Marca, Modelo = @Modelo, AñoDesde = @AñoDesde, 
                                           AñoHasta = @AñoHasta, Motor = @Motor, Tipo = @Tipo 
                                       WHERE IdVehiculo = @IdVehiculo");

                datos.setearParametro("@Marca", vehiculo.Marca);
                datos.setearParametro("@Modelo", vehiculo.Modelo);
                datos.setearParametro("@AñoDesde", vehiculo.AñoDesde);
                datos.setearParametro("@AñoHasta", (object)vehiculo.AñoHasta ?? DBNull.Value);
                datos.setearParametro("@Motor", vehiculo.Motor);
                datos.setearParametro("@Tipo", vehiculo.Tipo);

                // Importante: el parámetro para el WHERE
                datos.setearParametro("@IdVehiculo", vehiculo.IdVehiculo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Vehiculos WHERE IdVehiculo = @IdVehiculo");
                datos.setearParametro("@IdVehiculo", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
