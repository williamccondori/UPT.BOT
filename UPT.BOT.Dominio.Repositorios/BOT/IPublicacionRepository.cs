using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IPublicacionRepository : IBaseRepository<PublicacionEntity>
    {
        IList<PublicacionEntity> LeerXTipo(string tipoPublicacion);
    }
}
