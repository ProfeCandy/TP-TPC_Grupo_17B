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

            if (productoSeleccionado == null) 
                return "Error: el producto no existe.";

            ReservaStockNegocio reservaNegocio = new ReservaStockNegocio();
            int stockDisponible = reservaNegocio.ObtenerStockDisponible(idProducto);

            Carrito carrito = ObtenerCarrito(session);
            CarritoItem item = carrito.Items.Find(x => x.Producto.IdProducto == idProducto);

            int cantidadTotal = (item != null) ? item.Cantidad + cantidad : cantidad;

            if (cantidadTotal > stockDisponible)
            {
                return $"Error: Solo hay {stockDisponible} unidades disponibles.";
            }

            if (item != null)
            {
                reservaNegocio.ActualizarReserva(idProducto, item.Cantidad, cantidadTotal, session.SessionID);
                item.Cantidad += cantidad;
            }
            else
            {
                if (!reservaNegocio.ReservarStock(idProducto, cantidad, session.SessionID))
                {
                    return "Error: No se pudo reservar el stock. Intente nuevamente.";
                }
                carrito.Items.Add(new CarritoItem { Producto = productoSeleccionado, Cantidad = cantidad });
            }

            session["Carrito"] = carrito;
            return $"{productoSeleccionado.NombreProducto} agregado al carrito.";
        }
        public static void Eliminar(int idProducto, HttpSessionState session)
        {
            Carrito carrito = ObtenerCarrito(session);
            CarritoItem item = carrito.Items.Find(x => x.Producto.IdProducto == idProducto);

            if (item != null)
            {
                ReservaStockNegocio reservaNegocio = new ReservaStockNegocio();
                reservaNegocio.EliminarReserva(idProducto, item.Cantidad, session.SessionID);
                
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
                ReservaStockNegocio reservaNegocio = new ReservaStockNegocio();
                
                if (item.Cantidad > 1)
                {
                    reservaNegocio.ActualizarReserva(idProducto, item.Cantidad, item.Cantidad - 1, session.SessionID);
                    item.Cantidad--;
                }
                else
                {
                    reservaNegocio.EliminarReserva(idProducto, 1, session.SessionID);
                    carrito.Items.Remove(item);
                }
                session["Carrito"] = carrito;
            }
        }
        public static void Vaciar(HttpSessionState session)
        {
            ReservaStockNegocio reservaNegocio = new ReservaStockNegocio();
            reservaNegocio.LiberarReservasPorSesion(session.SessionID);
            
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
