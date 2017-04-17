using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente;
using UPT.BOT.Distribucion.Bot.Acceso.Adjunto;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Adjunto
{
    [Serializable]
    public class MallaCurricularDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext aoContexto)
        {
            var loMallaCurricularProxy = new MallaCurricularProxy(
                 VariableConfiguracion.RutaApi()
                 , VariableConfiguracion.VersionApi()
                 , VariableConfiguracion.ServicioApi());

            AdjuntoDto loMallaCurricular = loMallaCurricularProxy.Obtener();

            IMessageActivity loActividad = aoContexto.MakeMessage();
            loActividad.Recipient = loActividad.From;
            loActividad.Type = ActivityTypes.Message;
            loActividad.Attachments = new List<Attachment>();
            loActividad.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            loActividad.Text = "Esta es la malla curricular que tenemos actualmente!";

            loActividad.Attachments.Add(new Attachment()
            {
                ContentUrl = loMallaCurricular.UrlAdjunto,
                ContentType = "image/png",
                Name = loMallaCurricular.DescripcionTitulo
            });


            await aoContexto.PostAsync(loActividad);

            aoContexto.Done(this);
        }
    }
}