using System;
using System.Text;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class PublicacionEntity : BaseEntity
    {
        public long CodigoPublicacion { get; set; }
        public string CodigoTipoPublicacion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResumen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }

        public PublicacionEntity()
        {

        }

        public static PublicacionEntity Crear(string codigoTipoPublicacion, string descripcionTitulo, string descripcionImagen,
            string descripcionResumen,string  descripcionResena, string descripcionUrl, string usuario)
        {
            return new PublicacionEntity
            {
                CodigoTipoPublicacion = codigoTipoPublicacion,
                DescripcionTitulo = descripcionTitulo,
                DescripcionImagen = descripcionImagen,
                DescripcionResumen = descripcionResumen,
                DescripcionResena = descripcionResena,
                DescripcionUrl = descripcionUrl,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = usuario
            };
        }

        public void Modificar(string descripcionTitulo, string descripcionImagen,
            string descripcionResumen, string descripcionResena, string descripcionUrl, string indicadorEstado, string usuario)
        {
            DescripcionTitulo = descripcionTitulo;
            DescripcionImagen = descripcionImagen;
            DescripcionResumen = descripcionResumen;
            DescripcionResena = descripcionResena;
            DescripcionUrl = descripcionUrl;
            EstadoObjeto = EstadoObjeto.Modificado;
            FechaModifico = DateTime.Now;
            IndicadorEstado = indicadorEstado;
            UsuarioModifico = usuario;
        }

        public static string Validar(string descripcionTitulo, string descripcionResena
            , string descripcionImagen, string descripcionUrl)
        {
            StringBuilder mensaje = new StringBuilder();

            if (string.IsNullOrEmpty(descripcionTitulo))
                mensaje.AppendLine("El campo título es inválido.");

            if (string.IsNullOrEmpty(descripcionResena))
                mensaje.AppendLine("El campo reseña es inválido.");

            if (string.IsNullOrEmpty(descripcionImagen))
                mensaje.AppendLine("El campo imágen es inválido.");

            if (string.IsNullOrEmpty(descripcionUrl))
                mensaje.AppendLine("El campo url es inválido.");

            return mensaje.Length > 0 ? mensaje.ToString() : string.Empty;
        }
    }
}
