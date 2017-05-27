using System;
using System.ComponentModel.DataAnnotations.Schema;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class ClienteEntity : IEstadoObjeto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CodigoCliente { get; set; }
        public string DescripcionNombre { get; set; }
        public string DescripcionCanal { get; set; }
        public string DescripcionConversacion { get; set; }
        public string DescripcionMetadata { get; set; }
        public DateTime FechaRegistro { get; set; }
        public EstadoObjeto EstadoObjeto { get; set; }

        public ClienteEntity()
        {

        }

        public static ClienteEntity Crear(
            string codigoCliente
            , string descripcionCanal
            , string descripcionNombre
            , string descripcionConversacion
            , string descripcionConversacionNombre)
        {
            return new ClienteEntity
            {
                CodigoCliente = codigoCliente,
                DescripcionCanal = descripcionCanal,
                DescripcionNombre = descripcionNombre,
                DescripcionConversacion = descripcionConversacion,
                DescripcionMetadata = descripcionConversacionNombre,
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
            };
        }
    }
}
