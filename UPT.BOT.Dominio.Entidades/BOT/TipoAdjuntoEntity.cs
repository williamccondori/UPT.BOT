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

        public const string Nosotros = "N";
        public const string Acreditacion = "A";
        public const string Convenio = "V";
        public const string Servicio = "S";
        public const string MallaCurricular = "M";
        public const string PerfilProfesional = "P";
    }
}
