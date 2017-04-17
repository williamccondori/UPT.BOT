using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión;
using UPT.BOT.Distribucion.Bot.Acceso.Publicacion;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Bot
{
    [Serializable]
    public class NoticiaDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext aoContexto)
        {
            //await aoContexto.PostAsync("Buscaré algunas noticias");

            var loNoticiaProxy = new NoticiaProxy(
                VariableConfiguracion.RutaApi()
                , VariableConfiguracion.VersionApi()
                , VariableConfiguracion.ServicioApi());

            List<NoticiaConsultaBotDto> listaNoticia = loNoticiaProxy.Obtener();

            IMessageActivity loActividad = aoContexto.MakeMessage();
            loActividad.Recipient = loActividad.From;
            loActividad.Type = "message";
            loActividad.Attachments = new List<Attachment>();
            loActividad.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            loActividad.Text = "He encontrado las siguientes noticias!";

            foreach (var loNoticia in listaNoticia)
            {
                List<CardImage> listaImagen = new List<CardImage>();
                listaImagen.Add(new CardImage()
                {
                    Url = loNoticia.DescripcionImagen
                });
                List<CardAction> listaBoton = new List<CardAction>();
                listaBoton.Add(new CardAction()
                {
                    Value = loNoticia.DescripcionUrl,
                    Type = "openUrl",
                    Title = "Mostrar Más"
                });

                HeroCard plCard = new HeroCard()
                {
                    Title = loNoticia.DescripcionTitulo,
                    Text = loNoticia.DescripcionResumen,
                    Images = listaImagen,
                    Buttons = listaBoton,
                };

                Attachment plAttachment = plCard.ToAttachment();

                loActividad.Attachments.Add(plAttachment);
            }

            await aoContexto.PostAsync(loActividad);

            aoContexto.Done(this);
        }

    }
}