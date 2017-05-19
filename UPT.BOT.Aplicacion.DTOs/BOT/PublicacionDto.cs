using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class PublicacionDto : BaseDto
    {
        public long CodigoPublicacion { get; set; }
        public string CodigoTipoPublicacion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResumen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }
    }
}
