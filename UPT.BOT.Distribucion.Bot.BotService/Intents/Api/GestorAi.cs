using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Dialogs;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Documento;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Encuesta;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Extras;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Informacion;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Planestudio;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Publicacion;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared;

namespace UPT.BOT.Distribucion.Bot.BotService.Intents.Api
{
    [Serializable]
    public class GestorAi : BaseAi
    {
        [AiIntent("Predeterminado")]
        public async Task Predeterminado(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new PredeterminadoDialog(response.Result.Fulfillment.Speech)));
        }

        [AiIntent("extras.saludo")]
        public async Task Saludar(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new SaludarDialog(response), Menu));
        }

        // intenciones para mostrar información general

        [AiIntent("informacion.nosotros")]
        public async Task Nosotros(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new NosotrosDialog(response)));

        [AiIntent("informacion.direccion")]
        public async Task Direccion(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new DireccionDialog(response)));

        [AiIntent("informacion.telefono")]
        public async Task Telefono(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new TelefonoDialog(response)));

        [AiIntent("informacion.convenio")]
        public async Task Convenio(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new ConvenioDialog(response)));

        [AiIntent("informacion.servicio")]
        public async Task Servicio(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new ServicioDialog(response)));

        [AiIntent("informacion.admision")]
        public async Task Admision(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new AdmisionDialog(response)));

        [AiIntent("informacion.acreditacion")]
        public async Task Acreditacion(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new AcreditacionDialog(response)));

        [AiIntent("informacion.social")]
        public async Task Social(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new SocialDialog(response)));

        // intenciones para mostrar información de publicaciones

        [AiIntent("publicacion.noticia")]
        public async Task Noticia(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new NoticiaDialog(response)));
        }

        [AiIntent("publicacion.actualidad")]
        public async Task Actualidad(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new ActualidadDialog(response)));
        }

        [AiIntent("publicacion.comunicado")]
        public async Task Comunicado(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new ComunicadoDialog(response)));
        }

        [AiIntent("publicacion.evento")]
        public async Task Evento(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new EventoDialog(response)));
        }

        [AiIntent("publicacion.galeria")]
        public async Task Galeria(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new GaleriaDialog(response)));
        }

        [AiIntent("publicacion.publicacion")]
        public async Task Publicacion(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new PublicacionDialog(response)));
        }

        // intenciones para mostrar información del plan de estudios

        [AiIntent("planestudio.mallacurricular")]
        public async Task MallaCurricular(IDialogContext context, AIResponse response) => await Empezar(() => Dialogo(context, response, new MallaCurricularDialog(response.Result.Fulfillment.Speech)));

        // intenciones para mostrar información de documentos

        [AiIntent("documento.formato")]
        public async Task Formato(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new FormatoDialog(response)));
        }

        [AiIntent("documento.reglamento")]
        public async Task Reglamento(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new ReglamentoDialog(response)));
        }

        [AiIntent("documento.boletin")]
        public async Task Boletin(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new BoletinDialog(response)));
        }

        [AiIntent("documento.requisito")]
        public async Task Requsito(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new RequsitoDialog(response)));
        }

        [AiIntent("encuesta.calificacion")]
        public async Task Calificacion(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new CalificacionDialog(response)));
        }
    }
}