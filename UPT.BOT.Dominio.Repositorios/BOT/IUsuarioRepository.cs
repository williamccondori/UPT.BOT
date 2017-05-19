using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioEntity>
    {
        bool Verificar(string usuario, string password);
    }
}
