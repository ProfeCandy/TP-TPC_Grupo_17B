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
    }
}

