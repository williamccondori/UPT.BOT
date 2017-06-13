using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class DireccionDto : BaseDto
    {
        public long CodigoDireccion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionDireccion { get; set; }
        public string DescripcionUrl { get; set; }
        public string DescripcionMapa { get; set; }
    }
}
