using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class RolNegocio
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdRol, NombreRol, Descripcion FROM Rol");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Rol aux = new Rol();
                    aux.IdRol = (int)datos.Lector["IdRol"];
                    aux.NombreRol = (string)datos.Lector["NombreRol"];

                    if (datos.Lector["Descripcion"] != DBNull.Value)
                        aux.Descripcion = (string)datos.Lector["Descripcion"];

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

        public void Agregar(Rol nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Rol (NombreRol, Descripcion) VALUES (@NombreRol, @Descripcion)");
                datos.setearParametro("@NombreRol", nuevo.NombreRol);
                datos.setearParametro("@Descripcion", (object)nuevo.Descripcion ?? DBNull.Value);
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

        public void Modificar(Rol rol)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Rol SET NombreRol = @NombreRol, Descripcion = @Descripcion WHERE IdRol = @IdRol");
                datos.setearParametro("@NombreRol", rol.NombreRol);
                datos.setearParametro("@Descripcion", (object)rol.Descripcion ?? DBNull.Value);
                datos.setearParametro("@IdRol", rol.IdRol);
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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Rol WHERE IdRol = @IdRol");
                datos.setearParametro("@IdRol", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
             //Esto fallará si un Usuario está usando este Rol.
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}