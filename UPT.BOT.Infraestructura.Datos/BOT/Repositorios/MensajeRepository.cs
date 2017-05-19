using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class MensajeRepository : BaseRepository, IMensajeRepository
    {
        private readonly BotContext contextoBot;

        public MensajeRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public void Crear(MensajeEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Mensaje.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<MensajeEntity> LeerXCliente(string cliente)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Mensaje.Where(p => p.CodigoCliente == cliente).OrderByDescending(p => p.FechaMensaje).ToList();
            });
        }

        public long TotalXCliente(string cliente)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Mensaje.LongCount(p => p.CodigoCliente == cliente);
            });
        }
    }
}
