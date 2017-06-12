using System;
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

        public IList<MensajeEntity> Obtener(string cliente)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Mensaje.Where(p => p.CodigoCliente == cliente)
                .OrderByDescending(p => p.FechaMensaje).ToList();
            });
        }

        public long ObtenerNumero(string cliente)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Mensaje.LongCount(p => p.CodigoCliente == cliente);
            });
        }

        public long ObtenerNumero(DateTime fechaInicio, DateTime fechaFinal)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Mensaje.LongCount(p => p.FechaMensaje > fechaInicio && p.FechaMensaje < fechaFinal);
            });
        }

        public string[] ObtenerIntenciones()
        {
            var intenciones = contextoBot.Mensaje.GroupBy(p => p.DescripcionIntencion).ToList();

            return intenciones.Select(p => p.Key).ToArray();
        }

        public long ObtenerNumeroIntencion(string intencion)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Mensaje.LongCount(p => p.DescripcionIntencion == intencion);
            });
        }
    }
}
