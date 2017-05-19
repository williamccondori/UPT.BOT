using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class AdjuntoEntity : BaseEntity
    {
        public long CodigoAdjunto { get; set; }
        public string CodigoTipoAdjunto { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionSubtitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResumen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }
        //public string TipoAdjunto { get; set; }

        public AdjuntoEntity()
        {

        }
    }
}
