using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Distribucion.Bot.Acceso.Publicacion;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Publicacion
{
    [Serializable]
    public class ActualidadDialog : IDialog<object>
    {
        private string Mensaje { get; set; }

        public ActualidadDialog(string mensaje)
        {
            Mensaje = mensaje;
        }

        public async Task StartAsync(IDialogContext contexto)
        {
            List<Attachment> adjuntos = new List<Attachment>();

            List<ActualidadDto> listaActualidades = new ActualidadProxy(VariableConfiguracion.RutaApi()).Obtener();

            foreach (var actualidad in listaActualidades)
            {
                HeroCard tarjeta = new HeroCard(actualidad.DescripcionTitulo);

                List<CardImage> listaImagenes = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = actualidad.DescripcionImagen
                    }
                };

                List<CardAction> listaBotones = new List<CardAction>
                {
                    new CardAction
                    {
                        Value = actualidad.DescripcionUrl,
                        Type = ActionTypes.OpenUrl,
                        Title = ActionTitleTypes.ShowMore
                    }
                };

                tarjeta.Text = actualidad.DescripcionResumen;

                tarjeta.Images = listaImagenes;

                tarjeta.Buttons = listaBotones;

                adjuntos.Add(tarjeta.ToAttachment());
            }

            IMessageActivity actividadRespuesta = contexto.MakeMessage();
            actividadRespuesta.Recipient = actividadRespuesta.From;
            actividadRespuesta.Type = ActivityTypes.Message;
            actividadRespuesta.Attachments = adjuntos;
            actividadRespuesta.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            actividadRespuesta.Text = Mensaje;

            await contexto.PostAsync(actividadRespuesta);

            contexto.Done(this);
        }
    }
}