using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared
{
    [Serializable]
    public class EmpezarDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext aoContexto)
        {
            IMessageActivity loActividad = aoContexto.MakeMessage();
            loActividad.Recipient = loActividad.From;
            loActividad.Type = ActivityTypes.Message;
            loActividad.Text = "Estas son algunas cosas que puedo hacer por ti 😀";
            loActividad.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            loActividad.Attachments = new List<Attachment>();

            HeroCard loTarjetaInformacion = new HeroCard()
            {
                Title = "Nosotros",
                Images = new List<CardImage>()
                {
                    new CardImage
                    {
                        Url = "http://w.radiouno.pe/imagenes/noticias/56054.jpg"
                    }
                },
                Buttons = new List<CardAction>()
                {
                    new CardAction
                    {
                        Title = "Dirección",
                        Value = "Direccion",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Teléfono",
                        Value = "Telefono",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            HeroCard loTarjetaPublicacion = new HeroCard()
            {
                Title = "Publicaciones",
                Buttons = new List<CardAction>()
                {
                    new CardAction
                    {
                        Title = "Noticias",
                        Value = "Noticias",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Actualidades",
                        Value = "Actualidades",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            HeroCard loTarjetaPlanEstudio = new HeroCard()
            {
                Title = "Plan de estudios",
                Buttons = new List<CardAction>()
                {
                    new CardAction
                    {
                        Title = "Plan de estudios",
                        Value = "Plan de estudios",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Malla curricular",
                        Value = "Malla curricular",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            HeroCard loTarjetaDocumento = new HeroCard()
            {
                Title = "Documentos importantes",
                Buttons = new List<CardAction>()
                {
                    new CardAction
                    {
                        Title = "Formatos",
                        Value = "Formatos",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Reglamentos",
                        Value = "Reglamentos",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            HeroCard loTarjetaOpinion = new HeroCard()
            {
                Title = "Tu opinión nos importa",
                Buttons = new List<CardAction>()
                {
                    new CardAction
                    {
                        Title = "Buzón de sugerencias",
                        Value = "Buzon",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Calificanos",
                        Value = "Calificanos",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            loActividad.Attachments.Add(loTarjetaInformacion.ToAttachment());
            loActividad.Attachments.Add(loTarjetaPublicacion.ToAttachment());
            loActividad.Attachments.Add(loTarjetaPlanEstudio.ToAttachment());
            loActividad.Attachments.Add(loTarjetaDocumento.ToAttachment());
            loActividad.Attachments.Add(loTarjetaOpinion.ToAttachment());

            await aoContexto.PostAsync(loActividad);

            aoContexto.Done(this);
        }
    }
}