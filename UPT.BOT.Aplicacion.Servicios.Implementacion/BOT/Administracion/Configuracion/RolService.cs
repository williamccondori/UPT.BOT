using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Configuracion
{
    public class RolService : IRolService
    {
        private readonly IRolRepository goRolRepository;

        public RolService()
        {
            goRolRepository = new RolRepository(new BotContext());
        }

        public List<RolConsultaDto> Obtener()
        {
            List<RolEntity> listaRol = goRolRepository.Leer()
                .OrderByDescending(p => p.FechaRegistro)
                .ToList();

            return listaRol.Select(p => new RolConsultaDto
            {
                CodigoRol = p.CodigoRol,
                DescripcionRol = p.DescripcionRol,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                EstadoObjeto = EstadoObjeto.SinCambios
            }).ToList();
        }

        public bool Eliminar(long algId)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(RolRegistroDto aoRol)
        {
            if (aoRol.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                RolEntity loPublicacion = RolEntity.Crear(
                   aoRol.DescripcionRol
                   , aoRol.Usuario);

                goRolRepository.Crear(loPublicacion);

                return true;
            }
            else if (aoRol.EstadoObjeto == EstadoObjeto.Modificado)
            {
                RolEntity loRol = goRolRepository.Buscar(aoRol.CodigoRol);

                loRol.Modificar(
                    aoRol.DescripcionRol
                    , aoRol.Usuario);

                goRolRepository.Modificar(loRol);

                return true;
            }
            else
            {
                throw new Exception("La opción seleccionada no es válida");
            }
        }
    }
}
