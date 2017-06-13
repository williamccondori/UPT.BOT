using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class TelefonoDto : BaseDto
    {
        public long CodigoTelefono { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionTelefono { get; set; }
        public string DescripcionUrl { get; set; }
    }
}
