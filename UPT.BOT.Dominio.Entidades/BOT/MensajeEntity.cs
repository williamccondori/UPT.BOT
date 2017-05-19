using System;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class MensajeEntity : IEstadoObjeto
    {
        public long CodigoMensaje { get; set; }
        public string CodigoCliente { get; set; }
        public string DescripcionActividad { get; set; }
        public string DescripcionCanal { get; set; }
        public string DescripcionLocalidad { get; set; }
        public string DescripcionServicio { get; set; }
        public string DescripcionContenido { get; set; }
        public string DescripcionTipoContenido { get; set; }
        public string DescripcionIntencion { get; set; }
        public decimal PorIntencion { get; set; }
        public DateTime? FechaMensaje { get; set; }
        public EstadoObjeto EstadoObjeto { get; set; }

        public MensajeEntity()
        {

        }

        public static MensajeEntity Crear(
            string codigoCliente
            , string descripcionActividad
            , string descripcionCanal
            , string descripcionLocalidad
            , string descripcionServicio
            , string descripcionContenido
            , string descripcionTipoContenido
            , string descripcionIntencion
            , decimal porcentajeIntencion
            , DateTime fechaMensaje)
        {
            return new MensajeEntity
            {
                CodigoCliente = codigoCliente,
                DescripcionActividad = descripcionActividad,
                DescripcionCanal = descripcionCanal,
                DescripcionLocalidad = descripcionLocalidad,
                DescripcionServicio = descripcionServicio,
                DescripcionContenido = descripcionContenido,
                DescripcionTipoContenido = descripcionTipoContenido,
                DescripcionIntencion = descripcionIntencion,
                PorIntencion = porcentajeIntencion,
                FechaMensaje = fechaMensaje,
                EstadoObjeto = EstadoObjeto.Nuevo
            };
        }
    }
}
