using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class DocumentoDto : BaseDto
    {
        public long CodigoDocumento { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionFormato { get; set; }
        public string DescripcionUrl { get; set; }
        public byte[] DescripcionContenido { get; set; }
    }
}
