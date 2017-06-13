using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class PreguntaDto : BaseDto
    {
        public long CodigoPregunta { get; set; }
        public long CodigoEncuesta { get; set; }
        public string DescripcionPregunta { get; set; }
        public string IndicadorHabilitado { get; set; }

        public List<AlternativaDto> Alternativas { get; set; }
    }
}
