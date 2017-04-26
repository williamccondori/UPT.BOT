using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Distribucion.Bot.Acceso.Seguridad;
using UPT.BOT.Distribucion.Bot.BotService.Ai.Api;
using UPT.BOT.Distribucion.Bot.BotService.Dialogos;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.CMS.Servicios.Bot.Servicio
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public async Task<HttpResponseMessage> Post([FromBody]Activity aoActividad)
        {

            if (aoActividad.Type == ActivityTypes.Message)
            {
                ConnectorClient loConector = new ConnectorClient(new Uri(aoActividad.ServiceUrl));

                Activity loActividadEscribiendo = aoActividad.CreateReply();
                loActividadEscribiendo.Type = ActivityTypes.Typing;

                await loConector.Conversations.ReplyToActivityAsync(loActividadEscribiendo);

                ClienteDto loClienteDto = new ClienteDto
                {
                    CodigoCliente = aoActividad.From.Id,
                    DescripcionNombre = aoActividad.From.Name,
                    DescripcionConversacion = aoActividad.Conversation.Id,
                    DescripcionConversacionNombre = aoActividad.Conversation.Name,
                    DescripcionCanal = aoActividad.ChannelId,
                    EstadoObjeto = EstadoObjeto.Nuevo
                };

                ClienteProxy loClienteProxy = new ClienteProxy(
                    VariableConfiguracion.RutaApi(),
                    VariableConfiguracion.VersionApi(),
                    VariableConfiguracion.ServicioApi());

                loClienteProxy.Guardar(loClienteDto);

                StateClient loStateClient = aoActividad.GetStateClient();

                BotData loUserData = await loStateClient.BotState.GetUserDataAsync(aoActividad.ChannelId, aoActividad.From.Id);

                loUserData.SetProperty("Mensaje", new MensajeDto
                {
                    CodigoCliente = aoActividad.From.Id,
                    DescripcionActividad = aoActividad.Id,
                    DescripcionCanal = aoActividad.ChannelId,
                    DescripcionContenido = aoActividad.Text,
                    DescripcionIntencion = null,
                    DescripcionLocalidad = aoActividad.Locale,
                    DescripcionServicio = aoActividad.ServiceUrl,
                    DescripcionTipoContenido = aoActividad.TextFormat,
                    EstadoObjeto = EstadoObjeto.Nuevo,
                    FechaMensaje = aoActividad.Timestamp,
                    PorcentajeIntencion = 0
                });

                await loStateClient.BotState.SetUserDataAsync(aoActividad.ChannelId, aoActividad.From.Id, loUserData);

                await Conversation.SendAsync(aoActividad, () => new GestorApiAi());
            }
            else
            {
                HandleSystemMessage(aoActividad);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //Acciones para otro tipo de eventos.

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}