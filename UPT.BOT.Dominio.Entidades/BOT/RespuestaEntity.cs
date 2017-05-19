using System;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class RespuestaEntity : BaseEntity
    {
        public long CodigoRespuesta { get; set; }
        public long CodigoAlternativa { get; set; }
        public string CodigoCliente { get; set; }
        public DateTime FechaRespuesta { get; set; }

        public RespuestaEntity()
        {

        }
    }
}
