using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class UsuarioEntity : BaseEntity
    {
        public int CodigoUsuario { get; set; }
        public string DescripcionNombre { get; set; }
        public string DescripcionApellido { get; set; }
        public string DescripcionEmail { get; set; }
        public string DescripcionUsuario { get; set; }
        public string DescripcionPassword { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public string IndicadorHabilitado { get; set; }

        public UsuarioEntity()
        {

        }
    }
}
