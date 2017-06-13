using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.PlanEstudio;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Planestudio
{
    public class PlanEstudioService : BaseService, IPlanEstudioService
    {
        private readonly IPlanEstudioRepository repositorioPlanEstudio;

        public PlanEstudioService()
        {
            repositorioPlanEstudio = new PlanEstudioRepository(contexto);
        }

        public List<PlanEstudioDto> Obtener()
        {
            throw new NotImplementedException();
        }
    }
}
