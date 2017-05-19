using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Buzon;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;
using UPT.BOT.Utilidades.Utilidades.Mensajes;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Buzon
{
    public class BuzonService : IBuzonService
    {
        private readonly IBuzonRepository repositorioBuzon;
        private readonly ITipoBuzonRepository repositorioTipoBuzon;

        public BuzonService()
        {
            BotContext contexto = new BotContext();
            repositorioBuzon = new BuzonRepository(contexto);
            repositorioTipoBuzon = new TipoBuzonRepository(contexto);
        }

        public bool Guardar(BuzonDto buzon)
        {
            if (buzon.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                BuzonEntity nuevoBuzon = BuzonEntity.Crear(
                    buzon.CodigoTipoBuzon
                    , buzon.CodigoCliente
                    , buzon.DescripcionMensaje);

                repositorioBuzon.Crear(nuevoBuzon);
            }
            else
            {
                throw new ApplicationException(Excepcion.MetodoNoValido);
            }

            return true;
        }

        public IList<TipoBuzonDto> ObtenerTipo()
        {
            IEnumerable<TipoBuzonEntity> listaTipoBuzon = repositorioTipoBuzon.Leer();

            return listaTipoBuzon.Select(p => new TipoBuzonDto
            {
                CodigoTipoBuzon = p.CodigoTipoBuzon,
                DescripcionTipoBuzon = p.DescripcionTipoBuzon
            }).ToList();
        }
    }
}
