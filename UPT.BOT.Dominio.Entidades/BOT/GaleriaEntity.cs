using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class GaleriaEntity : BaseEntity
    {
        public long CodigoGaleria { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }

        public GaleriaEntity()
        {

        }
    }
}
