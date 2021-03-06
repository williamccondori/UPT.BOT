﻿using ApiAiSDK.Model;
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
    public class ComunicadoDialog : BaseDialog, IDialog<object>
    {
        private AIResponse response;

        public ComunicadoDialog(AIResponse response)
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

            List<ComunicadoDto> entidades = new ComunicadoProxy(ruta).Obtener();

            List<Attachment> adjuntos = new List<Attachment>();

            entidades.ForEach(p =>
            {
                HeroCard tarjeta = new HeroCard(p.DescripcionTitulo);
                List<CardImage> imagenes = new List<CardImage>
                {
                    new CardImage { Url = p.DescripcionImagen }
                };
                List<CardAction> botones = new List<CardAction>
                {
                    new CardAction{ Value = p.DescripcionUrl, Type = ActionTypes.OpenUrl, Title = ActionTitleTypes.ShowMore }
                };
                tarjeta.Text = p.DescripcionResumen;
                tarjeta.Images = imagenes;
                tarjeta.Buttons = botones;
                adjuntos.Add(tarjeta.ToAttachment());
            });

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