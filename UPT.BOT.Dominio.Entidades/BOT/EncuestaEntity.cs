using System;
using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class EncuestaEntity : BaseEntity
    {
        public long CodigoEncuesta { get; set; }
        public string DescripcionEncuesta { get; set; }
        public string IndicadorHabilitado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public ICollection<PreguntaEntity> Preguntas { get; set; }

        public EncuestaEntity()
        {

        }
    }
}
