using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Encuesta;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Encuesta
{
    public class EncuestaService : BaseService, IEncuestaService
    {
        private readonly IEncuestaRepository repositorioEncuesta;

        public EncuestaService()
        {
            repositorioEncuesta = new EncuestaRepository(contexto);
        }

        public IList<EncuestaDto> Obtener()
        {
            List<EncuestaEntity> listaEvento = repositorioEncuesta.Leer().Take(5).ToList();

            return listaEvento.Select(p => new EncuestaDto
            {
                CodigoEncuesta = p.CodigoEncuesta,
                DescripcionEncuesta = p.DescripcionEncuesta,
                FechaFin = p.FechaFin,
                FechaInicio = p.FechaInicio,
                IndicadorHabilitado = p.IndicadorHabilitado
            }).ToList();
        }

        public EncuestaDto ObtenerXCodigo(long codigoEncuesta)
        {
            EncuestaEntity encuesta = repositorioEncuesta.Buscar(codigoEncuesta);

            if (encuesta == null)
                throw new Exception("No se encontró un registro de código: " + codigoEncuesta);

            EncuestaDto encuestaDto = new EncuestaDto
            {
                CodigoEncuesta = encuesta.CodigoEncuesta,
                DescripcionEncuesta = encuesta.DescripcionEncuesta,
                Preguntas = encuesta.Preguntas.Select(p => new PreguntaDto
                {
                    CodigoEncuesta = p.CodigoEncuesta,
                    CodigoPregunta = p.CodigoPregunta,
                    DescripcionPregunta = p.DescripcionPregunta,
                    Alternativas = p.AlternativaS.Select(g => new AlternativaDto
                    {
                        CodigoAlternativa = g.CodigoAlternativa,
                        DescripcionAlternativa = g.DescripcionAlternativa,
                        CodigoPregunta = g.CodigoPregunta
                    }).ToList()
                }).ToList()
            };

            return encuestaDto;
        }
    }
}
