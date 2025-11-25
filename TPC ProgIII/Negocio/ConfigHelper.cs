using System;
using System.Configuration;

namespace Negocio
{
    public static class ConfigHelper
    {
        private static ConfiguracionNegocio configNegocio = new ConfiguracionNegocio();

        public static string ObtenerEmailContacto()
        {
            try
            {
                string valor = configNegocio.ObtenerValor("EmailContacto");
                if (!string.IsNullOrEmpty(valor))
                {
                    return valor;
                }
            }
            catch
            {
            }
            
            return ConfigurationManager.AppSettings["EmailContacto"] ?? "info@autoparts.com.ar";
        }

        public static string ObtenerEmailFrom()
        {
            try
            {
                string valor = configNegocio.ObtenerValor("EmailFrom");
                if (!string.IsNullOrEmpty(valor))
                {
                    return valor;
                }
            }
            catch
            {
            }
            
            return ConfigurationManager.AppSettings["EmailFrom"] ?? "noreply@tuempresa.com";
        }

        public static void ActualizarEmailContacto(string nuevoEmail)
        {
            try
            {
                configNegocio.ActualizarValor("EmailContacto", nuevoEmail);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el correo de contacto: " + ex.Message);
            }
        }

        public static void ActualizarEmailFrom(string nuevoEmail)
        {
            try
            {
                configNegocio.ActualizarValor("EmailFrom", nuevoEmail);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el correo de envío: " + ex.Message);
            }
        }
    }
}

