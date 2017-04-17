using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Configuracion
{
    public class TipoPublicacionService : ITipoPublicacionService
    {
        private readonly ITipoPublicacionRepository goTipoPublicacionRepository;

        public TipoPublicacionService()
        {
            goTipoPublicacionRepository = new TipoPublicacionRepository(
                new BotContext());
        }

        public IList<TipoPublicacionConsultaDto> Consultar()
        {
            List<TipoPublicacionEntity> listaTipoPublicacion = goTipoPublicacionRepository.Consultar()
               .ToList();

            return listaTipoPublicacion.Select(p => new TipoPublicacionConsultaDto
            {
                CodigoTipoPublicacion = p.CodigoTipoPublicacion,
                DescripcionTipoPublicacion = p.DescripcionTipoPublicacion,
                IndicadorEstado = p.IndicadorEstado
            }).ToList();
        }

        public bool Eliminar(long algId)
        {
            goTipoPublicacionRepository.Eliminar(algId);

            return true;
        }


        public bool Agregar(TipoPublicacionRegistroDto aoTipoPublicacionDto)
        {
            TipoPublicacionEntity loTipoPublicacion = new TipoPublicacionEntity
            {
                DescripcionTipoPublicacion = aoTipoPublicacionDto.DescripcionTipoPublicacion,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                EstadoObjeto = EstadoObjeto.Nuevo,
                UsuarioRegistro = aoTipoPublicacionDto.CodigoUsuario
            };

            goTipoPublicacionRepository.Agregar(loTipoPublicacion);

            return true;
        }

        public bool Modificar(TipoPublicacionRegistroDto aoTipoPublicacionDto)
        {
            TipoPublicacionEntity loTipoPublicacion = goTipoPublicacionRepository.Buscar(aoTipoPublicacionDto.CodigoTipoPublicacion);

            loTipoPublicacion.DescripcionTipoPublicacion = aoTipoPublicacionDto.DescripcionTipoPublicacion;
            loTipoPublicacion.FechaModifico = DateTime.Now;
            loTipoPublicacion.IndicadorEstado = EstadoEntidad.Activo;
            loTipoPublicacion.EstadoObjeto = EstadoObjeto.Nuevo;
            loTipoPublicacion.UsuarioModifico = aoTipoPublicacionDto.CodigoUsuario;


            goTipoPublicacionRepository.Modificar(loTipoPublicacion);

            return true;
        }
    }
}
