using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Distribucion.Bot.Acceso.Adjunto;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Planestudio
{
    [Serializable]
    public class MallaCurricularDialog : IDialog<object>
    {
        private string Mensaje { get; set; }

        public MallaCurricularDialog(string mensaje)
        {
            Mensaje = mensaje;
        }

        public async Task StartAsync(IDialogContext context)
        {
            List<Attachment> adjuntos = new List<Attachment>();

            MallaCurricularDto mallaCurricular = new MallaCurricularProxy(VariableConfiguracion.RutaApi()).Obtener();

            Attachment imagen = new Attachment(mallaCurricular.TipoAdjunto);

            imagen.ContentUrl = mallaCurricular.DescripcionUrl;

            adjuntos.Add(imagen);

            IMessageActivity actividad = context.MakeMessage();
            actividad.Recipient = actividad.From;
            actividad.Type = ActivityTypes.Message;
            actividad.Attachments = adjuntos;
            actividad.AttachmentLayout = AttachmentLayoutTypes.List;
            actividad.Text = Mensaje;

            await context.PostAsync(actividad);

            context.Done(this);
        }
    }
}