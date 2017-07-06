using System;
using UPT.BOT.Aplicacion.DTOs.Shared;

namespace UPT.BOT.Aplicacion.DTOs.BOT
{
    public class RespuestaDto : BaseDto
    {
        public long CodigoRespuesta { get; set; }
        public long CodigoAlternativa { get; set; }
        public string CodigoCliente { get; set; }
        public DateTime FechaRespuesta { get; set; }
    }
}
