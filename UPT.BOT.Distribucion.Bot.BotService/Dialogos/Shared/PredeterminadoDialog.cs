using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared
{
    [Serializable]
    public class PredeterminadoDialog : BaseDialog, IDialog<object>
    {
        private readonly string _mensaje;

        public PredeterminadoDialog(AIResponse response)
        {
            _mensaje = ObtenerMensajeServicio(response) ?? "Lo siento, no te he entendido";
        }

        public async Task StartAsync(IDialogContext context)
        {
            await context.SayAsync(_mensaje);
            context.Done(this);
        }
    }
}