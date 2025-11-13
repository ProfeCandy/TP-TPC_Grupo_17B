using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<ProductoImagen> ListarPorProducto(int idProducto)
        {
            List<ProductoImagen> lista = new List<ProductoImagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdImagen, IdProducto, UrlImagen FROM Imagen WHERE IdProducto = @IdProducto");
                datos.setearParametro("@IdProducto", idProducto);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ProductoImagen img = new ProductoImagen();
                    img.IdImagen = (int)datos.Lector["IdImagen"];
                    img.UrlImagen = (string)datos.Lector["UrlImagen"];
                    lista.Add(img);
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
