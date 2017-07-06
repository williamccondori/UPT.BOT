using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface ITarjetaRepository : IBaseRepository<TarjetaEntity>
    {
        IList<TarjetaEntity> LeerXTipo(string codigoTipoTarjeta);
        IList<TarjetaEntity> LeerXTipo(string codigoTipoTarjeta, int numeroRegistro);
    }
}
