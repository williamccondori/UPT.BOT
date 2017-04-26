using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        private readonly BotContext goBotContext;

        public ClienteRepository(BotContext aoBotContext)
        {
            goBotContext = aoBotContext;
        }

        public ClienteEntity Buscar(string CodigoCliente)
        {
            return Ejecutar(() =>
            {
                ClienteEntity loCliente = goBotContext.Cliente.Find(CodigoCliente);

                return loCliente;
            });
        }

        public void Crear(ClienteEntity aoCliente)
        {
            Ejecutar(() =>
            {
                goBotContext.Cliente.Add(aoCliente);

                goBotContext.GuardarCambios();
            });
        }

        public IList<ClienteEntity> Leer(string asCanal)
        {
            return Ejecutar(() =>
            {
                List<ClienteEntity> listaCliente = goBotContext.Cliente
                    .Where(p => p.DescripcionCanal == asCanal)
                    .ToList();

                return listaCliente;
            });
        }
    }
}
