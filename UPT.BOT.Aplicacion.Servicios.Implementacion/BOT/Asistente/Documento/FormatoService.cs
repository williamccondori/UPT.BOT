using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Documento;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Documento
{
    public class FormatoService : BaseService, IFormatoService
    {
        private readonly IDocumentoRepository repositorioDocumento;

        public FormatoService()
        {
            repositorioDocumento = new DocumentoRepository(contexto);
        }

        public IList<FormatoDto> Obtener()
        {
            List<DocumentoEntity> listaDocumento = repositorioDocumento.LeerXTipo(TipoDocumentoEntity.Formato)
                .Take(5).ToList();

            return listaDocumento.Select(p => new FormatoDto
            {
                CodigoDocumento = p.CodigoDocumento,
                CodigoTipoDocumento = p.CodigoTipoDocumento,
                DescripcionFormato = p.DescripcionFormato,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl
            }).ToList();
        }
    }
}
