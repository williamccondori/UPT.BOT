using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Informacion
{
    public class DireccionDialog : BaseDialog, IDialog<object>
    {
        private string speech;

        public DireccionDialog(string speech)
        {
            this.speech = speech;
        }

        public Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }
    }
}