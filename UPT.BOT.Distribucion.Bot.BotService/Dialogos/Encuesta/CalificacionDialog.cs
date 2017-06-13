using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Distribucion.Bot.Acceso.Encuesta;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Encuesta
{
    [Serializable]
    public class CalificacionDialog : BaseDialog, IDialog<object>
    {
        private readonly string mensaje;

        public CalificacionDialog(AIResponse response)
        {
            mensaje = response.Result.Fulfillment.Speech;
        }

        public async Task StartAsync(IDialogContext context)
        {
            IMessageActivity actividaMensaje = context.MakeMessage();
            actividaMensaje.Text = mensaje ?? string.Empty;
            actividaMensaje.Recipient = actividaMensaje.From;
            actividaMensaje.Type = ActivityTypes.Message;
            await context.PostAsync(actividaMensaje);

            EncuestaDto entidades = new EncuestaProxy(ruta).ObtenerXCodigo(1);
            PreguntaDto pregunta = entidades.Preguntas.FirstOrDefault();

            IMessageActivity actividadTarjeta = context.MakeMessage();
            actividadTarjeta.Recipient = actividadTarjeta.From;
            actividadTarjeta.Attachments = new List<Attachment>();
            actividadTarjeta.AttachmentLayout = AttachmentLayoutTypes.List;
            actividadTarjeta.Type = ActivityTypes.Message;
            List<Attachment> adjuntos = new List<Attachment>();

            HeroCard tarjeta = new HeroCard(pregunta.DescripcionPregunta);
            pregunta.Alternativas.Reverse();
            List<CardAction> botones = pregunta.Alternativas.Select(p => new CardAction
            {
                Title = p.DescripcionAlternativa,
                Value = p,
                Type = ActionTypes.PostBack,
                Image = "http://uptbotadministracion.azurewebsites.net/images/estrella.png"
            }).ToList();



            tarjeta.Buttons = botones;
            adjuntos.Add(tarjeta.ToAttachment());
            actividadTarjeta.Attachments = adjuntos;
            await context.PostAsync(actividadTarjeta);
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> respuesta)
        {
            var message = await respuesta;
            AlternativaDto alternativa = (AlternativaDto)message.Value;

            RespuestasDto respuestas = new RespuestasDto
            {
                CodigoAlternativa = Convert.ToInt64(alternativa.CodigoAlternativa),
                CodigoCliente = context.Activity.From.Id,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now
            };

            RespuestaProxy proxyRespuesta = new RespuestaProxy(ruta);
            proxyRespuesta.Guardar(respuestas);

            IMessageActivity actividaMensaje = context.MakeMessage();
            actividaMensaje.Text = "Muchas gracias!";
            actividaMensaje.Recipient = actividaMensaje.From;
            actividaMensaje.Type = ActivityTypes.Message;
            await context.PostAsync(actividaMensaje);
            context.Done(this);
        }
    }
}