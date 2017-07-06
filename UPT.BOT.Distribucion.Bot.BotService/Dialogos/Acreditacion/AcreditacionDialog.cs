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
        public readonly string _mensaje;

        public AcreditacionDialog(AIResponse response)
        {
            _mensaje = ObtenerMensajeServicio(response);
        }

        public async Task StartAsync(IDialogContext context)
        {
            IMessageActivity actividaMensaje = context.MakeMessage();
            actividaMensaje.Text = _mensaje ?? string.Empty;
            actividaMensaje.Recipient = actividaMensaje.From;
            actividaMensaje.Type = ActivityTypes.Message;

            await context.PostAsync(actividaMensaje);

            AcreditacionDto entidad = new AcreditacionProxy(ruta).Obtener();

            List<Attachment> adjuntos = new List<Attachment>();

            if (entidad != null)
            {
                HeroCard tarjetaAcreditacion = new HeroCard(entidad.DescripcionTitulo);
                tarjetaAcreditacion.Text = entidad.DescripcionResena;
                tarjetaAcreditacion.Images = new List<CardImage>
                {
                    new CardImage { Url = entidad.DescripcionImagen }
                };
                tarjetaAcreditacion.Buttons = new List<CardAction>
                {
                    new CardAction
                    {
                        Title = ActionTitleTypes.ShowMore,
                        Type = ActionTypes.OpenUrl,
                        Value = entidad.DescripcionUrl
                    }
                };
                adjuntos.Add(tarjetaAcreditacion.ToAttachment());
            }

            IMessageActivity actividadTarjeta = context.MakeMessage();
            actividadTarjeta.Recipient = actividadTarjeta.From;
            actividadTarjeta.Attachments = adjuntos;
            actividadTarjeta.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            actividadTarjeta.Type = ActivityTypes.Message;
            await context.PostAsync(actividadTarjeta);

            context.Done(this);
        }
    }
}
