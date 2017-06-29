using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Extras
{
    public class AyudaDialog : BaseDialog, IDialog<object>
    {
        private readonly string _mensaje;

        public AyudaDialog(AIResponse response)
        {
            _mensaje = ObtenerMensajeServicio(response);
        }

        public Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }
    }
}