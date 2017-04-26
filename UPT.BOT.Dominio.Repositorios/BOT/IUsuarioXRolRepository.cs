using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IUsuarioXRolRepository
    {
        IList<UsuarioXRolEntity> Buscar(long CodigoUsuario);
    }
}
