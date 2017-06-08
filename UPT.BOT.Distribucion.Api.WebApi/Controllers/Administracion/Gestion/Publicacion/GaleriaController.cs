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
    [RoutePrefix("api/v1/administracion/galeria")]
    public class GaleriaController : BaseApiController
    {
        private readonly IGaleriaService servicio;

        public GaleriaController()
        {
            servicio = new GaleriaService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<GaleriaDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<GaleriaDto>>(servicio.Obtener());
            });
        }

        [HttpPost, Route(Predeterminado)]
        public RespuestaDto<bool> Guardar(GaleriaDto galeria)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<bool>(servicio.Guardar(galeria));
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