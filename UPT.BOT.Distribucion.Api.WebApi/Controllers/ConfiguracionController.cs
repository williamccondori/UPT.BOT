using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    [RoutePrefix("api/configuracion")]
    public class ConfiguracionController : BaseApiController
    {
        private readonly IConfiguracionService _servicioConfiguracion;
        public ConfiguracionController()
        {
            _servicioConfiguracion = new ConfiguracionService();
        }

        [HttpPost, Route(Predeterminado)]
        public Response<bool> Guardar(ConfiguracionDto configuracion)
        {
            return Ejecutar(() =>
            {
                return new Response<bool>(_servicioConfiguracion.Guardar(configuracion));
            });
        }
    }
}