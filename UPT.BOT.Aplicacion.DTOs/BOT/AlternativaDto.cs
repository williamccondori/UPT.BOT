using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class AlternativaDto : BaseDto
    {
        public long CodigoAlternativa { get; set; }
        public long CodigoPregunta { get; set; }
        public string DescripcionAlternativa { get; set; }
        public string IndicadorHabilitado { get; set; }
    }
}
