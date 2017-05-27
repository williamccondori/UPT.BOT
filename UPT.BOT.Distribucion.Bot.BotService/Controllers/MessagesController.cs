using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Distribucion.Bot.Acceso.Seguridad;
using UPT.BOT.Distribucion.Bot.BotService.Intents.Api;
using UPT.BOT.Distribucion.Bot.BotService.Utilidades;

namespace UPT.CMS.Servicios.Bot.Servicio
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public async Task<HttpResponseMessage> Post([FromBody]Activity actividad)
        {
            try
            {
                if (actividad.Type == ActivityTypes.Message)
                {
                    ConnectorClient conector = new ConnectorClient(new Uri(actividad.ServiceUrl));

                    Activity actividadTyping = actividad.CreateReply();
                    actividadTyping.Type = ActivityTypes.Typing;
                    await conector.Conversations.ReplyToActivityAsync(actividadTyping);

                    actividad.Text = string.IsNullOrEmpty(actividad.Text) ? "0" : actividad.Text;

                    ClienteDto cliente = new ClienteDto
                    {
                        CodigoCliente = actividad.From.Id,
                        DescripcionNombre = actividad.From.Name,
                        DescripcionConversacion = actividad.Conversation.Id,
                        DescripcionMetadata = JsonConvert.SerializeObject(actividad),
                        DescripcionCanal = actividad.ChannelId,
                        EstadoObjeto = EstadoObjeto.Nuevo
                    };

                    ClienteProxy proxyCliente = new ClienteProxy(VariableConfiguracion.RutaApi());

                    proxyCliente.Guardar(cliente);

                    await Conversation.SendAsync(actividad, () => new GestorAi());
                }
                else
                {
                    HandleSystemMessage(actividad);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception excepcion)
            {
                ConnectorClient conector = new ConnectorClient(new Uri(actividad.ServiceUrl));

                Activity nuevaActividad = actividad.CreateReply(excepcion.Message);

                nuevaActividad.Type = ActivityTypes.Message;

                await conector.Conversations.ReplyToActivityAsync(nuevaActividad);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

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