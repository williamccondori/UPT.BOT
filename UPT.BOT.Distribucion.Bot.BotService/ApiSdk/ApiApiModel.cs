using System;

namespace UPT.BOT.Distribucion.Bot.BotService.ApiSdk
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ApiAiModelAttribute : Attribute
    {
        public readonly string TokenAcceso;

        public ApiAiModelAttribute(string asTokenAcceso)
        {
            TokenAcceso = asTokenAcceso;
        }
    }
}