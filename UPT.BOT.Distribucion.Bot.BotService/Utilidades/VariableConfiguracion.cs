using System;

namespace UPT.BOT.Distribucion.Bot.BotService.Utilidades
{
    [Serializable]
    public class VariableConfiguracion
    {
        public static string RutaApi()
        {
            return "http://localhost:53418/api";
        }

        public static string VersionApi()
        {
            return "v1";
        }

        public static string ServicioApi()
        {
            return "asistente";
        }
    }
}