using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Documento;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion.Documento;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Gestion.Documento
{
    [RoutePrefix("api/v1/administracion/requisito")]
    public class RequisitoController : BaseApiController
    {
        private readonly IRequisitoService servicio;

        public RequisitoController()
        {
            servicio = new RequisitoService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<RequisitoDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<RequisitoDto>>(servicio.Obtener());
            });
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(RequisitoDto Requisito)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicio.Guardar(Requisito));
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