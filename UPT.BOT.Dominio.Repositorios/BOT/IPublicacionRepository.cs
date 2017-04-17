using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IPublicacionRepository
    {
        IList<PublicacionEntity> Consultar();

        PublicacionEntity Buscar(long Id);

        void Crear(PublicacionEntity Publicacion);

        void Modificar(PublicacionEntity Publicacion);

        void Eliminar(long Id);
    }
}
