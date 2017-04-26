using System;
using System.Configuration;

namespace UPT.BOT.Distribucion.Bot.BotService.Utilidades
{
    [Serializable]
    public class VariableConfiguracion
    {
        public static string RutaApi()
        {
            return ConfigurationManager.AppSettings["ApiRuta"].ToString();
        }

        public static string VersionApi()
        {
            return ConfigurationManager.AppSettings["ApiVersion"].ToString();
        }

        public static string ServicioApi()
        {
            return ConfigurationManager.AppSettings["ApiServicio"].ToString();
        }
    }
}