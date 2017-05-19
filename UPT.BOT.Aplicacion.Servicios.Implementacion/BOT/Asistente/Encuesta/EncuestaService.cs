using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Encuesta;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Encuesta
{
    public class EncuestaService : IEncuestaService
    {
        private readonly IEncuestaRepository repositorioEncuesta;

        public EncuestaService()
        {
            repositorioEncuesta = new EncuestaRepository(new BotContext());
        }

        public IList<EncuestaDto> Obtener()
        {
            IEnumerable<EncuestaEntity> listaEvento = repositorioEncuesta.Leer().Take(5);

            return listaEvento.Select(p => new EncuestaDto
            {
                CodigoEncuesta = p.CodigoEncuesta,
                DescripcionEncuesta = p.DescripcionEncuesta,
                FechaFin = p.FechaFin,
                FechaInicio = p.FechaInicio,
                IndicadorHabilitado = p.IndicadorHabilitado
            }).ToList();
        }
    }
}
