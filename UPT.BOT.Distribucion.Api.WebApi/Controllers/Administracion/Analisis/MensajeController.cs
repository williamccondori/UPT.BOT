using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Analisis;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Analisis;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers.Administracion.Analisis
{
    [RoutePrefix("api/v1/administracion/mensaje")]
    public class MensajeController : BaseApiController
    {
        private readonly IMensajeService servicio;

        public MensajeController()
        {
            servicio = new MensajeService();
        }

        [HttpGet, Route("numero/mes")]
        public RespuestaDto<IList<GraficoDto>> ObtenerNumeroTotalMes()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<GraficoDto>>(servicio.ObtenerNumeroTotalMes());
            });
        }


        [HttpGet, Route("intenciones/numero")]
        public RespuestaDto<IList<GraficoDto>> ObtenerIntenciones()
        {
            return Ejecutar(() =>
            {
                return new RespuestaDto<IList<GraficoDto>>(servicio.ObtenerIntenciones());
            });
        }
    }
}