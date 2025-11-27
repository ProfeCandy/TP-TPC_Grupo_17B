using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Frontend
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            try
            {
                Negocio.ReservaStockNegocio reservaNegocio = new Negocio.ReservaStockNegocio();
                reservaNegocio.LiberarReservasExpiradas();
            }
            catch
            {
            }
        }

        void Session_End(object sender, EventArgs e)
        {
            try
            {
                string sessionId = Session.SessionID;
                if (!string.IsNullOrEmpty(sessionId))
                {
                    Negocio.ReservaStockNegocio reservaNegocio = new Negocio.ReservaStockNegocio();
                    reservaNegocio.LiberarReservasPorSesion(sessionId);
                }
            }
            catch
            {
            }
        }
    }
}