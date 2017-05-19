using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared
{
    [Serializable]
    public class SaludarDialog : IDialog<object>
    {
        private string Mensaje { get; set; }

        public SaludarDialog(string asMensaje = "")
        {
            Mensaje = asMensaje;
        }

        public async Task StartAsync(IDialogContext aoContexto)
        {
            if (string.IsNullOrEmpty(Mensaje))
            {
                Mensaje = "Hola!";
            }

            await aoContexto.PostAsync(Mensaje);

            aoContexto.Done(this);
        }
    }
}