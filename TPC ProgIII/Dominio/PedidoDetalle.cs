using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetallePedido
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; } // Modelar el obj. -> relacion
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        // Relaciones
        public Producto Producto { get; set; }
    }
}
