using System;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class AlertaEntity : BaseEntity
    {
        public long CodigoAlerta { get; set; }
        public string DescripcionAlerta { get; set; }
        public string DescripcionMensaje { get; set; }
        public string DescripcionImagen { get; set; }
        public DateTime FechaAlerta { get; set; }

        public AlertaEntity()
        {

        }
    }
}
