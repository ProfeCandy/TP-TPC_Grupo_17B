using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            RolNegocio rolNegocio = new RolNegocio();
            List<Rol> listaDeRoles = rolNegocio.Listar();
            List<Usuario> listaDeUsuarios = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"
            SELECT 
                IdUsuario, Nombre, Apellido, Email, Telefono, 
                Direccion, Localidad, FechaRegistro, Activo,
                IdRol 
            FROM 
                Usuario";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];

                    if (datos.Lector["Telefono"] != DBNull.Value)
                        aux.Telefono = (string)datos.Lector["Telefono"];

                    if (datos.Lector["Direccion"] != DBNull.Value)
                        aux.Direccion = (string)datos.Lector["Direccion"];

                    if (datos.Lector["Localidad"] != DBNull.Value)
                        aux.Localidad = (string)datos.Lector["Localidad"];

                    aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    int idRolDelUsuario = (int)datos.Lector["IdRol"];
                    aux.Rol = listaDeRoles.Find(r => r.IdRol == idRolDelUsuario);

                    listaDeUsuarios.Add(aux);
                }
                return listaDeUsuarios;
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
        public void Agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"
                    INSERT INTO Usuario (Nombre, Apellido, Email, Telefono, Direccion, Localidad, IdRol) 
                    VALUES (@Nombre, @Apellido, @Email, @Telefono, @Direccion, @Localidad, @IdRol)";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Telefono", (object)nuevo.Telefono ?? DBNull.Value);
                datos.setearParametro("@Direccion", (object)nuevo.Direccion ?? DBNull.Value);
                datos.setearParametro("@Localidad", (object)nuevo.Localidad ?? DBNull.Value);

                datos.setearParametro("@IdRol", nuevo.Rol.IdRol);

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

        public void Modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"
                    UPDATE Usuario SET 
                        Nombre = @Nombre, Apellido = @Apellido, Email = @Email, 
                        Telefono = @Telefono, Direccion = @Direccion, 
                        Localidad = @Localidad, IdRol = @IdRol, Activo = @Activo 
                    WHERE 
                        IdUsuario = @IdUsuario";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Telefono", (object)usuario.Telefono ?? DBNull.Value);
                datos.setearParametro("@Direccion", (object)usuario.Direccion ?? DBNull.Value);
                datos.setearParametro("@Localidad", (object)usuario.Localidad ?? DBNull.Value);
                datos.setearParametro("@IdRol", usuario.Rol.IdRol);
                datos.setearParametro("@Activo", usuario.Activo);
                datos.setearParametro("@IdUsuario", usuario.IdUsuario);

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

        // Eliminación Física
        public void EliminarFisico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Esto fallará si el usuario tiene Pedidos o Carrito asociados, por las claves foráneas.
                datos.setearConsulta("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario");
                datos.setearParametro("@IdUsuario", id);
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

        // Eliminación Lógica
        public void EliminarLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuario SET Activo = 0 WHERE IdUsuario = @IdUsuario");
                datos.setearParametro("@IdUsuario", id);
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