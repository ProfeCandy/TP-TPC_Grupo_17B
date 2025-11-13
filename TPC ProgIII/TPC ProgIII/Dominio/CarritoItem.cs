using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class CarritoItem
    {
        public int IdCarritoItem { get; set; }
        public int Cantidad { get; set; }
        // Relaciones
        public Producto Producto { get; set; }
        public Carrito Carrito { get; set; }
    }
}