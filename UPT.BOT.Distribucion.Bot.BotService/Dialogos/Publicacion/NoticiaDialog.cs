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
    public class NoticiaDialog : IDialog<object>
    {
        private string Mensaje { get; set; }

        public NoticiaDialog(string mensaje)
        {
            Mensaje = mensaje;
        }

        public async Task StartAsync(IDialogContext contexto)
        {
            List<Attachment> adjuntos = new List<Attachment>();

            List<NoticiaDto> listaNoticias = new NoticiaProxy(VariableConfiguracion.RutaApi()).Obtener();

            foreach (var noticia in listaNoticias)
            {
                HeroCard tarjeta = new HeroCard(noticia.DescripcionTitulo);

                List<CardImage> listaImagenes = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = noticia.DescripcionImagen
                    }
                };

                List<CardAction> listaBotones = new List<CardAction>
                {
                    new CardAction
                    {
                        Value = noticia.DescripcionUrl,
                        Type = ActionTypes.OpenUrl,
                        Title = ActionTitleTypes.ShowMore
                    }
                };

                tarjeta.Text = noticia.DescripcionResumen;

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