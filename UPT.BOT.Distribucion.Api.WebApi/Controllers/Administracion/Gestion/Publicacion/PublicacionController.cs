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
    [RoutePrefix("api/v1/administracion/publicacion")]
    public class PublicacionController : BaseApiController
    {
        private readonly IPublicacionService servicio;

        public PublicacionController()
        {
            servicio = new PublicacionService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<PublicacionDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<PublicacionDto>>(servicio.Obtener());
            });
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(PublicacionDto publicacion)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicio.Guardar(publicacion));
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