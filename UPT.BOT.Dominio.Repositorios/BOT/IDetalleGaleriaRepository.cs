using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IDetalleGaleriaRepository : IBaseRepository<DetalleGaleriaEntity>
    {
        IList<DetalleGaleriaEntity> Leer(long codigoGaleria);
    }
}
