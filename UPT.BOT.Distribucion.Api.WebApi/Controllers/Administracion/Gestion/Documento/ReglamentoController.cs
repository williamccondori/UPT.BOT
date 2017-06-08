using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Documento;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion.Documento;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Gestion.Documento
{
    [RoutePrefix("api/v1/administracion/reglamento")]
    public class ReglamentoController : BaseApiController
    {
        private readonly IReglamentoService servicio;

        public ReglamentoController()
        {
            servicio = new ReglamentoService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<ReglamentoDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<ReglamentoDto>>(servicio.Obtener());
            });
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(ReglamentoDto Reglamento)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicio.Guardar(Reglamento));
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