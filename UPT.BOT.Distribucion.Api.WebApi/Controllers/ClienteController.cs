using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : BaseApiController
    {
        private readonly IClienteService _servicioCliente;
        public ClienteController()
        {
            _servicioCliente = new ClienteService();
        }

        [HttpPost, Route(Predeterminado)]
        public Response<bool> Guardar(ClienteDto cliente)
        {
            return Ejecutar(() =>
            {
                return new Response<bool>(_servicioCliente.Guardar(cliente));
            });
        }
    }
}