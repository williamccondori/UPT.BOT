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
    public class TarjetaService : BaseService, ITarjetaService
    {
        private readonly ITarjetaRepository _repositorioTarjeta;
        public TarjetaService()
        {
            _repositorioTarjeta = new TarjetaRepository(contexto);
        }
        public bool Guardar(TarjetaDto dto)
        {
            if (dto.Estado == EstadoObjeto.Nuevo)
            {
                TarjetaEntity tarjeta = TarjetaEntity.Crear(dto.CodigoTipoTarjeta, dto.DescripcionTitulo
                    , dto.DescripcionSubtitulo, dto.DescripcionResena, dto.DescripcionImagen,
                    dto.DescripcionUrl, dto.IndicadorEstado, dto.Usuario);
                _repositorioTarjeta.Crear(tarjeta);
            }
            else if (dto.Estado == EstadoObjeto.Modificado)
            {
                TarjetaEntity tarjeta = _repositorioTarjeta.Buscar(dto.CodigoTarjeta);
                tarjeta.Modificar(dto.DescripcionTitulo, dto.DescripcionSubtitulo, dto.DescripcionResena
                    , dto.DescripcionImagen, dto.DescripcionUrl, dto.IndicadorHabilitado, dto.Usuario);
                _repositorioTarjeta.Modificar();
            }
            else
                throw new Exception("La operación seleccionada es incorrecta");
            return true;
        }

        public IList<TarjetaDto> ObtenerXTipo(string codigoTipo)
        {
            List<TarjetaEntity> entidades = _repositorioTarjeta.LeerXTipo(codigoTipo).ToList();
            List<TarjetaDto> dtos = entidades.Select(p => Mapear(p)).ToList();
            return dtos;
        }

        public IList<TarjetaDto> ObtenerXTipo(string codigoTipo, int numeroRegistro)
        {
            List<TarjetaEntity> entidades = _repositorioTarjeta.LeerXTipo(codigoTipo, numeroRegistro).ToList();
            List<TarjetaDto> dtos = entidades.Select(p => Mapear(p)).ToList();
            return dtos;
        }

        public TarjetaDto Mapear(TarjetaEntity entidad)
        {
            return new TarjetaDto
            {
                CodigoTarjeta = entidad.CodigoTarjeta,
                CodigoTipoTarjeta = entidad.CodigoTipoTarjeta,
                DescripcionImagen = entidad.DescripcionImagen,
                DescripcionResena = entidad.DescripcionResena,
                DescripcionSubtitulo = entidad.DescripcionSubtitulo,
                DescripcionTitulo = entidad.DescripcionTitulo,
                DescripcionUrl = entidad.DescripcionUrl,
                Estado = EstadoObjeto.SinCambios,
                Fecha = entidad.FechaRegistro,
                IndicadorEstado = entidad.IndicadorEstado,
                IndicadorHabilitado = entidad.IndicadorHabilitado,
                Usuario = entidad.UsuarioRegistro,
                TipoTarjeta = new TipoTarjetaDto
                {
                    CodigoTipoTarjeta = entidad.TipoTarjetaX.CodigoTipoTarjeta,
                    DescripcionTipoTarjeta = entidad.TipoTarjetaX.DescripcionTipoTarjeta
                }
            };
        }
    }
}
