using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class TelefonoEntity : BaseEntity
    {
        public long CodigoTelefono { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionTelefono { get; set; }
        public string DescripcionUrl { get; set; }

        public TelefonoEntity()
        {

        }
    }
}
