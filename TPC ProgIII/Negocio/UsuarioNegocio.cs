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

        public Usuario BuscarUsuarioPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"
                    SELECT u.IdUsuario, u.Nombre, u.Apellido, u.Email, u.Telefono, 
                           u.Direccion, u.Localidad, u.FechaRegistro, u.Activo, 
                           u.IdRol, r.NombreRol
                    FROM Usuario u
                    INNER JOIN Rol r ON u.IdRol = r.IdRol
                    WHERE u.IdUsuario = @IdUsuario";

                datos.setearConsulta(consulta);
                datos.setearParametro("@IdUsuario", id);
                datos.ejecutarLectura();

                Usuario usuario = null;

                if (datos.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Email = (string)datos.Lector["Email"];

                    // Validaciones de nulos (DBNull)
                    if (!(datos.Lector["Telefono"] is DBNull))
                        usuario.Telefono = (string)datos.Lector["Telefono"];

                    if (!(datos.Lector["Direccion"] is DBNull))
                        usuario.Direccion = (string)datos.Lector["Direccion"];

                    if (!(datos.Lector["Localidad"] is DBNull))
                        usuario.Localidad = (string)datos.Lector["Localidad"];

                    // Validar FechaRegistro x las dudas
                    if (!(datos.Lector["FechaRegistro"] is DBNull))
                        usuario.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];

                    usuario.Activo = (bool)datos.Lector["Activo"];

                    usuario.Rol = new Rol();
                    usuario.Rol.IdRol = (int)datos.Lector["IdRol"];

                    if (!(datos.Lector["NombreRol"] is DBNull))
                        usuario.Rol.NombreRol = (string)datos.Lector["NombreRol"];
                }

                return usuario;
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
        
        public int Agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"
                    INSERT INTO Usuario (Nombre, Apellido, Email, Clave, Telefono, Direccion, Localidad, IdRol) 
                    VALUES (@Nombre, @Apellido, @Email, @Clave, @Telefono, @Direccion, @Localidad, @IdRol);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Telefono", (object)nuevo.Telefono ?? DBNull.Value);
                datos.setearParametro("@Direccion", (object)nuevo.Direccion ?? DBNull.Value);
                datos.setearParametro("@Localidad", (object)nuevo.Localidad ?? DBNull.Value);
                datos.setearParametro("@Clave", nuevo.Clave);
                datos.setearParametro("@IdRol", nuevo.Rol.IdRol);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    int idUsuario = (int)datos.Lector[0];
                    return idUsuario;
                }
                return 0;
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

        // Login
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"
                    SELECT u.IdUsuario, u.IdRol, u.Nombre, u.Apellido, u.Email, u.Telefono, u.Direccion, u.Localidad, u.Activo, u.EmailConfirmado, r.NombreRol 
                    FROM Usuario u
                    LEFT JOIN Rol r ON u.IdRol = r.IdRol
                    WHERE u.Email = @Email AND u.Clave = @Clave");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Clave", usuario.Clave);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.Rol = new Rol();
                    usuario.Rol.IdRol = (int)datos.Lector["IdRol"];
                    usuario.Rol.NombreRol = datos.Lector["NombreRol"] != DBNull.Value ? (string)datos.Lector["NombreRol"] : "";

                    usuario.Nombre = datos.Lector["Nombre"] != DBNull.Value ? (string)datos.Lector["Nombre"] : "";
                    usuario.Apellido = datos.Lector["Apellido"] != DBNull.Value ? (string)datos.Lector["Apellido"] : "";
                    usuario.Email = datos.Lector["Email"] != DBNull.Value ? (string)datos.Lector["Email"] : "";
                    usuario.Telefono = datos.Lector["Telefono"] != DBNull.Value ? (string)datos.Lector["Telefono"] : "";
                    usuario.Direccion = datos.Lector["Direccion"] != DBNull.Value ? (string)datos.Lector["Direccion"] : "";
                    usuario.Localidad = datos.Lector["Localidad"] != DBNull.Value ? (string)datos.Lector["Localidad"] : "";
                    usuario.Activo = (bool)datos.Lector["Activo"];
                    usuario.EmailConfirmado = datos.Lector["EmailConfirmado"] != DBNull.Value ? (bool)datos.Lector["EmailConfirmado"] : false;

                    return true;
                }
                return false;
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

        // Método para generar token de confirmación
        public void GenerarTokenConfirmacion(int idUsuario, string token)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuario SET TokenConfirmacion = @Token WHERE IdUsuario = @IdUsuario");
                datos.setearParametro("@Token", token);
                datos.setearParametro("@IdUsuario", idUsuario);
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

        // Método para confirmar email
        public void ConfirmarEmail(string token)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuario SET EmailConfirmado = 1, TokenConfirmacion = NULL WHERE TokenConfirmacion = @Token");
                datos.setearParametro("@Token", token);
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

        // Método para buscar usuario por email
        public Usuario BuscarPorEmail(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdUsuario, Nombre, Apellido, Email FROM Usuario WHERE Email = @Email");
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Email = (string)datos.Lector["Email"];
                    return usuario;
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

        // Método para generar token de recuperación
        public void GenerarTokenRecuperacion(string email, string token)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                DateTime expiracion = DateTime.Now.AddHours(24);
                datos.setearConsulta("UPDATE Usuario SET TokenRecuperacion = @Token, TokenRecuperacionExpiracion = @Expiracion WHERE Email = @Email");
                datos.setearParametro("@Token", token);
                datos.setearParametro("@Expiracion", expiracion);
                datos.setearParametro("@Email", email);
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

        // Método para buscar usuario por token de recuperación (validando expiración)
        public Usuario BuscarPorTokenRecuperacion(string token)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"SELECT IdUsuario, Email, Nombre, Apellido FROM Usuario 
                                       WHERE TokenRecuperacion = @Token 
                                       AND TokenRecuperacionExpiracion > GETDATE()");
                datos.setearParametro("@Token", token);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    return usuario;
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

        // Método para actualizar contraseña y limpiar token
        public void ActualizarPassword(int idUsuario, string nuevaPassword)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuario SET Clave = @Clave, TokenRecuperacion = NULL, TokenRecuperacionExpiracion = NULL WHERE IdUsuario = @IdUsuario");
                datos.setearParametro("@Clave", nuevaPassword);
                datos.setearParametro("@IdUsuario", idUsuario);
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