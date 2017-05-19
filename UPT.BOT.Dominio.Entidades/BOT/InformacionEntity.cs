using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class InformacionEntity : BaseEntity
    {
        public long CodigoInformacion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionMensaje { get; set; }
        public string DescripcionIntencion { get; set; }

        public InformacionEntity()
        {

        }
    }
}
