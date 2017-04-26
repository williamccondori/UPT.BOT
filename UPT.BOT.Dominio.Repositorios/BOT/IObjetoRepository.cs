using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IObjetoRepository
    {
        void Crear(ObjetoEntity Objeto);

        void Modificar(ObjetoEntity Objeto);

        void Eliminar(long Id);

        IList<ObjetoEntity> Leer();
    }
}
