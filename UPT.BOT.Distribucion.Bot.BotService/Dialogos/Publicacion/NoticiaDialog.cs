using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            List<Elemento> listaNoticias = new RssProxy("http://rpp.pe/feed/tecnologia").Obtener();

            List<Attachment> adjuntos = new List<Attachment>();

            //List<NoticiaDto> listaNoticias = new NoticiaProxy(VariableConfiguracion.RutaApi()).Obtener();

            foreach (var noticia in listaNoticias)
            {
                HeroCard tarjeta = new HeroCard(noticia.Titulo);

                List<CardImage> listaImagenes = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = noticia.Imagen
                    }
                };

                List<CardAction> listaBotones = new List<CardAction>
                {
                    new CardAction
                    {
                        Value = noticia.Enlace,
                        Type = ActionTypes.OpenUrl,
                        Title = ActionTitleTypes.ShowMore
                    }
                };

                tarjeta.Text = noticia.Descripcion;

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