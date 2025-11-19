using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imgNegocio = new ImagenNegocio();

            try
            {
                datos.setearConsulta(@"SELECT P.IdProducto, P.NombreProducto, P.Descripcion, 
                                              M.IdMarca, M.Descripcion AS Marca, 
                                              C.IdCategoria, C.Descripcion AS Categoria, 
                                              P.Precio
                                       FROM Producto P, Marcas M, Categoria C WHERE P.IdMarca = M.IdMarca AND P.IdCategoria = C.IdCategoria");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto prod = new Producto();
                    prod.IdProducto = (int)datos.Lector["IdProducto"];
                    prod.NombreProducto = (string)datos.Lector["NombreProducto"];
                    prod.Descripcion = (string)datos.Lector["Descripcion"];
                    prod.Precio = (decimal)datos.Lector["Precio"];

                    prod.Marca = new Marca
                    {
                        IdMarca = (int)datos.Lector["IdMarca"],
                        Descripcion = (string)datos.Lector["Marca"]
                    };

                    prod.Categoria = new Categoria
                    {
                        IdCategoria = (int)datos.Lector["IdCategoria"],
                        Descripcion = (string)datos.Lector["Categoria"]
                    };

                    // Cargar imágenes relacionadas
                    prod.Imagenes = imgNegocio.ListarPorProducto(prod.IdProducto);
                    if (prod.Imagenes.Count > 0)
                        prod.ImagenPrincipal = prod.Imagenes[0].UrlImagen;

                    lista.Add(prod);
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

        public List<Producto> ListarPorCategoria(int idCategoria)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imgNegocio = new ImagenNegocio();

            try
            {
                datos.setearConsulta(@"SELECT P.IdProducto, P.NombreProducto, P.Descripcion, 
                                      M.IdMarca, M.Descripcion AS Marca, 
                                      C.IdCategoria, C.Descripcion AS Categoria, 
                                      P.Precio
                               FROM Producto P, Marcas M, Categoria C 
                               WHERE P.IdMarca = M.IdMarca 
                               AND P.IdCategoria = C.IdCategoria 
                               AND P.IdCategoria = @IdCategoria");

                datos.setearParametro("@IdCategoria", idCategoria);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto prod = new Producto();
                    prod.IdProducto = (int)datos.Lector["IdProducto"];
                    prod.NombreProducto = (string)datos.Lector["NombreProducto"];
                    prod.Descripcion = (string)datos.Lector["Descripcion"];
                    prod.Precio = (decimal)datos.Lector["Precio"];

                    prod.Marca = new Marca
                    {
                        IdMarca = (int)datos.Lector["IdMarca"],
                        Descripcion = (string)datos.Lector["Marca"]
                    };

                    prod.Categoria = new Categoria
                    {
                        IdCategoria = (int)datos.Lector["IdCategoria"],
                        Descripcion = (string)datos.Lector["Categoria"]
                    };

                    
                    prod.Imagenes = imgNegocio.ListarPorProducto(prod.IdProducto);
                    if (prod.Imagenes.Count > 0)
                        prod.ImagenPrincipal = prod.Imagenes[0].UrlImagen;

                    lista.Add(prod);
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

        public Producto ObtenerPorId(int idProducto)
        {
            Producto prod = null;
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imgNegocio = new ImagenNegocio();

            try
            {
                datos.setearConsulta(@"SELECT P.IdProducto, P.NombreProducto, P.Descripcion, 
                                    M.IdMarca, M.Descripcion AS Marca, 
                                    C.IdCategoria, C.Descripcion AS Categoria, 
                                    P.Precio
                               FROM Producto P, Marcas M, Categoria C 
                               WHERE P.IdMarca = M.IdMarca 
                               AND P.IdCategoria = C.IdCategoria
                               AND P.IdProducto = @IdProducto");

                datos.setearParametro("@IdProducto", idProducto);

                datos.ejecutarLectura();

                
                if (datos.Lector.Read())
                {
                    prod = new Producto();
                    prod.IdProducto = (int)datos.Lector["IdProducto"];
                    prod.NombreProducto = (string)datos.Lector["NombreProducto"];
                    prod.Descripcion = (string)datos.Lector["Descripcion"];
                    prod.Precio = (decimal)datos.Lector["Precio"];

                    prod.Marca = new Marca
                    {
                        IdMarca = (int)datos.Lector["IdMarca"],
                        Descripcion = (string)datos.Lector["Marca"]
                    };

                    prod.Categoria = new Categoria
                    {
                        IdCategoria = (int)datos.Lector["IdCategoria"],
                        Descripcion = (string)datos.Lector["Categoria"]
                    };

                    // Carga Imagenes
                    prod.Imagenes = imgNegocio.ListarPorProducto(prod.IdProducto);
                    if (prod.Imagenes.Count > 0)
                        prod.ImagenPrincipal = prod.Imagenes[0].UrlImagen;
                }

                return prod;
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

        public void Agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO Producto (NombreProducto, Descripcion, IdMarca, IdCategoria, Precio)
                                       VALUES (@NombreProducto, @Descripcion, @IdMarca, @IdCategoria, @Precio);
                                       SELECT SCOPE_IDENTITY() AS IdProducto");

                datos.setearParametro("@NombreProducto", nuevo.NombreProducto);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.IdCategoria);
                datos.setearParametro("@Precio", nuevo.Precio);

                datos.ejecutarLectura();

                int idProducto = 0;
                if (datos.Lector.Read())
                    idProducto = Convert.ToInt32(datos.Lector["IdProducto"]);

                datos.cerrarConexion();

                // Insertar imágenes
                if (nuevo.Imagenes != null && nuevo.Imagenes.Count > 0)
                {
                    foreach (ProductoImagen img in nuevo.Imagenes)
                    {
                        AccesoDatos datosImg = new AccesoDatos();
                        datosImg.setearConsulta("INSERT INTO Imagen (IdProducto, UrlImagen) VALUES (@IdProducto, @UrlImagen)");
                        datosImg.setearParametro("@IdProducto", idProducto);
                        datosImg.setearParametro("@UrlImagen", img.UrlImagen);
                        datosImg.ejecutarAccion();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"UPDATE Producto 
                                       SET NombreProducto = @NombreProducto, Descripcion = @Descripcion, 
                                           IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio 
                                       WHERE IdProducto = @IdProducto");

                datos.setearParametro("@NombreProducto", producto.NombreProducto);
                datos.setearParametro("@Descripcion", producto.Descripcion);
                datos.setearParametro("@IdMarca", producto.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", producto.Categoria.IdCategoria);
                datos.setearParametro("@Precio", producto.Precio);
                datos.setearParametro("@IdProducto", producto.IdProducto);
                datos.ejecutarAccion();

                // Actualizar imágenes
                AccesoDatos datosImg = new AccesoDatos();
                datosImg.setearConsulta("DELETE FROM Imagen WHERE IdProducto = @IdProducto");
                datosImg.setearParametro("@IdProducto", producto.IdProducto);
                datosImg.ejecutarAccion();

                foreach (ProductoImagen img in producto.Imagenes)
                {
                    AccesoDatos datosImgInsert = new AccesoDatos();
                    datosImgInsert.setearConsulta("INSERT INTO Imagen (IdProducto, UrlImagen) VALUES (@IdProducto, @UrlImagen)");
                    datosImgInsert.setearParametro("@IdProducto", producto.IdProducto);
                    datosImgInsert.setearParametro("@UrlImagen", img.UrlImagen);
                    datosImgInsert.ejecutarAccion();
                }
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
                datos.setearConsulta("DELETE FROM Producto WHERE IdProducto = @IdProducto");
                datos.setearParametro("@IdProducto", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
