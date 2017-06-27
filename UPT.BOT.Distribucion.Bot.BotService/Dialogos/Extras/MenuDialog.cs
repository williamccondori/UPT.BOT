using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UPT.BOT.Distribucion.Bot.BotService.Dialogos.Extras
{
    public class MenuDialog : BaseDialog, IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            IMessageActivity actividaMensaje = context.MakeMessage();
            actividaMensaje.Text = "Estas son algunas de las opciones que tenemos para ti 😎";
            actividaMensaje.Recipient = actividaMensaje.From;
            actividaMensaje.Type = ActivityTypes.Message;

            await context.PostAsync(actividaMensaje);

            HeroCard tarjetaInformacion = new HeroCard("Información");
            tarjetaInformacion.Subtitle = "Encuentre información acerca de la escuela profesional de manera rápida.";
            tarjetaInformacion.Images = InformacionImagen();
            tarjetaInformacion.Buttons = InformacionAccion();

            HeroCard tarjetaPublicacion = new HeroCard("Publicaciones");
            tarjetaPublicacion.Subtitle = "Vea las publicaciones de la escuela profesional de manera rápida.";
            tarjetaPublicacion.Images = PublicacionImagen();
            tarjetaPublicacion.Buttons = PublicacionAccion();

            HeroCard tarjetaPlanestudio = new HeroCard("Plan de estudios");
            tarjetaPlanestudio.Subtitle = "Obtenga inforamción acerca de nuestro plan de estudios.";
            tarjetaPlanestudio.Images = PlanestudioImagen();
            tarjetaPlanestudio.Buttons = PlanestudioAccion();

            HeroCard tarjetaDocumento = new HeroCard("Documentos");
            tarjetaDocumento.Subtitle = "Descargue documentos útiles de la escuela profesional.";
            tarjetaDocumento.Images = DocumentoImagen();
            tarjetaDocumento.Buttons = DocumentoAccion();

            HeroCard tarjetaContacto = new HeroCard("Contacto");
            tarjetaContacto.Subtitle = "Póngase en contacto con nosotros y califique nuestro servicio.";
            tarjetaContacto.Images = ContactoImagen();
            tarjetaContacto.Buttons = ContactoAccion();

            IMessageActivity actividadTarjeta = context.MakeMessage();
            actividadTarjeta.Recipient = actividadTarjeta.From;
            actividadTarjeta.Type = ActivityTypes.Message;
            actividadTarjeta.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            actividadTarjeta.Attachments = new List<Attachment>
            {
                tarjetaInformacion.ToAttachment(),
                tarjetaPublicacion.ToAttachment(),
                tarjetaPlanestudio.ToAttachment(),
                tarjetaDocumento.ToAttachment(),
                tarjetaContacto.ToAttachment()
            };

            await context.PostAsync(actividadTarjeta);

            context.Done(this);
        }

        private IList<CardAction> ContactoAccion() => new List<CardAction>
        {
            //new CardAction { Title = "Contáctanos", Value = "Contáctanos" },
            //new CardAction { Title = "Sugerencias", Value = "Sugerencias" },
            new CardAction { Title = "Califícanos", Value = "Califícanos" },
            //new CardAction { Title = "Módulo de encuestas", Value = "Encuestas" },
            //new CardAction { Title = "Módulo de notas", Value = "Notas" },
            //new CardAction { Title = "Módulo de horarios", Value = "Horarios" }
        };

        private IList<CardImage> ContactoImagen() => new List<CardImage>
        {
            new CardImage{ Url = "http://uptbotadministracion.azurewebsites.net/images/05.png" }
        };

        private IList<CardAction> DocumentoAccion() => new List<CardAction>
        {
            new CardAction { Title = "Formatos", Value = "Formatos" },
            new CardAction { Title = "Reglamentos", Value = "Reglamentos" },
            new CardAction { Title = "Boletines", Value = "Boletines" }
        };


        private IList<CardImage> DocumentoImagen()
        {
            return new List<CardImage>
            {
                new CardImage{ Url = "http://uptbotadministracion.azurewebsites.net/images/04.png" }
            };
        }

        private IList<CardAction> PlanestudioAccion()
        {
            return new List<CardAction>
            {
                //new CardAction { Title = "Plan de estudios", Value = "Plan de estudios" },
                //new CardAction { Title = "Malla curricular", Value = "Malla curricular" },
                //new CardAction { Title = "Perfíl profesional", Value = "Perfíl profesional" }
            };
        }

        private IList<CardImage> PlanestudioImagen()
        {
            return new List<CardImage>
            {
                new CardImage{ Url = "http://uptbotadministracion.azurewebsites.net/images/03.png" }
            };
        }

        private IList<CardAction> PublicacionAccion()
        {
            return new List<CardAction>
            {
                new CardAction { Title = "Noticias", Value = "Noticias" },
                new CardAction { Title = "Actualidades", Value = "Actualidades" },
                new CardAction { Title = "Eventos", Value = "Eventos" },

                new CardAction { Title = "Comunicados", Value = "Comunicados" },
                new CardAction { Title = "Galerias", Value = "Galerias" },
                new CardAction { Title = "Publicaciones", Value = "Publicaciones" }
            };
        }

        private IList<CardImage> PublicacionImagen()
        {
            return new List<CardImage>
            {
                new CardImage{ Url = "http://uptbotadministracion.azurewebsites.net/images/02.png" }
            };
        }

        private IList<CardImage> InformacionImagen() => new List<CardImage>
        {
            new CardImage{ Url = "http://uptbotadministracion.azurewebsites.net/images/01.png" }
        };

        private IList<CardAction> InformacionAccion() => new List<CardAction>
        {
            new CardAction { Title = "Nosotros", Value = "Nosotros" },
            new CardAction { Title = "Direcciones", Value = "Direcciones" },
            new CardAction { Title = "Teléfonos", Value = "Teléfonos" },
            new CardAction { Title = "Convenios", Value = "Convenios" },
            //new CardAction { Title = "Servicios", Value = "Servicios" },
            //new CardAction { Title = "Enlaces importantes", Value = "Enlaces importantes" },
            //new CardAction { Title = "Admisión", Value = "Admisión" },
            new CardAction { Title = "Acreditación", Value = "Acreditación" },
            //new CardAction { Title = "Redes sociales", Value = "Redes sociales" }
        };
    }
}