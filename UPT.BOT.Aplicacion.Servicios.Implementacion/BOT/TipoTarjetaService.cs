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
    public class TipoTarjetaService : BaseService, ITipoTarjetaService
    {
        private readonly ITipoTarjetaRepository _repositorioTipoTarjeta;
        public TipoTarjetaService()
        {
            _repositorioTipoTarjeta = new TipoTarjetaRepository(contexto);
        }

        public IList<TipoTarjetaDto> Obtener()
        {
            List<TipoTarjetaEntity> entidades = _repositorioTipoTarjeta.Leer().ToList();
            List<TipoTarjetaDto> dtos = entidades.Select(p => Mapear(p)).ToList();
            return dtos;
        }

        private TipoTarjetaDto Mapear(TipoTarjetaEntity entidad)
        {
            return new TipoTarjetaDto
            {
                CodigoTipoTarjeta = entidad.CodigoTipoTarjeta,
                DescripcionTipoTarjeta = entidad.DescripcionTipoTarjeta,
                Estado = EstadoObjeto.SinCambios,
                Fecha = entidad.FechaRegistro,
                IndicadorEstado = entidad.IndicadorEstado,
                Usuario = entidad.UsuarioRegistro
            };
        }
    }
}
