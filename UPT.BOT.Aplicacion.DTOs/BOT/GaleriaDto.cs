using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class GaleriaDto : BaseDto
    {
        public long CodigoGaleria { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }
    }
}
