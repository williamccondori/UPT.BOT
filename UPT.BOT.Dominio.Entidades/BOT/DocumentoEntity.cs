using System;
using System.Text;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class DocumentoEntity : BaseEntity
    {
        public long CodigoDocumento { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionFormato { get; set; }
        public string DescripcionUrl { get; set; }
        public byte[] DescripcionContenido { get; set; }

        public DocumentoEntity()
        {

        }

        public static DocumentoEntity Crear(string codigoTipoDocumento, string descripcionTitulo, string descripcionResena
            , string descripcionFormato, string descripcionUrl, string usuario, byte[] descripcionContenido)
        {
            return new DocumentoEntity
            {
                CodigoTipoDocumento = codigoTipoDocumento,
                DescripcionTitulo = descripcionTitulo,
                DescripcionResena = descripcionResena,
                DescripcionFormato = descripcionFormato,
                DescripcionUrl = descripcionUrl,
                DescripcionContenido = descripcionContenido,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = usuario
            };
        }

        public void Modificar(string descripcionTitulo, string descripcionResena, string descripcionFormato
            , string descripcionUrl, string usuario, string indicadorEstado, byte[] descripcionContenido)
        {
            DescripcionTitulo = descripcionTitulo;
            DescripcionResena = descripcionResena;
            DescripcionFormato = descripcionFormato;
            DescripcionUrl = descripcionUrl;
            DescripcionContenido = descripcionContenido;
            EstadoObjeto = EstadoObjeto.Modificado;
            FechaModifico = DateTime.Now;
            IndicadorEstado = indicadorEstado;
            UsuarioModifico = usuario;
        }

        public static string Validar(string descripcionTitulo, string descripcionResena
            , string descripcionFormato, string descripcionUrl)
        {
            StringBuilder mensaje = new StringBuilder();

            if (string.IsNullOrEmpty(descripcionTitulo))
                mensaje.AppendLine("El campo título es inválido.");

            if (string.IsNullOrEmpty(descripcionResena))
                mensaje.AppendLine("El campo reseña es inválido.");

            if (string.IsNullOrEmpty(descripcionFormato))
                mensaje.AppendLine("El campo formato es inválido.");

            if (string.IsNullOrEmpty(descripcionUrl))
                mensaje.AppendLine("El campo url es inválido.");

            return mensaje.Length > 0 ? mensaje.ToString() : string.Empty;
        }
    }
}

