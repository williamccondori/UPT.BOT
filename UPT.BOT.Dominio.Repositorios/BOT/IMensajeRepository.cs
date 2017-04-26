using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IMensajeRepository
    {
        void Crear(MensajeEntity Mensaje);
        IList<MensajeEntity> Leer(string CodigoCliente);
    }
}
