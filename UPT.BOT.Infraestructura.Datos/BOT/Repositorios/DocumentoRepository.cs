using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class DocumentoRepository : BaseRepository, IDocumentoRepository
    {
        private readonly BotContext contextoBot;

        public DocumentoRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public DocumentoEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Documento.Find(id);
            });
        }

        public void Crear(DocumentoEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Documento.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                DocumentoEntity entidad = contextoBot.Documento.Find(id);
                contextoBot.Documento.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<DocumentoEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.Documento.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public IList<DocumentoEntity> LeerXTipo(string tipoDocumento)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Documento.Where(p => p.IndicadorEstado == EstadoEntidad.Activo && p.CodigoTipoDocumento == tipoDocumento).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public void Modificar()
        {
            Ejecutar(() =>
            {
                contextoBot.GuardarCambios();
            });
        }
    }
}
