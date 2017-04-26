using System;
using UPT.BOT.Aplicacion.DTOs.BOT.Asistente.Seguridad;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Seguridad
{
    public class MensajeService : IMensajeService
    {
        private readonly IMensajeRepository goMensajeRepository;

        public MensajeService()
        {
            goMensajeRepository = new MensajeRepository(new BotContext());
        }

        public bool Guardar(MensajeDto aoMensajeDto)
        {
            if (aoMensajeDto.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                MensajeEntity loMensaje = MensajeEntity.Crear(
                    aoMensajeDto.CodigoCliente
                    , aoMensajeDto.DescripcionActividad
                    , aoMensajeDto.DescripcionCanal
                    , aoMensajeDto.DescripcionLocalidad
                    , aoMensajeDto.DescripcionServicio
                    , aoMensajeDto.DescripcionContenido
                    , aoMensajeDto.DescripcionTipoContenido
                    , aoMensajeDto.DescripcionIntencion
                    , aoMensajeDto.PorcentajeIntencion
                    , aoMensajeDto.FechaMensaje ?? DateTime.Now);

                goMensajeRepository.Crear(loMensaje);

                return true;
            }
            else
            {
                throw new ApplicationException("La opción seleccionada no es válida");
            }
        }
    }
}
