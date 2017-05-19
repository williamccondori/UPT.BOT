using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class AlternativaEntity : BaseEntity
    {
        public long CodigoAlternativa { get; set; }
        public long CodigoPregunta { get; set; }
        public string DescripcionAlternativa { get; set; }
        public string IndicadorHabilitado { get; set; }

        public AlternativaEntity()
        {

        }
    }
}
