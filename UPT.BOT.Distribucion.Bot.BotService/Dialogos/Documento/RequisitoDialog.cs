using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Distribucion.Bot.Acceso.Documento;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Documento
{
    [Serializable]
    public class RequisitoDialog : BaseDialog, IDialog<object>
    {
        private AIResponse response;

        public RequisitoDialog(AIResponse response)
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

            List<RequisitoDto> entidades = new RequisitoProxy(ruta).Obtener();

            List<Attachment> listaAdjuntos = new List<Attachment>();
            HeroCard tarjetaFormato = new HeroCard("Requisitos");
            tarjetaFormato.Subtitle = "Puedes descargar archivos con requisitos que te pueden ser útiles!";
            tarjetaFormato.Buttons = entidades.Select(p => new CardAction
            {
                Title = p.DescripcionTitulo,
                Value = p.DescripcionUrl,
                Type = ActionTypes.DownloadFile
            }).ToList();

            listaAdjuntos.Add(tarjetaFormato.ToAttachment());
            IMessageActivity actividadTarjeta = context.MakeMessage();
            actividadTarjeta.Recipient = actividadTarjeta.From;
            actividadTarjeta.Attachments = listaAdjuntos;
            actividadTarjeta.AttachmentLayout = AttachmentLayoutTypes.List;
            actividadTarjeta.Type = ActivityTypes.Message;

            await context.PostAsync(actividadTarjeta);

            context.Done(this);
        }
    }
}