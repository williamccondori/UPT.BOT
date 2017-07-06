using System;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT
{
    public class ObjetoService : BaseService, IObjetoService
    {
        private readonly IObjetoRepository _repositorioObjeto;
        public ObjetoService()
        {
            _repositorioObjeto = new ObjetoRepository(contexto);
        }

        public bool Guardar(ObjetoDto dto)
        {
            if (dto.Estado == EstadoObjeto.Nuevo)
            {
                ObjetoEntity objeto = ObjetoEntity.Crear(dto.DescripcionObjeto, dto.DescripcionControlador
                    , dto.DescripcionAccion, dto.IndicadorHabilitado, dto.Usuario);
                _repositorioObjeto.Crear(objeto);
            }
            else if (dto.Estado == EstadoObjeto.Modificado)
            {
                ObjetoEntity objeto = _repositorioObjeto.Buscar(dto.CodigoObjeto);
                objeto.Modificar(dto.DescripcionObjeto, dto.DescripcionControlador
                    , dto.DescripcionAccion, dto.IndicadorHabilitado, dto.Usuario);
                _repositorioObjeto.Modificar();
            }
            else
                throw new Exception("La operación seleccionada es incorrecta");
            return true;
        }
    }
}
