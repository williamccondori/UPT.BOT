using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    [RoutePrefix("api/buzon")]
    public class BuzonController : BaseApiController
    {
        private readonly IBuzonService _servicioBuzon;
        public BuzonController()
        {
            _servicioBuzon = new BuzonService();
        }

        [HttpPost, Route(Predeterminado)]
        public Response<bool> Guardar(BuzonDto buzon)
        {
            return Ejecutar(() =>
            {
                return new Response<bool>(_servicioBuzon.Guardar(buzon));
            });
        }
    }
}