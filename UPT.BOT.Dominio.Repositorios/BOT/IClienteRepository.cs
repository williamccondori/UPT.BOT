using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IClienteRepository
    {
        void Crear(ClienteEntity Cliente);
        IList<ClienteEntity> Leer(string Canal);
        ClienteEntity Buscar(string CodigoCliente);
    }
}
