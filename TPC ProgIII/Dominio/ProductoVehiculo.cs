using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProductoVehiculo
    {
        public Producto Producto { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public string DetalleCompatibilidad { get; set; }
        public string Observaciones { get; set; }
    }
}
