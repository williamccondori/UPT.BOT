using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class PublicacionEntity : BaseEntity
    {
        public long CodigoPublicacion { get; set; }
        public string CodigoTipoPublicacion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResumen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }

        public PublicacionEntity()
        {

        }
    }
}
