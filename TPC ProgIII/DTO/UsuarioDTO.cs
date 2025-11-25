using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoTexto
        {
            get { return Activo ? "Activo" : "Inactivo"; }
        }
    }
}