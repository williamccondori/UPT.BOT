using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión
{
    public class ActualidadDto : BaseDto
    {
        public int CodigoTipoPublicacion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionResumen { get; set; }
        public string DescripcionContenido { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionUrl { get; set; }
    }

    public class ActualidadConsultaDto
    {
        public int CodigoPublicacion { get; set; }
    }

    public class ActualidadRegistroDto
    {

    }
}
