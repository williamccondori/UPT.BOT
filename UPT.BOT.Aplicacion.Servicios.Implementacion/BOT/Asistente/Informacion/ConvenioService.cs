﻿using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion
{
    public class ConvenioService : BaseService, IConvenioService
    {
        private readonly IAdjuntoRepository repositorioAdjunto;

        public ConvenioService()
        {
            repositorioAdjunto = new AdjuntoRepository(contexto);
        }

        public List<ConvenioDto> Obtener()
        {
            IEnumerable<AdjuntoEntity> listaAdjunto = repositorioAdjunto.LeerXTipo(TipoAdjuntoEntity.Nosotros).Take(5);

            return listaAdjunto.Select(p => new ConvenioDto
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