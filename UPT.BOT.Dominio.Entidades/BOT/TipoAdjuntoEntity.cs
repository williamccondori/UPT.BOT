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
        public const string Acreditacion = "T";
        public const string Convenio = "V";
        public const string Servicio = "S";

        public const string Actualidad = "A";
        public const string Publicacion = "P";
        public const string Comunicado = "C";

        public const string PerfilProfesional = "L";

        public const string Formato = "F";
        public const string Reglamento = "R";
        public const string Boletin = "B";
        public const string Requisito = "Q";
    }
}
