using System.Collections.Generic;
using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    [RoutePrefix("api/rol")]
    public class RolController : BaseApiController
    {
        private readonly IRolService _servicioRol;

        public RolController()
        {
            _servicioRol = new RolService();
        }

        [HttpGet, Route(Predeterminado)]
        public Response<IList<RolDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                return new Response<IList<RolDto>>(_servicioRol.Obtener());
            });
        }

        [HttpPost, Route(Predeterminado)]
        public Response<bool> Guardar(RolDto rol)
        {
            return Ejecutar(() =>
            {
                return new Response<bool>(_servicioRol.Guardar(rol));
            });
        }

    }
}