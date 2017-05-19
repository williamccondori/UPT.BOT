using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class DocumentoEntity : BaseEntity
    {
        public long CodigoDocumento { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionFormato { get; set; }
        public string DescripcionUrl { get; set; }
        public byte[] DescripcionContenido { get; set; }

        public DocumentoEntity()
        {

        }
    }
}
