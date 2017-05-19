using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IDocumentoRepository : IBaseRepository<DocumentoEntity>
    {
        IList<DocumentoEntity> LeerXTipo(string tipoDocumento);
    }
}
