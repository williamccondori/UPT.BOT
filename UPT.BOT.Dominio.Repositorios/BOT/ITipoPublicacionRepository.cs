using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface ITipoPublicacionRepository
    {
        TipoPublicacionEntity Buscar(long Id);

        IList<TipoPublicacionEntity> Consultar();

        void Agregar(TipoPublicacionEntity Publicacion);

        void Modificar(TipoPublicacionEntity Publicacion);

        void Eliminar(long Id);
    }
}
