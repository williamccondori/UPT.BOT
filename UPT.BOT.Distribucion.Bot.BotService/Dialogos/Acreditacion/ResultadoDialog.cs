using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Acreditacion
{
    public class ResultadoDialog : BaseDialog, IDialog<object>
    {
        public readonly string _mensaje;

        public ResultadoDialog(AIResponse response)
        {
            _mensaje = ObtenerMensajeServicio(response);
        }

        public Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }
    }
}