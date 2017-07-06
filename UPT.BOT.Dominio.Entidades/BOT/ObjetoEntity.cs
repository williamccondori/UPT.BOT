using System;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class ObjetoEntity : BaseEntity
    {
        public int CodigoObjeto { get; set; }
        public string DescripcionObjeto { get; set; }
        public string DescripcionControlador { get; set; }
        public string DescripcionAccion { get; set; }
        public string IndicadorHabilitado { get; set; }

        public static ObjetoEntity Crear(string descripcionControlador,
            string descripcionAccion, string indicadorHabilitado, string usuario)
        {
            return new ObjetoEntity
            {
                DescripcionObjeto = descripcionControlador + "/" + descripcionAccion,
                DescripcionControlador = descripcionControlador,
                DescripcionAccion = descripcionAccion,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                IndicadorHabilitado = indicadorHabilitado,
                UsuarioRegistro = usuario
            };
        }

        public void Modificar(string descripcionControlador,
            string descripcionAccion, string indicadorHabilitado, string usuario)
        {
            DescripcionObjeto = descripcionControlador + "/" + descripcionAccion;
            DescripcionControlador = descripcionControlador;
            DescripcionAccion = descripcionAccion;
            IndicadorHabilitado = indicadorHabilitado;
            UsuarioModifico = usuario;
            FechaModifico = DateTime.Now;
            EstadoObjeto = EstadoObjeto.Modificado;
        }
    }
}
