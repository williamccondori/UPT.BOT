using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class TipoPublicacionEntity : BaseEntity
    {
        public string CodigoTipoPublicacion { get; set; }
        public string DescripcionTipoPublicacion { get; set; }

        public TipoPublicacionEntity()
        {

        }

        public const string Actualidad = "A";
        public const string Noticia = "N";
        public const string Comunicado = "C";
        public const string Publicacion = "P";
    }
}
