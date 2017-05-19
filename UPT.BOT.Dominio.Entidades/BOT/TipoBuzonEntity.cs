using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class TipoBuzonEntity : BaseEntity
    {
        public string CodigoTipoBuzon { get; set; }
        public string DescripcionTipoBuzon { get; set; }

        public TipoBuzonEntity()
        {

        }
    }
}
