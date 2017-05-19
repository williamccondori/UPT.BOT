using System;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class EventoDto : BaseDto
    {
        public long CodigoEvento { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }
        public DateTime FechaEvento { get; set; }
        public string DescripcionLugar { get; set; }
        public string DescripcionMapa { get; set; }
        public string IndicadorConcluido { get; set; }
    }
}
