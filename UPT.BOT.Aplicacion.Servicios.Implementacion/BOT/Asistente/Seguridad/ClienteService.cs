using System;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Seguridad;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;
using UPT.BOT.Utilidades.Utilidades.Mensajes;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Seguridad
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository repositorioCliente;

        public ClienteService()
        {
            repositorioCliente = new ClienteRepository(new BotContext());
        }

        public bool Guardar(ClienteDto cliente)
        {
            if (cliente.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                ClienteEntity clienteExistente = repositorioCliente.Buscar(cliente.CodigoCliente);

                if (clienteExistente == null)
                {
                    ClienteEntity nuevoCliente = ClienteEntity.Crear(
                        cliente.CodigoCliente
                        , cliente.DescripcionCanal
                        , cliente.DescripcionNombre
                        , cliente.DescripcionConversacion
                        , cliente.DescripcionConversacionNombre);

                    repositorioCliente.Crear(nuevoCliente);
                }
            }
            else
            {
                throw new ApplicationException(Excepcion.MetodoNoValido);
            }

            return true;
        }
    }
}
