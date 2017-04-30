using System;

namespace UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Ai
{
    public interface IAiModel
    {
        string Token { get; }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method, AllowMultiple = true)]
    [Serializable]
    public class AiModelAttribute : Attribute, IAiModel, IEquatable<IAiModel>
    {
        private readonly string gsToken;
        private readonly string gsRuta;

        public string Token => gsToken;


        public AiModelAttribute(string asToken)
        {
            gsToken = asToken;

            gsRuta = "https://api.api.ai/v1/";
        }

        public bool Equals(IAiModel aoModelo)
        {
            return aoModelo != null && Equals(gsToken, aoModelo.Token);
        }
    }
}