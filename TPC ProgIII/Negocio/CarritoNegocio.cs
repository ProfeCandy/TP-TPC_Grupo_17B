using Dominio;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CarritoNegocio
    {
        public void AgregarItem(Carrito carrito, Producto producto, int cantidad)
        {
            CarritoItem itemExistente = carrito.Items.Find(x => x.Producto.IdProducto == producto.IdProducto);
            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                carrito.Items.Add(new CarritoItem { Producto = producto, Cantidad = cantidad });
            }
        }

        public decimal CalcularTotal(Carrito carrito)
        {
            if (carrito == null) return 0;

            decimal total = 0;
            foreach (var item in carrito.Items)
            {
                total += item.Producto.Precio * item.Cantidad;
            }
            return total;
        }

        public List<CarritoItemDto> ObtenerListadoDTO(Carrito carrito)
        {
            List<CarritoItemDto> listaSalida = new List<CarritoItemDto>();

            if (carrito != null)
            {
                foreach (var item in carrito.Items)
                {
                    CarritoItemDto dto = new CarritoItemDto();

                    dto.IdProducto = item.Producto.IdProducto;
                    dto.Nombre = item.Producto.NombreProducto;
                    dto.Marca = item.Producto.Marca.Descripcion;
                    dto.PrecioUnitario = item.Producto.Precio;
                    dto.Cantidad = item.Cantidad;

                    dto.ImagenUrl = item.Producto.ImagenPrincipal ?? "https://dummyimage.com/50x50/dee2e6/6c757d.jpg";

                    dto.SubTotal = item.Producto.Precio * item.Cantidad;

                    listaSalida.Add(dto);
                }
            }
            return listaSalida;
        }
    }
}
