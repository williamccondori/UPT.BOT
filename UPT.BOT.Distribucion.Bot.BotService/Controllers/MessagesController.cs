using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Distribucion.Bot.Acceso.Seguridad;
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
                //Typing
                ConnectorClient loConector = new ConnectorClient(new Uri(aoActividad.ServiceUrl));
                Activity loActividadEscribiendo = aoActividad.CreateReply();
                loActividadEscribiendo.Type = ActivityTypes.Typing;
                await loConector.Conversations.ReplyToActivityAsync(loActividadEscribiendo);

                ActividadDto loAccion = new ActividadDto
                {
                    EstadoObjeto = EstadoObjeto.Nuevo,
                    DescripcionAccion = aoActividad.Action,
                    DescripcionIdCanal = aoActividad.ChannelId,
                    DescripcionLocalidad = aoActividad.Locale,
                    DescripcionIdActividadRespuesta = aoActividad.ReplyToId,
                    DescripcionUrlServicio = aoActividad.ServiceUrl,
                    DescripcionContenido = aoActividad.Text,
                    DescripcionTipoContenido = aoActividad.TextFormat,
                    FechaMensaje = aoActividad.Timestamp,
                    DescripcionIdActividad = aoActividad.Id,
                    Emisor = new ActividadCuentaDto
                    {
                        CodigoActividadCuenta = 0,
                        DescripcionId = aoActividad.From.Id,
                        DescripcionNombre = aoActividad.From.Name,
                        IndicadorTipo = ActividadCuentaDto.Emisor
                    },
                    Receptor = new ActividadCuentaDto
                    {
                        CodigoActividadCuenta = 0,
                        DescripcionId = aoActividad.Recipient.Id,
                        DescripcionNombre = aoActividad.Recipient.Name,
                        IndicadorTipo = ActividadCuentaDto.Receptor
                    }
                };

                ActividadProxy loActividadProxy = new ActividadProxy(
                    VariableConfiguracion.RutaApi(),
                    VariableConfiguracion.VersionApi(),
                    VariableConfiguracion.ServicioApi());

                loActividadProxy.Registrar(loAccion);

                await Conversation.SendAsync(aoActividad, () => new LuisDialog());
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