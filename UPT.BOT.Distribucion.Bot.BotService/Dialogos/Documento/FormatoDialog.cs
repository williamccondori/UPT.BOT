using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Distribucion.Bot.Acceso.Documento;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Documento
{
    public class FormatoDialog : BaseDialog, IDialog<object>
    {
        private AIResponse response;

        public FormatoDialog(AIResponse response)
        {
            this.response = response;
        }

        public async Task StartAsync(IDialogContext context)
        {
            IMessageActivity actividaMensaje = context.MakeMessage();
            actividaMensaje.Text = response.Result.Fulfillment.Speech ?? string.Empty;
            actividaMensaje.Recipient = actividaMensaje.From;
            actividaMensaje.Type = ActivityTypes.Message;

            await context.PostAsync(actividaMensaje);

            List<FormatoDto> entidades = new FormatoProxy(ruta).Obtener();

            List<Attachment> listaAdjuntos = new List<Attachment>();

            foreach (var entidad in entidades)
            {
                HeroCard tarjetaFormato = new HeroCard("Formatos");
                tarjetaFormato.Buttons = FormatoAccion(entidad.DescripcionUrl, entidad.DescripcionTitulo);
                listaAdjuntos.Add(tarjetaFormato.ToAttachment());
            }

            IMessageActivity actividadTarjeta = context.MakeMessage();
            actividadTarjeta.Recipient = actividadTarjeta.From;
            actividadTarjeta.Type = ActivityTypes.Message;

            await context.PostAsync(actividadTarjeta);

            context.Done(this);
        }

        private IList<CardAction> FormatoAccion(string url, string titulo) => new List<CardAction>
        {
            new CardAction { Title = titulo, Type = ActionTypes.DownloadFile, Value = url}
        };
    }
}
