using System;
using System.Configuration;
using System.Web.Configuration;

namespace Negocio
{
    public static class ConfigHelper
    {
        public static string ObtenerEmailContacto()
        {
            return ConfigurationManager.AppSettings["EmailContacto"] ?? "info@autoparts.com.ar";
        }

        public static string ObtenerEmailFrom()
        {
            return ConfigurationManager.AppSettings["EmailFrom"] ?? "noreply@tuempresa.com";
        }

        public static void ActualizarEmailContacto(string nuevoEmail)
        {
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                config.AppSettings.Settings["EmailContacto"].Value = nuevoEmail;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
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
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                config.AppSettings.Settings["EmailFrom"].Value = nuevoEmail;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el correo de envío: " + ex.Message);
            }
        }
    }
}

