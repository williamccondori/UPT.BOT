using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class DireccionEntity : BaseEntity
    {
        public long CodigoDireccion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionDireccion { get; set; }
        public string DescripcionUrl { get; set; }
        public string DescripcionMapa { get; set; }

        public DireccionEntity()
        {

        }
    }
}
