using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.PlanEstudio;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Planestudio
{
    public class MallaCurricularService : BaseService, IMallaCurricularService
    {
        private readonly IAdjuntoRepository repositorioAdjunto;

        public MallaCurricularService()
        {
            repositorioAdjunto = new AdjuntoRepository(contexto);
        }

        public List<MallaCurricularDto> Obtener()
        {
            List<AdjuntoEntity> listaAdjunto = repositorioAdjunto.LeerXTipo(TipoAdjuntoEntity.MallaCurricular).Take(5).ToList();

            return listaAdjunto.Select(p => new MallaCurricularDto
            {
                CodigoAdjunto = p.CodigoAdjunto,
                CodigoTipoAdjunto = p.CodigoTipoAdjunto,
                DescripcionResena = p.DescripcionResena,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionResumen = p.DescripcionResumen,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }
    }
}
