using System;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class EventoEntity : BaseEntity
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

        public EventoEntity()
        {

        }
    }
}
