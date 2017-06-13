using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Informacion
{
    [RoutePrefix("api/v1/asistente/telefono")]
    public class BotTelefonoController : BaseApiController
    {
        private readonly ITelefonoService servicioTelefono;

        public BotTelefonoController()
        {
            servicioTelefono = new TelefonoService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<TelefonoDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<TelefonoDto>>(servicioTelefono.Obtener());
            });
        }
    }
}