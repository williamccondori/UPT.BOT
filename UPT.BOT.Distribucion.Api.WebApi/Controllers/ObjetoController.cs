﻿using System.Web.Http;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT;

namespace UPT.BOT.Distribucion.Api.WebApi.Controllers
{
    [RoutePrefix("api/objeto")]
    public class ObjetoController : BaseApiController
    {
        private readonly IObjetoService _servicioObjeto;

        public ObjetoController()
        {
            _servicioObjeto = new ObjetoService();
        }

        [HttpPost, Route(Predeterminado)]
        public Response<bool> Guardar(ObjetoDto Objeto)
        {
            return Ejecutar(() =>
            {
                return new Response<bool>(_servicioObjeto.Guardar(Objeto));
            });
        }

    }
}
