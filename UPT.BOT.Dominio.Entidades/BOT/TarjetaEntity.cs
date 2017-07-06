using System;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class TarjetaEntity : BaseEntity
    {
        public int CodigoTarjeta { get; set; }
        public string CodigoTipoTarjeta { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionSubtitulo { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionUrl { get; set; }
        public string IndicadorHabilitado { get; set; }
        public TipoTarjetaEntity TipoTarjetaX { get; set; }

        public static TarjetaEntity Crear(string codigoTipoTarjeta, string descripcionTitulo
            , string descripcionSubtitulo, string descripcionResena, string descripcionImagen
            , string descripcionUrl, string indicadorHabilitado, string usuario)
        {
            return new TarjetaEntity
            {
                CodigoTipoTarjeta = codigoTipoTarjeta,
                DescripcionImagen = descripcionImagen,
                DescripcionResena = descripcionResena,
                DescripcionSubtitulo = descripcionSubtitulo,
                DescripcionTitulo = descripcionTitulo,
                DescripcionUrl = descripcionUrl,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                IndicadorHabilitado = indicadorHabilitado,
                UsuarioRegistro = usuario
            };
        }

        public void Modificar(string descripcionTitulo
            , string descripcionSubtitulo, string descripcionResena, string descripcionImagen
            , string descripcionUrl, string indicadorHabilitado, string usuario)
        {
            DescripcionImagen = descripcionImagen;
            DescripcionResena = descripcionResena;
            DescripcionSubtitulo = descripcionSubtitulo;
            DescripcionTitulo = descripcionTitulo;
            IndicadorHabilitado = indicadorHabilitado;
            FechaModifico = DateTime.Now;
            UsuarioModifico = usuario;
        }
    }
}
