using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Documento;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion.Documento;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Gestion.Documento
{
    [RoutePrefix("api/v1/administracion/formato")]
    public class FormatoController : BaseApiController
    {
        private readonly IFormatoService servicio;

        public FormatoController()
        {
            servicio = new FormatoService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<FormatoDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<FormatoDto>>(servicio.Obtener());
            });
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(FormatoDto formato)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicio.Guardar(formato));
            });
        }

        [HttpDelete, Route(Predeterminado)]
        public RespuestaDto<bool> Eliminar(object id)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicio.Eliminar(id));
            });
        }
    }
}