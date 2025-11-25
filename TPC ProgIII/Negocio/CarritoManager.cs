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

            Carrito carrito = ObtenerCarrito(session);
            CarritoItem item = carrito.Items.Find(x => x.Producto.IdProducto == idProducto);

            if (item != null)
                item.Cantidad += cantidad;
            else
                carrito.Items.Add(new CarritoItem { Producto = productoSeleccionado, Cantidad = cantidad });

            session["Carrito"] = carrito;

            return $"{productoSeleccionado.NombreProducto} agregado al carrito.";
        }
<<<<<<< Updated upstream
        public static void Eliminar(int idProducto, HttpSessionState session)
        {
            Carrito carrito = ObtenerCarrito(session);
            CarritoItem item = carrito.Items.Find(x => x.Producto.IdProducto == idProducto);

            if (item != null)
            {
                carrito.Items.Remove(item);
                session["Carrito"] = carrito;
            }
        }
        public static void Restar(int idProducto, HttpSessionState session)
        {
            Carrito carrito = ObtenerCarrito(session);
            CarritoItem item = carrito.Items.Find(x => x.Producto.IdProducto == idProducto);

            if (item != null)
            {
                if (item.Cantidad > 1)
                {
                    item.Cantidad--;
                }
                else
                { 
                    carrito.Items.Remove(item);
                }
                session["Carrito"] = carrito;
            }
        }
        public static void Vaciar(HttpSessionState session)
        {
            session["Carrito"] = new Carrito();
        }
        public static int ObtenerCantidadItems(HttpSessionState session)
        {
            Carrito carrito = ObtenerCarrito(session);
            int cantidad = 0;
            foreach (var item in carrito.Items)
            {
                cantidad += item.Cantidad;
            }
            return cantidad;
        }
        public static Carrito ObtenerCarrito(HttpSessionState session)
        {
            if (session["Carrito"] == null)
            {
                session["Carrito"] = new Carrito();
            }
            return (Carrito)session["Carrito"];
        }
    }
}
