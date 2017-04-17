using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Adjunto
{
    [Serializable]
    public class ReglamentoDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext aoContexto)
        {
            IMessageActivity loActividad = aoContexto.MakeMessage();
            loActividad.Recipient = loActividad.From;
            loActividad.Type = ActivityTypes.Message;
            loActividad.Attachments = new List<Attachment>();

            List<CardAction> listaBotones = new List<CardAction>();

            listaBotones.Add(new CardAction()
            {
                Title = "📜 Reglamento de grados y titulos",
                Value = "http://epis.upt.edu.pe/acreditacion/docs/docentes/Reglamento_de_grados_y_titulos.pdf",
                Type = ActionTypes.DownloadFile
            });

            listaBotones.Add(new CardAction()
            {
                Title = "📜 Reglamento de Prácticas",
                Value = "http://epis.upt.edu.pe/acreditacion/docs/docentes/Reglamento_de_grados_y_titulos.pdf",
                Type = ActionTypes.DownloadFile
            });

            HeroCard loTarjeta = new HeroCard();
            loTarjeta.Text = "¿Cuál de estos reglamentos deseas ver?";
            loTarjeta.Buttons = listaBotones;


            loActividad.Attachments.Add(loTarjeta.ToAttachment());

            await aoContexto.PostAsync(loActividad);

            aoContexto.Done(this);
        }
    }
}