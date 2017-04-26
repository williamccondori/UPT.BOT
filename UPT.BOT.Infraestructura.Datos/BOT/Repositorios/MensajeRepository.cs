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
        private readonly BotContext goBotContext;

        public MensajeRepository(BotContext aoBotContext)
        {
            goBotContext = aoBotContext;
        }

        public void Crear(MensajeEntity aoMensaje)
        {
            Ejecutar(() =>
            {
                goBotContext.Mensaje.Add(aoMensaje);

                goBotContext.GuardarCambios();
            });
        }

        public IList<MensajeEntity> Leer(string asCodigoCliente)
        {
            return Ejecutar(() =>
            {
                List<MensajeEntity> listaMensaje = goBotContext.Mensaje
                    .Where(p => p.CodigoCliente == asCodigoCliente)
                    .ToList();

                return listaMensaje;
            });
        }
    }
}
