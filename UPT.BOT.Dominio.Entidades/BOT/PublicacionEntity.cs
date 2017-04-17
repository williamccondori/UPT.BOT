using System;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class PublicacionEntity : BaseEntity
    {
        public int CodigoPublicacion { get; set; }
        public int CodigoTipoPublicacion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionResumen { get; set; }
        public string DescripcionContenido { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionUrl { get; set; }

        public PublicacionEntity()
        {

        }

        public static PublicacionEntity Agregar(
            int aiCodigoTipoPublicacion,
            string asDescripcionTitulo,
            string asDescripcionResumen,
            string asDescripcionContenido,
            string asDescripcionImagen,
            string asDescripcionUrl,
            string asUsuario)
        {
            return new PublicacionEntity
            {
                CodigoTipoPublicacion = aiCodigoTipoPublicacion,
                DescripcionContenido = asDescripcionContenido,
                DescripcionImagen = asDescripcionImagen,
                DescripcionResumen = asDescripcionResumen,
                DescripcionTitulo = asDescripcionTitulo,
                DescripcionUrl = asDescripcionUrl,
                EstadoObjeto = EstadoObjeto.Nuevo,
                IndicadorEstado = EstadoEntidad.Activo,
                FechaRegistro = DateTime.Now,
                UsuarioRegistro = asUsuario
            };
        }

        public void Modificar(
            string asDescripcionTitulo,
            string asDescripcionResumen,
            string asDescripcionContenido,
            string asDescripcionImagen,
            string asDescripcionUrl,
            string asUsuario)
        {
            DescripcionContenido = asDescripcionContenido;
            DescripcionImagen = asDescripcionImagen;
            DescripcionResumen = asDescripcionResumen;
            DescripcionTitulo = asDescripcionTitulo;
            DescripcionUrl = asDescripcionUrl;
            EstadoObjeto = EstadoObjeto.Modificado;
            FechaModifico = DateTime.Now;
            UsuarioModifico = asUsuario;
        }
    }
}
