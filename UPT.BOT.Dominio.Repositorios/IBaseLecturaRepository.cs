using System.Collections.Generic;

namespace UPT.BOT.Dominio.Repositorios
{
    public interface IBaseLecturaRepository<T>
    {
        IList<T> Leer();
        T Buscar(object id);
    }
}
