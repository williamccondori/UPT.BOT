using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Extras
{
    public class CreadorDialog : BaseDialog, IDialog<object>
    {
        public readonly string _mensaje;

        public CreadorDialog(AIResponse response)
        {
            _mensaje = ObtenerMensajeServicio(response);
        }

        public Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }
    }
}