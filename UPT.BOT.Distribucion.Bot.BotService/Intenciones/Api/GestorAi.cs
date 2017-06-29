using ApiAiSDK.Model;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using UPT.BOT.Distribucion.Bot.BotService.ApiAiSdk.Dialogs;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Acreditacion;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Documento;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Encuesta;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Extras;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Informacion;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Planestudio;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Publicacion;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos.Shared;

namespace UPT.BOT.Distribucion.Bot.BotService.Intenciones.Api
{
    /// <summary>
    /// clase que se encarga de gestionar las intenciones del usuario
    /// y crear los diferentes dialogos
    /// </summary>
    [Serializable]
    public class GestorAi : BaseAi
    {
        /// <summary>
        /// comienza el dialogo cuando no se encuentra la intención del usuario
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Extras.Predeterminado)]
        public async Task Predeterminado(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new PredeterminadoDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario saluda
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Extras.Saludar)]
        public async Task Saludar(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new SaludarDialog(response), Menu));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario agradece
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Extras.Agradecer)]
        public async Task Agradecer(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new CreadorDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario pregunta por el creador
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Extras.Creador)]
        public async Task Creador(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new CreadorDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario quire ver el menú de opciones
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Extras.Menu)]
        public async Task Menu(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new MenuDialog(response)));
        }

        /// <summary>
        /// continua el dialogo con el dialogo del menú
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="result">resultado interno de la conversación</param>
        /// <returns>ejecución del diálogo</returns>
        private async Task Menu(IDialogContext context, IAwaitable<object> result)
        {
            await Empezar(() => context.Call(new MenuDialog(), Terminar));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita ayuda
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del dialgo</returns>
        [AiIntent(Extras.Ayuda)]
        public async Task Ayuda(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new AyudaDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de la escuela
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Informacion.Nosotros)]
        public async Task Nosotros(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new NosotrosDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de direcciones
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Informacion.Direccion)]
        public async Task Direccion(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new DireccionDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de teléfonos
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Informacion.Telefono)]
        public async Task Telefono(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new TelefonoDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de la admisión
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Informacion.Admision)]
        public async Task Admision(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new AdmisionDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de los convenios
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Informacion.Convenio)]
        public async Task Convenio(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new ConvenioDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de los servicios
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Informacion.Servicio)]
        public async Task Servicio(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new ServicioDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de la acreditación
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Acreditacion.Acreditaciones)]
        public async Task Acreditaciones(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new AcreditacionDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de los objetivos educacionales
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Acreditacion.Objetivo)]
        public async Task Objetivo(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new ObjetivoDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de los resultados del estudiante
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Acreditacion.Resultado)]
        public async Task Resultado(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new ResultadoDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de noticias
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Publicacion.Noticia)]
        public async Task Noticia(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new NoticiaDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de actualidades
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Publicacion.Actualidad)]
        public async Task Actualidad(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new ActualidadDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de comunicados
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Publicacion.Comunicado)]
        public async Task Comunicado(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new ComunicadoDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de eventos
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Publicacion.Evento)]
        public async Task Evento(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new EventoDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de las galerías
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Publicacion.Galeria)]
        public async Task Galeria(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new GaleriaDialog(response)));
        }

        /// <summary>
        /// comienza el dialogo cuando el usuario solicita información de las publicaciones
        /// </summary>
        /// <param name="context">contexto de la conversación</param>
        /// <param name="response">respuesta del servicio</param>
        /// <returns>ejecución del diálogo</returns>
        [AiIntent(Publicacion.Publicaciones)]
        public async Task Publicaciones(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new PublicacionDialog(response)));
        }







        [AiIntent(Documento.Formato)]
        public async Task Formato(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new FormatoDialog(response)));
        }

        [AiIntent(Documento.Reglamento)]
        public async Task Reglamento(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new ReglamentoDialog(response)));
        }

        [AiIntent(Documento.Boletin)]
        public async Task Boletin(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new BoletinDialog(response)));
        }

        [AiIntent(Documento.Requisito)]
        public async Task Requisito(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new RequisitoDialog(response)));
        }



        // intenciones para mostrar información del plan de estudios

        [AiIntent("planestudio.mallacurricular")]
        public async Task MallaCurricular(IDialogContext context, AIResponse response) => await Empezar(() => Dialogo(context, response, new MallaCurricularDialog(response.Result.Fulfillment.Speech)));



        [AiIntent("encuesta.calificacion")]
        public async Task Calificacion(IDialogContext context, AIResponse response)
        {
            await Empezar(() => Dialogo(context, response, new CalificacionDialog(response)));
        }
    }
}