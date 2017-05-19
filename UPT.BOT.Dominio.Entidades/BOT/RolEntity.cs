using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class RolEntity : BaseEntity
    {
        public string CodigoRol { get; set; }
        public string DescripcionRol { get; set; }

        public RolEntity()
        {

        }
    }
}
