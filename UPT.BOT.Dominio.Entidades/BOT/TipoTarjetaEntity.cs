using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class TipoTarjetaEntity : BaseEntity
    {
        public string CodigoTipoTarjeta { get; set; }
        public string DescripcionTipoTarjeta { get; set; }
    }
}
