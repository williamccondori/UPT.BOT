using System;
using System.Text;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class EventoEntity : BaseEntity
    {
        public long CodigoEvento { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }
        public DateTime FechaEvento { get; set; }
        public string DescripcionLugar { get; set; }
        public string DescripcionMapa { get; set; }
        public string IndicadorConcluido { get; set; }

        public EventoEntity()
        {

        }

        public static EventoEntity Crear(string descripcionTitulo, string descripcionImagen, string descripcionResena,
            string descripcionUrl, DateTime fechaEvento, string descripcionLugar, string descripcionMapa, string indicadorConcluido, string usuario)
        {
            return new EventoEntity
            {
                DescripcionTitulo = descripcionTitulo,
                DescripcionImagen = descripcionImagen,
                DescripcionResena = descripcionResena,
                DescripcionUrl = descripcionUrl,
                FechaEvento = fechaEvento,
                DescripcionLugar = descripcionLugar,
                DescripcionMapa = descripcionMapa,
                IndicadorConcluido = indicadorConcluido,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = usuario
            };
        }

        public void Modificar(string descripcionTitulo, string descripcionImagen, string descripcionResena,
            string descripcionUrl, DateTime fechaEvento, string descripcionLugar, string descripcionMapa, string indicadorConcluido, string indicadorEstado, string usuario)
        {
            DescripcionTitulo = descripcionTitulo;
            DescripcionImagen = descripcionImagen;
            DescripcionResena = descripcionResena;
            DescripcionUrl = descripcionUrl;
            FechaEvento = fechaEvento;
            DescripcionLugar = descripcionLugar;
            DescripcionMapa = descripcionMapa;
            IndicadorConcluido = indicadorConcluido;
            EstadoObjeto = EstadoObjeto.Modificado;
            FechaModifico = DateTime.Now;
            IndicadorEstado = indicadorEstado;
            UsuarioModifico = usuario;
        }

        public static string Validar(string descripcionTitulo, string descripcionImagen, string descripcionResena,
            string descripcionUrl, DateTime fechaEvento, string descripcionLugar, string descripcionMapa, string indicadorConcluido)
        {
            StringBuilder mensaje = new StringBuilder();

            if (string.IsNullOrEmpty(descripcionTitulo))
                mensaje.AppendLine("El campo título es inválido.");

            if (string.IsNullOrEmpty(descripcionResena))
                mensaje.AppendLine("El campo reseña es inválido.");

            if (string.IsNullOrEmpty(descripcionImagen))
                mensaje.AppendLine("El campo imágen es inválido.");

            if (string.IsNullOrEmpty(descripcionLugar))
                mensaje.AppendLine("El campo lugar es inválido.");

            if (string.IsNullOrEmpty(descripcionUrl))
                mensaje.AppendLine("El campo url es inválido.");

            return mensaje.Length > 0 ? mensaje.ToString() : string.Empty;
        }
    }
}
