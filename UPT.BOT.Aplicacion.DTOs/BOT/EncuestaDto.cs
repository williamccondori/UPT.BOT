using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class EncuestaDto : BaseDto
    {
        public long CodigoEncuesta { get; set; }
        public string DescripcionEncuesta { get; set; }
        public string IndicadorHabilitado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<PreguntaDto> Preguntas { get; set; }
    }
}
