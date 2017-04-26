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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository goClienteRepository;

        public ClienteService()
        {
            goClienteRepository = new ClienteRepository(new BotContext());
        }

        public bool Guardar(ClienteDto aoClienteDto)
        {
            if (aoClienteDto.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                ClienteEntity loClienteAgregado = goClienteRepository.Buscar(aoClienteDto.CodigoCliente);

                if (loClienteAgregado == null)
                {
                    ClienteEntity loCliente = ClienteEntity.Crear(
                                       aoClienteDto.CodigoCliente
                                       , aoClienteDto.DescripcionCanal
                                       , aoClienteDto.DescripcionNombre
                                       , aoClienteDto.DescripcionConversacion
                                       , aoClienteDto.DescripcionConversacionNombre);

                    goClienteRepository.Crear(loCliente);
                }

                return true;
            }
            else
            {
                throw new ApplicationException("La opción seleccionada no es válida");
            }
        }
    }
}
