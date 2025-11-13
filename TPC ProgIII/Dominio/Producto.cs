using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public List<ProductoImagen> Imagenes { get; set; } = new List<ProductoImagen>();
        public List<Vehiculo> VehiculosCompatibles { get; set; } = new List<Vehiculo>();
        public bool Activo { get; set; }
    }
}
