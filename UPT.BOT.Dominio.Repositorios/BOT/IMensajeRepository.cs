using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IMensajeRepository : IBaseInsercionRepository<MensajeEntity>
    {
        IList<MensajeEntity> LeerXCliente(string cliente);
        long TotalXCliente(string cliente);
    }
}
