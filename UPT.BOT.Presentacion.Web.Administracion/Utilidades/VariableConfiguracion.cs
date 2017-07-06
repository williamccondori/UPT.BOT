using System.Configuration;

namespace UPT.BOT.Presentacion.Web.Administracion.Utilidades
{
    public class VariableConfiguracion
    {
        public static string RutaApi()
        {
            string ruta = ConfigurationManager.AppSettings["Api"].ToString();

            return string.Format("{0}/api/", ruta);
        }
    }
}