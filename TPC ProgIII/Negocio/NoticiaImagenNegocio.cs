using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NoticiaImagenNegocio
    {
        public List<NoticiaImagen> ObtenerPorNoticia(int idNoticia)
        {
            List<NoticiaImagen> lista = new List<NoticiaImagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdNoticiaImagen, IdNoticia, UrlImagen, Orden, FechaSubida FROM NoticiaImagen WHERE IdNoticia = @IdNoticia ORDER BY Orden");
                datos.setearParametro("@IdNoticia", idNoticia);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    NoticiaImagen aux = new NoticiaImagen();
                    aux.IdNoticiaImagen = (int)datos.Lector["IdNoticiaImagen"];
                    aux.IdNoticia = (int)datos.Lector["IdNoticia"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Orden = (int)datos.Lector["Orden"];
                    aux.FechaSubida = (DateTime)datos.Lector["FechaSubida"];

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

        public void Agregar(NoticiaImagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO NoticiaImagen (IdNoticia, UrlImagen, Orden, FechaSubida) VALUES (@IdNoticia, @UrlImagen, @Orden, @FechaSubida)");
                datos.setearParametro("@IdNoticia", imagen.IdNoticia);
                datos.setearParametro("@UrlImagen", imagen.UrlImagen);
                datos.setearParametro("@Orden", imagen.Orden);
                datos.setearParametro("@FechaSubida", imagen.FechaSubida);
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

        public void EliminarPorNoticia(int idNoticia)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM NoticiaImagen WHERE IdNoticia = @IdNoticia");
                datos.setearParametro("@IdNoticia", idNoticia);
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

        public void Eliminar(int idNoticiaImagen)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM NoticiaImagen WHERE IdNoticiaImagen = @IdNoticiaImagen");
                datos.setearParametro("@IdNoticiaImagen", idNoticiaImagen);
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
