using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared
{
    [Serializable]
    public class PredeterminadoDialog : IDialog<object>
    {
        public string Mensaje { get; set; }

        public PredeterminadoDialog(string asMensaje = "")
        {
            Mensaje = asMensaje;
        }
        public async Task StartAsync(IDialogContext aoContexto)
        {
            if (string.IsNullOrEmpty(Mensaje))
            {
                Mensaje = "Lo siento, no te he entendido";
            }

            await aoContexto.PostAsync(Mensaje);

            aoContexto.Done(this);
        }
    }
}