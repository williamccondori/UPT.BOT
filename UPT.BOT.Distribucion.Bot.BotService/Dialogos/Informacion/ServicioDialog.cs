using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Distribucion.Bot.Acceso.Informacion;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Informacion
{
    public class ServicioDialog : BaseDialog, IDialog<object>
    {
        private AIResponse response;

        public ServicioDialog(AIResponse response)
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

            List<ServicioDto> entidades = new ServicioProxy(ruta).Obtener();

            List<Attachment> listaAdjuntos = new List<Attachment>();

            foreach (var entidad in entidades)
            {
                HeroCard tarjetaServicio = new HeroCard(entidad.DescripcionTitulo);
                tarjetaServicio.Text = entidad.DescripcionResena;
                tarjetaServicio.Images = ServicioImagen(entidad.DescripcionImagen);
                tarjetaServicio.Buttons = ServicioAccion(entidad.DescripcionUrl);
                listaAdjuntos.Add(tarjetaServicio.ToAttachment());
            }

            IMessageActivity actividadTarjeta = context.MakeMessage();
            actividadTarjeta.Recipient = actividadTarjeta.From;
            actividadTarjeta.Type = ActivityTypes.Message;
            actividadTarjeta.Attachments = listaAdjuntos;
            actividadTarjeta.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            await context.PostAsync(actividadTarjeta);

            context.Done(this);
        }

        private IList<CardAction> ServicioAccion(string url) => new List<CardAction>
        {
            new CardAction { Title = ActionTitleTypes.ShowMore, Type = ActionTypes.OpenUrl, Value = url}
        };

        private IList<CardImage> ServicioImagen(string url) => new List<CardImage>
        {
            new CardImage{ Url = url }
        };
    }
}
