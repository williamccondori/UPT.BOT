using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Distribucion.Bot.Acceso.Documento;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Documento
{
    public class BoletinDialog : IDialog<object>
    {
        private string Mensaje { get; set; }

        public BoletinDialog(string mensaje)
        {
            Mensaje = mensaje;
        }

        public async Task StartAsync(IDialogContext context)
        {
            HeroCard tarjeta = new HeroCard("Boletines", Mensaje);

            List<BoletinDto> listaBoletines = new BoletinProxy(VariableConfiguracion.RutaApi()).Obtener();

            List<CardAction> botones = listaBoletines.Select(p => new CardAction
            {
                Title = p.DescripcionTitulo,
                Value = p.DescripcionUrl,
                Type = ActionTypes.DownloadFile
            }).ToList();

            tarjeta.Buttons = botones;

            List<Attachment> adjuntos = new List<Attachment>();

            adjuntos.Add(tarjeta.ToAttachment());

            IMessageActivity actividad = context.MakeMessage();
            actividad.Recipient = actividad.From;
            actividad.Type = ActivityTypes.Message;
            actividad.Attachments = adjuntos;
            actividad.AttachmentLayout = AttachmentLayoutTypes.List;

            await context.PostAsync(actividad);

            context.Done(this);
        }
    }
}