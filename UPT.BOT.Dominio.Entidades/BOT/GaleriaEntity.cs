using System;
using System.Collections.Generic;
using System.Text;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class GaleriaEntity : BaseEntity
    {
        public long CodigoGaleria { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionImagen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionUrl { get; set; }
        public List<DetalleGaleriaEntity> DetalleGaleriaS { get; set; }

        public GaleriaEntity()
        {

        }

        public static GaleriaEntity Crear(string descripcionTitulo, string descripcionImagen,
            string descripcionResena, string descripcionUrl, List<DetalleGaleriaEntity> detalles, string usuario)
        {
            return new GaleriaEntity
            {
                DescripcionTitulo = descripcionTitulo,
                DescripcionImagen = descripcionImagen,
                DescripcionResena = descripcionResena,
                DescripcionUrl = descripcionUrl,
                DetalleGaleriaS = detalles,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = usuario
            };
        }

        public static string Validar(string descripcionImagen)
        {
            StringBuilder mensaje = new StringBuilder();
            
            if (string.IsNullOrEmpty(descripcionImagen))
                mensaje.AppendLine("El campo imágen es inválido.");

            return mensaje.Length > 0 ? mensaje.ToString() : string.Empty;
        }

        public void Modificar(string descripcionTitulo, string descripcionImagen, string descripcionResena
            , string descripcionUrl,string indicadorEstado, string usuario)
        {
            DescripcionTitulo = descripcionTitulo;
            DescripcionImagen = descripcionImagen;
            DescripcionResena = descripcionResena;
            DescripcionUrl = descripcionUrl;
            EstadoObjeto = EstadoObjeto.Modificado;
            FechaModifico = DateTime.Now;
            IndicadorEstado = indicadorEstado;
            UsuarioModifico = usuario;
        }
    }
}
