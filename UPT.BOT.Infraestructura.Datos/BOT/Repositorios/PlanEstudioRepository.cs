using System;
using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class PlanEstudioRepository : BaseRepository, IPlanEstudioRepository
    {
        private readonly BotContext contexto;

        public PlanEstudioRepository(BotContext contexto)
        {
            this.contexto = contexto;
        }

        public PlanEstudioEntity Buscar(object id)
        {
            throw new NotImplementedException();
        }

        public void Crear(PlanEstudioEntity entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(object id)
        {
            throw new NotImplementedException();
        }

        public IList<PlanEstudioEntity> Leer()
        {
            throw new NotImplementedException();
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
