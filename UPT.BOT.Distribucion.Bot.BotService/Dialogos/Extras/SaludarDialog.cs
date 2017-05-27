using ApiAiSDK.Model;  
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Extras
{
    [Serializable]
    public class SaludarDialog : BaseDialog, IDialog<object>
    {
        private AIResponse response;

        public SaludarDialog(AIResponse response)
        {
            this.response = response;
        }

        public async Task StartAsync(IDialogContext context)
        {
            IMessageActivity actividaMensaje = context.MakeMessage();

            Activity actividad = (Activity)context.Activity;

            string usuario = actividad.From.Name;

            string[] nombres = usuario.Split(' ');

            string saludo = response.Result.Fulfillment.Speech ?? "Hola";

            string saludoFeliz = string.Format("{0} {1} ! 😀", saludo, nombres[0]);

            actividaMensaje.Text = saludoFeliz;
            actividaMensaje.Recipient = actividaMensaje.From;
            actividaMensaje.Type = ActivityTypes.Message;

            await context.PostAsync(actividaMensaje);

            context.Done(this);
        }
    }
}