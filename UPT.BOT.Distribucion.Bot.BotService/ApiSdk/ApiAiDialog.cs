using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.ApiSdk
{
    public class ApiAiDialog<R> : IDialog<R>
    {
        public ApiAiDialog()
        {

        }

        public Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }
    }
}