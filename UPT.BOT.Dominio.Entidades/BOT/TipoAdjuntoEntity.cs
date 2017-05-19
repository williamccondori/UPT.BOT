using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class TipoAdjuntoEntity : BaseEntity
    {
        public string CodigoTipoAdjunto { get; set; }
        public string DescripcionTipoAdjunto { get; set; }

        public TipoAdjuntoEntity()
        {

        }
    }
}
