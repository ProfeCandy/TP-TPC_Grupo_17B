using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Usuario Usuario { get; set; }
        public List<CarritoItem> Items { get; set; } = new List<CarritoItem>();
    }
}