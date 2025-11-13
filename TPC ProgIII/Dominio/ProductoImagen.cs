using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProductoImagen
    {
        public int IdImagen { get; set; }
        public Producto Producto { get; set; }
        public string UrlImagen { get; set; }
    }
}
