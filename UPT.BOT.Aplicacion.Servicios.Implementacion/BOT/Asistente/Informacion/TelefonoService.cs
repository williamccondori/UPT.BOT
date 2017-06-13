using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Informacion;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Informacion
{
    public class TelefonoService : BaseService, ITelefonoService
    {
        private readonly ITelefonoRepository repositorioTelefono;

        public TelefonoService()
        {
            repositorioTelefono = new TelefonoRepository(contexto);
        }

        public List<TelefonoDto> Obtener()
        {
            List<TelefonoEntity> listaTelefono = repositorioTelefono.Leer().Take(5).ToList();

            return listaTelefono.Select(p => new TelefonoDto
            {
                CodigoTelefono = p.CodigoTelefono,
                DescripcionTelefono = p.DescripcionTelefono,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }
    }
}
