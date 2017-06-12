using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Analisis;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Analisis
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository repositorioCliente;
        private readonly IMensajeRepository repositorioMensaje;

        public ClienteService()
        {
            repositorioCliente = new ClienteRepository(contexto);
            repositorioMensaje = new MensajeRepository(contexto);
        }

        public IList<ClienteDto> Obtener()
        {
            List<ClienteEntity> clientes = repositorioCliente.LeerXCanal("facebook")
                .ToList();

            List<ClienteDto> clientesDto = clientes.Select(p => new ClienteDto
            {
                CodigoCliente = p.CodigoCliente,
                DescripcionCanal = p.DescripcionCanal,
                DescripcionConversacion = p.DescripcionConversacion,
                DescripcionMetadata = p.DescripcionMetadata,
                DescripcionNombre = p.DescripcionNombre
            }).ToList();

            return clientesDto;
        }

        public IList<GraficoDto> ObtenerNumeroMensajes()
        {
            List<ClienteEntity> clientes = repositorioCliente.LeerXCanal("facebook")
                .Take(10).ToList();

            List<GraficoDto> resumen = new List<GraficoDto>();

            clientes.ForEach(p =>
            {
                long numeroMensajes = repositorioMensaje.ObtenerNumero(p.CodigoCliente);

                resumen.Add(new GraficoDto
                {
                    Etiqueta = p.DescripcionNombre,
                    Valor = numeroMensajes
                });
            });

            return resumen;
        }
    }
}
