using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared
{
    [Serializable]
    public class PredeterminadoDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext aoContexto)
        {
            await aoContexto.PostAsync("Lo siento, no te he entendido ");

            aoContexto.Done(this);
        }
    }
}