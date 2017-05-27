using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Dialogs;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Documento;
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
            => await Empezar(() => Dialogo(context, response, new PredeterminadoDialog(response.Result.Fulfillment.Speech)));

        [AiIntent("extras.saludo")]
        public async Task Saludar(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new SaludarDialog(response), Menu));

        // intenciones para mostrar información general

        [AiIntent("informacion.nosotros")]
        public async Task Nosotros(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new NosotrosDialog(response)));

        [AiIntent("informacion.direccion")]
        public async Task Direccion(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new DireccionDialog(response.Result.Fulfillment.Speech)));

        [AiIntent("informacion.telefono")]
        public async Task Telefono(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new TelefonoDialog(response.Result.Fulfillment.Speech)));

        [AiIntent("informacion.convenio")]
        public async Task Convenio(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new ConvenioDialog(response.Result.Fulfillment.Speech)));

        [AiIntent("informacion.servicio")]
        public async Task Servicio(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new ServicioDialog(response.Result.Fulfillment.Speech)));

        [AiIntent("informacion.admision")]
        public async Task Admision(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new AdmisionDialog(response.Result.Fulfillment.Speech)));

        [AiIntent("informacion.acreditacion")]
        public async Task Acreditacion(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new AcreditacionDialog(response.Result.Fulfillment.Speech)));

        [AiIntent("informacion.social")]
        public async Task Social(IDialogContext context, AIResponse response)
            => await Empezar(() => Dialogo(context, response, new SocialDialog(response.Result.Fulfillment.Speech)));

        // intenciones para mostrar información de publicaciones

        [AiIntent("publicacion.noticia")]
        public async Task Noticia(IDialogContext context, AIResponse response) => await Empezar(() => Dialogo(context, response, new NoticiaDialog(response.Result.Fulfillment.Speech)));

        // intenciones para mostrar información del plan de estudios

        [AiIntent("planestudio.mallacurricular")]
        public async Task MallaCurricular(IDialogContext context, AIResponse response) => await Empezar(() => Dialogo(context, response, new MallaCurricularDialog(response.Result.Fulfillment.Speech)));

        // intenciones para mostrar información de documentos

        [AiIntent("documento.formato")]
        public async Task Formato(IDialogContext context, AIResponse response) => await Empezar(() => Dialogo(context, response, new FormatoDialog(response.Result.Fulfillment.Speech)));

        [AiIntent("documento.reglamento")]
        public async Task Reglamento(IDialogContext context, AIResponse response) => await Empezar(() => Dialogo(context, response, new ReglamentoDialog(response.Result.Fulfillment.Speech)));

        [AiIntent("documento.boletin")]
        public async Task Boletin(IDialogContext context, AIResponse response) => await Empezar(() => Dialogo(context, response, new BoletinDialog(response.Result.Fulfillment.Speech)));


    }
}