using ApiAiSDK;
using ApiAiSDK.Model;
using System;

namespace UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Ai
{

    public interface IAiService
    {
        AIResponse BuscarIntencion(string Mensaje);
    }

    [Serializable]
    public class AiService : IAiService
    {
        private readonly IAiModel gsModelo;

        public AiService(IAiModel aoModelo)
        {
            gsModelo = aoModelo;
        }

        public AIResponse BuscarIntencion(string asMensaje)
        {
            var loConfiguracionApi = new AIConfiguration(gsModelo.Token, SupportedLanguage.Spanish);

            var gsApi = new ApiAi(loConfiguracionApi);

            AIResponse loResultado = gsApi.TextRequest(asMensaje);

            return loResultado;
        }
    }
}