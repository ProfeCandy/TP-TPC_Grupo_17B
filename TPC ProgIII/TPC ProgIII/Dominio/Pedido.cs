using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }
        public string DireccionEnvio { get; set; }
        public string LocalidadEnvio { get; set; }

        // Relación con el cliente
        public Usuario Usuario { get; set; }

        // Detalle del pedido
        public List<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
    }
}