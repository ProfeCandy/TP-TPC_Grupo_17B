using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class NoticiaImagen
    {
        public int IdNoticiaImagen { get; set; }
        public int IdNoticia { get; set; }
        public string UrlImagen { get; set; }
        public int Orden { get; set; }
        public DateTime FechaSubida { get; set; }
    }
}

