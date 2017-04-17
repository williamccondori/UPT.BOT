using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IActividadRepository
    {
        IList<ActividadEntity> Leer(string Canal);
        void Crear(ActividadEntity Activiad);
    }
}
