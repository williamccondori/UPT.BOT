using System;

namespace UPT.BOT.Distribucion.Bot.BotService.ApiSdk
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ApiAiIntentAttribute : Attribute
    {
        public readonly string Intencion;

        public ApiAiIntentAttribute(string asIntencion)
        {
            Intencion = asIntencion;
        }
    }
}