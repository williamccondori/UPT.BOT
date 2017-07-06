using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT
{
    public class RolService : BaseService, IRolService
    {
        private readonly IRolRepository _repositorioRol;
        public RolService()
        {
            _repositorioRol = new RolRepository(contexto);
        }

        public bool Guardar(RolDto dto)
        {
            if (dto.Estado == EstadoObjeto.Nuevo)
            {
                RolEntity rol = RolEntity.Crear(dto.DescripcionRol, dto.Usuario);
                _repositorioRol.Crear(rol);
            }
            else if (dto.Estado == EstadoObjeto.Modificado)
            {
                RolEntity rol = _repositorioRol.Buscar(dto.CodigoRol);
                rol.Modificar(dto.DescripcionRol, dto.Usuario);
                _repositorioRol.Modificar();
            }
            else
                throw new Exception("La operación seleccionada es incorrecta");
            return true;
        }

        public IList<RolDto> Obtener()
        {
            List<RolEntity> entidades = _repositorioRol.Leer().ToList();
            List<RolDto> dtos = entidades.Select(p => Mapear(p)).ToList();
            return dtos;
        }

        private RolDto Mapear(RolEntity entidad)
        {
            return new RolDto
            {
                CodigoRol = entidad.CodigoRol,
                DescripcionRol = entidad.DescripcionRol,
                Estado = EstadoObjeto.SinCambios,
                Fecha = entidad.FechaRegistro,
                IndicadorEstado = entidad.IndicadorEstado,
                Usuario = entidad.UsuarioRegistro
            };
        }
    }
}
