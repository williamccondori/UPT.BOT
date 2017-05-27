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
    public class NosotrosDialog : BaseDialog, IDialog<object>
    {
        private AIResponse response;

        public NosotrosDialog(AIResponse response)
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

            NosotrosDto entidad = new NosotrosProxy(ruta).Obtener();

            HeroCard tarjetaNosotros = new HeroCard(entidad.DescripcionTitulo);
            tarjetaNosotros.Text = entidad.DescripcionResumen;
            tarjetaNosotros.Images = NosotrosImagen(entidad.DescripcionImagen);
            tarjetaNosotros.Buttons = NosotrosAccion(entidad.DescripcionUrl);

            IMessageActivity actividadTarjeta = context.MakeMessage();
            actividadTarjeta.Recipient = actividadTarjeta.From;
            actividadTarjeta.Type = ActivityTypes.Message;
            actividadTarjeta.Attachments = new List<Attachment>
            {
                tarjetaNosotros.ToAttachment()
            };

            await context.PostAsync(actividadTarjeta);

            context.Done(this);
        }

        private IList<CardAction> NosotrosAccion(string url) => new List<CardAction>
        {
            new CardAction { Title = ActionTitleTypes.ShowMore, Type = ActionTypes.OpenUrl, Value = url}
        };

        private IList<CardImage> NosotrosImagen(string url) => new List<CardImage>
        {
            new CardImage{ Url = url }
        };
    }
}