using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class ActividadRepository : BaseRepository, IActividadRepository
    {
        private readonly BotContext goBotContext;

        public ActividadRepository(BotContext aoBotContext)
        {
            goBotContext = aoBotContext;
        }

        public void Crear(ActividadEntity aoActiviad)
        {
            Ejecutar(() =>
            {
                goBotContext.Actividad.Add(aoActiviad);

                goBotContext.GuardarCambios();
            });
        }

        public IList<ActividadEntity> Leer(string asCanal)
        {
            throw new NotImplementedException();
        }
    }
}
