using System;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Gestión
{
    public class NoticiaDto : BaseDto
    {
        public long CodigoPublicacion { get; set; }
        public int CodigoTipoPublicacion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionResumen { get; set; }
        public string DescripcionContenido { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionUrl { get; set; }
    }

    public class NoticiaConsultaDto : NoticiaDto
    {
        public DateTime FechaRegistro { get; set; }
        public TipoPublicacionDto TipoPublicacion { get; set; }
    }

    public class NoticiaRegistroDto : NoticiaDto
    {
        public DateTime FechaRegistro { get; set; }
        public string CodigoUsuario { get; set; }
    }

    public class NoticiaConsultaBotDto : NoticiaDto
    {

    }
}
