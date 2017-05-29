using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Distribucion.Bot.Acceso.Documento;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Documento
{
    [Serializable]
    public class ReglamentoDialog : BaseDialog, IDialog<object>
    {
        private AIResponse response;

        public ReglamentoDialog(AIResponse response)
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

            List<ReglamentoDto> entidades = new ReglamentoProxy(ruta).Obtener();

            List<Attachment> listaAdjuntos = new List<Attachment>();

            foreach (var entidad in entidades)
            {
                HeroCard tarjetaReglamento = new HeroCard("Reglamentos");
                tarjetaReglamento.Buttons = ReglamentoAccion(entidad.DescripcionUrl, entidad.DescripcionTitulo);
                listaAdjuntos.Add(tarjetaReglamento.ToAttachment());
            }

            IMessageActivity actividadTarjeta = context.MakeMessage();
            actividadTarjeta.Recipient = actividadTarjeta.From;
            actividadTarjeta.Type = ActivityTypes.Message;

            await context.PostAsync(actividadTarjeta);

            context.Done(this);
        }

        private IList<CardAction> ReglamentoAccion(string url, string titulo) => new List<CardAction>
        {
            new CardAction { Title = titulo, Type = ActionTypes.DownloadFile, Value = url}
        };
    }
}
