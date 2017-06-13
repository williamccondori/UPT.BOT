using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Informacion
{
    [RoutePrefix("api/v1/asistente/enlace_importante")]
    public class BotEnlaceImportanteController : BaseApiController
    {
        private readonly IEnlaceImportanteService servicioEnlaceImportante;

        public BotEnlaceImportanteController()
        {
            servicioEnlaceImportante = new EnlaceImportanteService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<EnlaceImportanteDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<EnlaceImportanteDto>>(servicioEnlaceImportante.Obtener());
            });
        }
    }
}