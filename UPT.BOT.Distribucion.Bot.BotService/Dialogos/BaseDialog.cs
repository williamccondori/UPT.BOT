using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos
{
    public class BaseDialog
    {
        protected IMessageActivity CrearActividad(IDialogContext contexto, IList<Attachment> listaAdjuntos, string tipoAdjunto = AttachmentLayoutTypes.List)
        {
            IMessageActivity actividad = contexto.MakeMessage();
            actividad.Recipient = actividad.From;
            actividad.Type = ActivityTypes.Message;
            actividad.Attachments = listaAdjuntos;
            actividad.AttachmentLayout = tipoAdjunto;

            foreach (var adjunto in listaAdjuntos)
            {
                actividad.Attachments.Add(adjunto);
            }

            return actividad;
        }
    }
}