using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class PreguntaEntity : BaseEntity
    {
        public long CodigoPregunta { get; set; }
        public long CodigoEncuesta { get; set; }
        public string DescripcionPregunta { get; set; }
        public string IndicadorHabilitado { get; set; }

        public PreguntaEntity()
        {

        }
    }
}
