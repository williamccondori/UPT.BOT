using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Dominio.Entidades.BOT
{
    public class ClienteEntity
    {
        public string CodigoCliente { get; set; }
        public string DescripcionCanal { get; set; }
        public string DescripcionConversacion { get; set; }
        public string DescripcionConversacionNombre { get; set; }
        public string DescripcionNombre { get; set; }
        public EstadoObjeto EstadoObjeto { get; set; }

        public static ClienteEntity Crear(
            string asCodigoCliente,
            string asDescripcionCanal,
            string asDescripcionNombre,
            string asDescripcionConversacion,
            string asDescripcionConversacionNombre)
        {
            return new ClienteEntity
            {
                DescripcionConversacion = asDescripcionConversacion,
                DescripcionConversacionNombre = asDescripcionConversacionNombre,
                DescripcionNombre = asDescripcionNombre,
                DescripcionCanal = asDescripcionCanal,
                CodigoCliente = asCodigoCliente,
                EstadoObjeto = EstadoObjeto.Nuevo
            };
        }
    }
}
