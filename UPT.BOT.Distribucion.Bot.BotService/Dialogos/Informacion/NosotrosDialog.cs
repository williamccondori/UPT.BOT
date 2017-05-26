using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Informacion
{
    public class NosotrosDialog : BaseDialog, IDialog<object>
    {
        private string speech;

        public NosotrosDialog(string speech)
        {
            this.speech = speech;
        }

        public async Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }
    }
}