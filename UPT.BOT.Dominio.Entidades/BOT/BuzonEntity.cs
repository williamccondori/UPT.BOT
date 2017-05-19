using System;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class BuzonEntity : BaseEntity
    {
        public long CodigoBuzon { get; set; }
        public string CodigoTipoBuzon { get; set; }
        public string CodigoCliente { get; set; }
        public string DescripcionMensaje { get; set; }
        public string IndicadorLeido { get; set; }
        public string IndicadorGuardado { get; set; }
        public string IndicadorHistorial { get; set; }

        public BuzonEntity()
        {

        }

        public static BuzonEntity Crear(
            string codigoTipoBuzon
            , string codigoCliente
            , string descripcionMensaje)
        {
            return new BuzonEntity
            {
                CodigoCliente = codigoCliente,
                CodigoTipoBuzon = codigoTipoBuzon,
                DescripcionMensaje = descripcionMensaje,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                IndicadorGuardado = Indicador.No,
                IndicadorHistorial = Indicador.No,
                IndicadorLeido = Indicador.No,
                UsuarioRegistro = string.Empty
            };
        }
    }
}
