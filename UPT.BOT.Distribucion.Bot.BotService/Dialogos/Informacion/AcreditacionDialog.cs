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
    public class AcreditacionDialog : BaseDialog, IDialog<object>
    {
        private AIResponse response;

        public AcreditacionDialog(AIResponse response)
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

            AcreditacionDto entidad = new AcreditacionProxy(ruta).Obtener();

            List<Attachment> listaAdjuntos = new List<Attachment>();

            if (entidad != null)
            {
                HeroCard tarjetaAcreditacion = new HeroCard(entidad.DescripcionTitulo);
                tarjetaAcreditacion.Text = entidad.DescripcionResumen;
                tarjetaAcreditacion.Images = AcreditacionImagen(entidad.DescripcionImagen);
                tarjetaAcreditacion.Buttons = AcreditacionAccion(entidad.DescripcionUrl);
            }

            IMessageActivity actividadTarjeta = context.MakeMessage();
            actividadTarjeta.Recipient = actividadTarjeta.From;
            actividadTarjeta.Type = ActivityTypes.Message;
            actividadTarjeta.Attachments = listaAdjuntos;

            await context.PostAsync(actividadTarjeta);

            context.Done(this);
        }

        private IList<CardAction> AcreditacionAccion(string url) => new List<CardAction>
        {
            new CardAction { Title = ActionTitleTypes.ShowMore, Type = ActionTypes.OpenUrl, Value = url}
        };

        private IList<CardImage> AcreditacionImagen(string url) => new List<CardImage>
        {
            new CardImage{ Url = url }
        };
    }
}
