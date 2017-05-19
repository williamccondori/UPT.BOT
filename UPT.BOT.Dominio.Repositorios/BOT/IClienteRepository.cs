using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IClienteRepository : IBaseInsercionRepository<ClienteEntity>, IBaseLecturaRepository<ClienteEntity>
    {
        IList<ClienteEntity> LeerXCanal(string canal);
    }
}
