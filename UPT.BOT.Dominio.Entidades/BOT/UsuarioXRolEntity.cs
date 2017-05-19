using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class UsuarioXRolEntity : BaseEntity
    {
        public int CodigoUsuarioXRol { get; set; }
        public int CodigoUsuario { get; set; }
        public string CodigoRol { get; set; }

        public UsuarioXRolEntity()
        {

        }
    }
}
