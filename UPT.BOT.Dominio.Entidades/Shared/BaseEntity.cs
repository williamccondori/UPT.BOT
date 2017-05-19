using System;

namespace UPT.BOT.Dominio.Entidades.Shared
{
    public class BaseEntity : IBaseEntity
    {
        public string IndicadorEstado { get; set; }
        public string UsuarioRegistro { get; set; }
        public string UsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public EstadoObjeto EstadoObjeto { get; set; }
    }
}
