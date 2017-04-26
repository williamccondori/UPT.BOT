using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IRolRepository
    {
        void Crear(RolEntity Rol);
        void Modificar(RolEntity Rol);
        void Eliminar(long Id);
        IList<RolEntity> Leer();
        RolEntity Buscar(long Id);
    }
}
