using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion
{
    public class TipoPublicacionDto : BaseDto
    {

        public int CodigoTipoPublicacion { get; set; }
        public string DescripcionTipoPublicacion { get; set; }
    }

    public class TipoPublicacionConsultaDto : TipoPublicacionDto
    {
    }

    public class TipoPublicacionRegistroDto : TipoPublicacionDto
    {
        public string CodigoUsuario { get; set; }
    }
}
