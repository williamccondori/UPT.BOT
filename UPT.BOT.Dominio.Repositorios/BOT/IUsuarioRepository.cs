using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IUsuarioRepository
    {
        void Crear(UsuarioEntity Usuario);

        void Modificar(UsuarioEntity Usuario);

        void Eliminar(long Id);

        UsuarioEntity Buscar(string Usuario);

        UsuarioEntity Buscar(long Id);

        IList<UsuarioEntity> Leer();
    }
}
