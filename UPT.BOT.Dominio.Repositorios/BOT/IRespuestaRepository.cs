using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IRespuestaRepository : IBaseOperacionRepository<RespuestaEntity>
    {
        RespuestaEntity Buscar(string codigoCliente, long codigoAlternativa);
    }
}
