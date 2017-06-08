using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion.Publicacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Gestion.Publicacion
{
    [RoutePrefix("api/v1/administracion/actualidad")]
    public class ActualidadController : BaseApiController
    {
        private readonly IActualidadService servicio;

        public ActualidadController()
        {
            servicio = new ActualidadService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<ActualidadDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<ActualidadDto>>(servicio.Obtener());
            });
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(ActualidadDto actualidad)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicio.Guardar(actualidad));
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