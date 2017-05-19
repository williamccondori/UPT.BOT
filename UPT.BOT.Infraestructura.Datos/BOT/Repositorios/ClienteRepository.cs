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
        private readonly BotContext contextoBot;

        public ClienteRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public ClienteEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Cliente.Find(id);
            });
        }

        public void Crear(ClienteEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Cliente.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<ClienteEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.Cliente.OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public IList<ClienteEntity> LeerXCanal(string canal)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Cliente.Where(p => p.DescripcionCanal == canal).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }
    }
}
