using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public short AñoDesde { get; set; }
        public short? AñoHasta { get; set; }
        public string Motor { get; set; }
        public string Tipo { get; set; }
    }
}