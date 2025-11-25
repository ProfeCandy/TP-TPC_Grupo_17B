using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using DTO;

namespace Negocio
{
    internal class AdminManager
    {
        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private ProductoNegocio productoNegocio = new ProductoNegocio();
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        private MarcaNegocio marcaNegocio = new MarcaNegocio();



        // GESTION DE USUARIOS
        // GESTION DE USUARIOS
        // GESTION DE USUARIOS
        public List<UsuarioDto> ListarUsuariosDto()
        {
            List<UsuarioDto> lista = new List<UsuarioDto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Traemos solo los datos necesarios para la grilla, sin claves ni tokens
                datos.setearConsulta(@"
                    SELECT U.IdUsuario, U.Nombre, U.Apellido, U.Email, U.Telefono, 
                           U.Activo, U.FechaRegistro,
                           R.IdRol, R.NombreRol
                    FROM Usuario U
                    INNER JOIN Rol R ON U.IdRol = R.IdRol
                    ORDER BY U.FechaRegistro DESC");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    UsuarioDto dto = new UsuarioDto();
                    dto.IdUsuario = (int)datos.Lector["IdUsuario"];

                    string nombre = (string)datos.Lector["Nombre"];
                    string apellido = (string)datos.Lector["Apellido"];
                    dto.NombreCompleto = $"{nombre} {apellido}";

                    dto.Email = (string)datos.Lector["Email"];

                    // Validamos nulos
                    if (datos.Lector["Telefono"] != DBNull.Value)
                        dto.Telefono = (string)datos.Lector["Telefono"];
                    else
                        dto.Telefono = "-";

                    dto.Activo = (bool)datos.Lector["Activo"];
                    dto.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];

                    // Datos del Rol
                    dto.IdRol = (int)datos.Lector["IdRol"];
                    dto.NombreRol = (string)datos.Lector["NombreRol"];

                    lista.Add(dto);
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

        // Acción administrativa: Cambiar Rol
        public void CambiarRolUsuario(int idUsuario, int idNuevoRol)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuario SET IdRol = @IdRol WHERE IdUsuario = @IdUsuario");
                datos.setearParametro("@IdRol", idNuevoRol);
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

        // Baja Lógica
        public void AlternarEstadoUsuario(int idUsuario, bool activo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuario SET Activo = @Activo WHERE IdUsuario = @IdUsuario");
                datos.setearParametro("@Activo", activo);
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



        // GESTIÓN DE PRODUCTOS
        // GESTIÓN DE PRODUCTOS
        // GESTIÓN DE PRODUCTOS
        public List<Producto> ListarProductos()
        {
            return productoNegocio.Listar();
        }
        public Producto ObtenerProductoPorId(int id)
        {
            return productoNegocio.ObtenerPorId(id);
        }
        public void GuardarProducto(Producto producto)
        {
            if (producto.IdProducto == 0)
            {
                productoNegocio.Agregar(producto);
            }
            else
            {
                productoNegocio.Modificar(producto);
            }
        }
        // Producto Activo true/false
        public void ModificarEstadoProducto(int idProducto, bool activo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Producto SET Activo = @Activo WHERE IdProducto = @IdProducto");
                datos.setearParametro("@Activo", activo);
                datos.setearParametro("@IdProducto", idProducto);
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
        public void EliminarProductoFisico(int idProducto)
        {
            productoNegocio.Eliminar(idProducto);
        }



        // GESTION CATEGORIAS
        // GESTION CATEGORIAS
        // GESTION CATEGORIAS
        public List<Categoria> ListarCategorias()
        {
            return categoriaNegocio.Listar();
        }
        public void GuardarCategoria(Categoria categoria)
        {
            // Mismo patrón: ID 0 es Alta, ID > 0 es Modificación
            if (categoria.IdCategoria == 0)
                categoriaNegocio.Agregar(categoria);
            else
                categoriaNegocio.Modificar(categoria);
        }
        public void EliminarCategoria(int id)
        {
            // Aquí podrías agregar validación: No eliminar si hay productos asociados
            categoriaNegocio.Eliminar(id);
        }



        // GESTION MARCAS
        // GESTION MARCAS
        // GESTION MARCAS
        public List<Marca> ListarMarcas()
        {
            return marcaNegocio.Listar();
        }
        public void GuardarMarca(Marca marca)
        {
            // Mismo patrón: ID 0 es Alta, ID > 0 es Modificación
            if (marca.IdMarca == 0)
                marcaNegocio.Agregar(marca);
            else
                marcaNegocio.Modificar(marca);
        }
        public void EliminarMarca(int id)
        {
            marcaNegocio.Eliminar(id);
        }
    }
}
