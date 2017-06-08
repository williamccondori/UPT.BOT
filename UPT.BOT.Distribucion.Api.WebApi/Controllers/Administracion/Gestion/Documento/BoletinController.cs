using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Documento;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion.Documento;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Gestion.Documento
{
    [RoutePrefix("api/v1/administracion/boletin")]
    public class BoletinController : BaseApiController
    {
        private readonly IBoletinService servicio;

        public BoletinController()
        {
            servicio = new BoletinService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<BoletinDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<BoletinDto>>(servicio.Obtener());
            });
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(BoletinDto boletin)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicio.Guardar(boletin));
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