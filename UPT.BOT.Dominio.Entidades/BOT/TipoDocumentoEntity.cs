using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class TipoDocumentoEntity : BaseEntity
    {
        public string CodigoTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }

        public TipoDocumentoEntity()
        {

        }

        public const string Boletin = "B";
        public const string Formato = "F";
        public const string Reglamento = "R";
        public const string Requisito = "Q";
    }
}
