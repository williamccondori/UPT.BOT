using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IAdjuntoRepository : IBaseRepository<AdjuntoEntity>
    {
        IList<AdjuntoEntity> LeerXTipo(string tipoAdjunto);
    }
}
