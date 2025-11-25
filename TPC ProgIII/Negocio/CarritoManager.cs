using System;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public static class CarritoManager
    {
        public static string Agregar(int idProducto, int cantidad, HttpSessionState session)
        {

            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto productoSeleccionado = productoNegocio.ObtenerPorId(idProducto);

            if (productoSeleccionado == null) return "Error: el producto no existe.";

            Carrito carrito;

            if (session["Carrito"] == null)
                carrito = new Carrito();
            else
                carrito = (Carrito)session["Carrito"];

            CarritoItem item = carrito.Items.Find(x => x.Producto.IdProducto == idProducto);

            if (item != null)
                item.Cantidad += cantidad;
            else
                carrito.Items.Add(new CarritoItem { Producto = productoSeleccionado, Cantidad = cantidad });

            session["Carrito"] = carrito;

            return $"{productoSeleccionado.NombreProducto} agregado al carrito.";
        }
    }
}
