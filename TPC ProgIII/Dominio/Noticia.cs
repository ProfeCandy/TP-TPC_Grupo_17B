using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Noticia
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Categoria { get; set; }
        public string ImagenUrl { get; set; }
        public bool Activa { get; set; }
        public List<NoticiaImagen> Imagenes { get; set; }

        public Noticia()
        {
            Imagenes = new List<NoticiaImagen>();
        }
    }
}
