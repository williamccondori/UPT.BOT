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
            loActividad.Text = "Estas son algunas de las opciones que tengo para ti 😀";
            loActividad.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            loActividad.Attachments = new List<Attachment>();

            HeroCard loTarjetaInformacion = new HeroCard()
            {
                Title = "Información",
                Text = "Información a cerca de la universidad o de la escuela profesional.",
                Images = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = "http://uptbotadministracion.azurewebsites.net/images/01.png"
                    }
                },
                Buttons = new List<CardAction>
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
                Text = "Mantente al día con las principales noticias y actualidades.",
                Images = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = "http://uptbotadministracion.azurewebsites.net/images/02.png"
                    }
                },
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
                    },
                    new CardAction
                    {
                        Title = "Eventos",
                        Value = "Eventos",
                        Type = ActionTypes.ImBack
                    },
                    new CardAction
                    {
                        Title = "Galería de fotos",
                        Value = "Galería",
                        Type = ActionTypes.ImBack
                    }
                }
            };

            HeroCard loTarjetaPlanEstudio = new HeroCard()
            {
                Title = "Plan de estudios",
                Text = "Información a cerca del plan de estudio actual.",
                Images = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = "http://uptbotadministracion.azurewebsites.net/images/03.png"
                    }
                },
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
                Title = "Documentos",
                Text = "Documentos importantes para estudiantes y docentes.",
                Images = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = "http://uptbotadministracion.azurewebsites.net/images/04.png"
                    }
                },
                Buttons = new List<CardAction>
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
                Title = "Contáctenos",
                Text = "Tu opinión nos importa, no perdamos contacto.",
                Images = new List<CardImage>
                {
                    new CardImage
                    {
                        Url = "http://uptbotadministracion.azurewebsites.net/images/05.png"
                    }
                },
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