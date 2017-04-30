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
        public decimal PorcentajeIntencion { get; set; }
        public DateTime? FechaMensaje { get; set; }
        public EstadoObjeto EstadoObjeto { get; set; }

        public static MensajeEntity Crear(
            string asCodigoCliente,
            string asDescripcionActividad,
            string asDescripcionCanal,
            string asDescripcionLocalidad,
            string asDescripcionServicio,
            string asDescripcionContenido,
            string asDescripcionTipoContenido,
            string asDescripcionIntencion,
            decimal adcPorcentajeIntencion,
            DateTime? adtFechaMensaje)
        {
            return new MensajeEntity
            {
                CodigoCliente = asCodigoCliente,
                DescripcionActividad = asDescripcionActividad,
                DescripcionCanal = asDescripcionCanal,
                DescripcionLocalidad = asDescripcionLocalidad,
                DescripcionServicio = asDescripcionServicio,
                DescripcionContenido = asDescripcionContenido,
                DescripcionTipoContenido = asDescripcionTipoContenido,
                DescripcionIntencion = asDescripcionIntencion,
                PorcentajeIntencion = adcPorcentajeIntencion,
                FechaMensaje = adtFechaMensaje,
                EstadoObjeto = EstadoObjeto.Nuevo
            };
        }
    }
}
