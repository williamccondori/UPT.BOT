using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class AdmisionEntity : BaseEntity
    {
        public long CodigoAdmision { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }
        public string IndicadorConcluido { get; set; }

        public AdmisionEntity()
        {

        }
    }
}
