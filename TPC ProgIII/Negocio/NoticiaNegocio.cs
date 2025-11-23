using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NoticiaNegocio
    {
        public List<Noticia> Listar()
        {
            List<Noticia> lista = new List<Noticia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdNoticia, Titulo, Cuerpo, FechaPublicacion, Categoria, ImagenUrl, Activa FROM Noticias WHERE Activa = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Noticia aux = new Noticia();
                    aux.IdNoticia = (int)datos.Lector["IdNoticia"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Cuerpo = (string)datos.Lector["Cuerpo"];
                    aux.FechaPublicacion = (DateTime)datos.Lector["FechaPublicacion"];
                    
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria = (string)datos.Lector["Categoria"];
                    
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    
                    aux.Activa = (bool)datos.Lector["Activa"];

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

        public Noticia ObtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Noticia noticia = null;

            try
            {
                datos.setearConsulta("SELECT IdNoticia, Titulo, Cuerpo, FechaPublicacion, Categoria, ImagenUrl, Activa FROM Noticias WHERE IdNoticia = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    noticia = new Noticia();
                    noticia.IdNoticia = (int)datos.Lector["IdNoticia"];
                    noticia.Titulo = (string)datos.Lector["Titulo"];
                    noticia.Cuerpo = (string)datos.Lector["Cuerpo"];
                    noticia.FechaPublicacion = (DateTime)datos.Lector["FechaPublicacion"];

                    if (!(datos.Lector["Categoria"] is DBNull))
                        noticia.Categoria = (string)datos.Lector["Categoria"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        noticia.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    noticia.Activa = (bool)datos.Lector["Activa"];

                    // Cargar imágenes relacionadas
                    NoticiaImagenNegocio imagenNegocio = new NoticiaImagenNegocio();
                    noticia.Imagenes = imagenNegocio.ObtenerPorNoticia(noticia.IdNoticia);
                }

                return noticia;
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

        // Eliminación lógica (marca como inactiva)
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Noticias SET Activa = 0 WHERE IdNoticia = @Id");
                datos.setearParametro("@Id", id);
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

        // Agregar noticia y retornar el ID generado
        public int Agregar(Noticia noticia)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Noticias (Titulo, Cuerpo, FechaPublicacion, Categoria, ImagenUrl, Activa) VALUES (@Titulo, @Cuerpo, @FechaPublicacion, @Categoria, @ImagenUrl, @Activa); SELECT SCOPE_IDENTITY()");
                datos.setearParametro("@Titulo", noticia.Titulo);
                datos.setearParametro("@Cuerpo", noticia.Cuerpo);
                datos.setearParametro("@FechaPublicacion", noticia.FechaPublicacion);
                datos.setearParametro("@Categoria", (object)noticia.Categoria ?? DBNull.Value);
                datos.setearParametro("@ImagenUrl", (object)noticia.ImagenUrl ?? DBNull.Value);
                datos.setearParametro("@Activa", noticia.Activa);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)Convert.ToDecimal(datos.Lector[0]);
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

        // Modificar noticia
        public void Modificar(Noticia noticia)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Noticias SET Titulo = @Titulo, Cuerpo = @Cuerpo, Categoria = @Categoria, ImagenUrl = @ImagenUrl, Activa = @Activa WHERE IdNoticia = @IdNoticia");
                datos.setearParametro("@IdNoticia", noticia.IdNoticia);
                datos.setearParametro("@Titulo", noticia.Titulo);
                datos.setearParametro("@Cuerpo", noticia.Cuerpo);
                datos.setearParametro("@Categoria", (object)noticia.Categoria ?? DBNull.Value);
                datos.setearParametro("@ImagenUrl", (object)noticia.ImagenUrl ?? DBNull.Value);
                datos.setearParametro("@Activa", noticia.Activa);
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
