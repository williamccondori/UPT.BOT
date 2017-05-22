using System.Configuration;

namespace UPT.BOT.Presentacion.Web.Administracion.Utilidades
{
    public class VariableConfiguracion
    {
        public static string RutaApi()
        {
            string ruta = ConfigurationManager.AppSettings["ApiRuta"].ToString();
            string version = ConfigurationManager.AppSettings["ApiVersion"].ToString();
            string servicio = ConfigurationManager.AppSettings["ApiServicio"].ToString();

            return string.Format("{0}/api/{1}/{2}/", ruta, version, servicio);
        }
    }
}