using System;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

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

        public static RespuestaEntity Crear(long codigoAlternativa, string codigoCliente, string usuario)
        {
            return new RespuestaEntity
            {
                CodigoAlternativa = codigoAlternativa,
                CodigoCliente = codigoCliente,
                FechaRespuesta = DateTime.Now,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = usuario
            };
        }
    }
}
