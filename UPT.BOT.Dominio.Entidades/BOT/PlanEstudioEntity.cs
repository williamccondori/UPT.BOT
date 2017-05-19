using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class PlanEstudioEntity : BaseEntity
    {
        public long CodigoPlanEstudio { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }
        public string DescripcionAnio { get; set; }
    }
}
