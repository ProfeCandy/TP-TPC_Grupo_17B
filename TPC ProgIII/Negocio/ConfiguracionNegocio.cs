using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ConfiguracionNegocio
    {
        public string ObtenerValor(string clave)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Valor FROM Configuracion WHERE Clave = @Clave");
                datos.setearParametro("@Clave", clave);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (string)datos.Lector["Valor"];
                }
                return null;
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

        public void ActualizarValor(string clave, string valor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Configuracion SET Valor = @Valor WHERE Clave = @Clave");
                datos.setearParametro("@Valor", valor);
                datos.setearParametro("@Clave", clave);
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

        public void Agregar(string clave, string valor, string descripcion = null)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Configuracion (Clave, Valor, Descripcion) VALUES (@Clave, @Valor, @Descripcion)");
                datos.setearParametro("@Clave", clave);
                datos.setearParametro("@Valor", valor);
                datos.setearParametro("@Descripcion", (object)descripcion ?? DBNull.Value);
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

