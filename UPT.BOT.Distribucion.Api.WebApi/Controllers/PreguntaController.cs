using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    [RoutePrefix("api/pregunta")]
    public class PreguntaController : BaseApiController
    {
        private readonly IPreguntaService _servicioPregunta;

        public PreguntaController()
        {
            _servicioPregunta = new PreguntaService();
        }

        [HttpPost, Route(Predeterminado)]
        public Response<bool> Guardar(PreguntaDto pregunta)
        {
            return Ejecutar(() =>
            {
                return new Response<bool>(_servicioPregunta.Guardar(pregunta));
            });
        }

        [HttpGet, Route(Predeterminado)]
        public Response<IList<PreguntaDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new Response<IList<PreguntaDto>>(_servicioPregunta.Obtener());
            });
        }
    }
}
