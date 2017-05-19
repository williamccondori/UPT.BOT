using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Publicacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Publicacion;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Asistente.Publicacion
{
    [RoutePrefix("api/v1/asistente/galeria")]
    public class BotGaleriaController : BaseApiController
    {
        private readonly IGaleriaService servicioGaleria;

        public BotGaleriaController()
        {
            servicioGaleria = new GaleriaService();
        }

        [HttpGet, Route(Predeterminado)]
        public RespuestaDto<IList<GaleriaDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<GaleriaDto>>(servicioGaleria.Obtener());
            });
        }

        [HttpGet, Route("detalle/{codigoGaleria}")]
        public RespuestaDto<IList<DetalleGaleriaDto>> ObtenerDetalle(long codigoGaleria)
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<DetalleGaleriaDto>>(servicioGaleria.ObtenerDetalle(codigoGaleria));
            });
        }
    }
}