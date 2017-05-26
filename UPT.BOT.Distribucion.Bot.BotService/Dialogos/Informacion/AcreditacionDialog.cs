using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Informacion
{
    public class AcreditacionDialog : BaseDialog, IDialog<object>
    {
        private string speech;

        public AcreditacionDialog(string speech)
        {
            this.speech = speech;
        }

        public async Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }
    }
}