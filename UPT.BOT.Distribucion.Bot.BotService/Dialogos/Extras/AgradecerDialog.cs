using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Extras
{
    public class AgradecerDialog : BaseDialog, IDialog<object>
    {
        private AIResponse response;

        public AgradecerDialog(AIResponse response)
        {
            this.response = response;
        }

        public async Task StartAsync(IDialogContext context)
        {
            IMessageActivity actividaMensaje = context.MakeMessage();
            actividaMensaje.Text = response.Result.Fulfillment.Speech;
            actividaMensaje.Recipient = actividaMensaje.From;
            actividaMensaje.Type = ActivityTypes.Message;
            await context.PostAsync(actividaMensaje);
            context.Done(this);
        }
    }
}