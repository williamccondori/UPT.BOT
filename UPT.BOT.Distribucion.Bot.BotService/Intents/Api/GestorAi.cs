using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Dialogs;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Adjunto;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Bot;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared;

namespace UPT.BOT.Distribucion.Bot.BotService.Intents.Api
{
    [Serializable]
    public class GestorAi : BaseAi
    {
        [AiIntent("Predeterminado")]
        public async Task Predeterminado(IDialogContext aoContexto, AIResponse aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, "Predeterminado", new PredeterminadoDialog(aoResultado.Result.Fulfillment.Speech), Terminar);
            });
        }

        [AiIntent("Saludar")]
        public async Task Saludar(IDialogContext aoContexto, AIResponse aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, "Saludar", new SaludarDialog(aoResultado.Result.Fulfillment.Speech), Empezar);
            });
        }

        [AiIntent("Noticia")]
        public async Task Noticia(IDialogContext aoContexto, AIResponse aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, "Noticia", new NoticiaDialog(), Empezar);
            });
        }

        [AiIntent("MallaCurricular")]
        public async Task MallaCurricular(IDialogContext aoContexto, AIResponse aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, "MallaCurricular", new MallaCurricularDialog(), Empezar);
            });
        }

        [AiIntent("Reglamento")]
        public async Task Reglamento(IDialogContext aoContexto, AIResponse aoResultado)
        {
            await EmpezarDialogo(() =>
            {
                EmpezarConversacion(aoContexto, aoResultado, "Reglamento", new ReglamentoDialog(), Empezar);
            });
        }
    }
}