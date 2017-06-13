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
    public class AcreditacionService : BaseService, IAcreditacionService
    {
        private readonly IAdjuntoRepository repositorioAdjunto;

        public AcreditacionService()
        {
            repositorioAdjunto = new AdjuntoRepository(contexto);
        }

        public AcreditacionDto Obtener()
        {
            List<AdjuntoEntity> listaAdjunto = repositorioAdjunto.LeerXTipo(TipoAdjuntoEntity.Acreditacion).Take(5).ToList();

            AdjuntoEntity adjunto = listaAdjunto.FirstOrDefault();

            if (adjunto == null)
                return default(AcreditacionDto);

            return new AcreditacionDto
            {
                CodigoAdjunto = adjunto.CodigoAdjunto,
                CodigoTipoAdjunto = adjunto.CodigoTipoAdjunto,
                DescripcionResena = adjunto.DescripcionResena,
                DescripcionImagen = adjunto.DescripcionImagen,
                DescripcionResumen = adjunto.DescripcionResumen,
                DescripcionTitulo = adjunto.DescripcionTitulo,
                DescripcionUrl = adjunto.DescripcionUrl
            };
        }
    }
}
