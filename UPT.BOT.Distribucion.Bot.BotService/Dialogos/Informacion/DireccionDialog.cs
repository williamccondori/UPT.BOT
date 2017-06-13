using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Distribucion.Bot.Acceso.Informacion;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Informacion
{
    public class DireccionDialog : BaseDialog, IDialog<object>
    {
        private AIResponse response;

        public DireccionDialog(AIResponse response)
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

            List<DireccionDto> entidades = new DireccionProxy(ruta).Obtener();

            List<Attachment> listaAdjuntos = new List<Attachment>();

            foreach (var entidad in entidades)
            {
                HeroCard tarjetaDireccion = new HeroCard(entidad.DescripcionTitulo);
                tarjetaDireccion.Text = entidad.DescripcionDireccion;
                tarjetaDireccion.Buttons = ConvenioAccion(entidad.DescripcionMapa);
                listaAdjuntos.Add(tarjetaDireccion.ToAttachment());
            }

            IMessageActivity actividadTarjeta = context.MakeMessage();
            actividadTarjeta.Recipient = actividadTarjeta.From;
            actividadTarjeta.Type = ActivityTypes.Message;
            actividadTarjeta.Attachments = listaAdjuntos;
            actividadTarjeta.AttachmentLayout = AttachmentLayoutTypes.List;

            await context.PostAsync(actividadTarjeta);

            context.Done(this);
        }

        private IList<CardAction> ConvenioAccion(string url) => new List<CardAction>
        {
            new CardAction { Title = "Ubicación", Type = ActionTypes.OpenUrl, Value = url}
        };
    }
}