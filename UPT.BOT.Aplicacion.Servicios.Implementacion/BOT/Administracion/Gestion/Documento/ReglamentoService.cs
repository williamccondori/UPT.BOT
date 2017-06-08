using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Gestion.Documento;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Gestion.Documento
{
    public class ReglamentoService : IReglamentoService
    {
        private readonly IDocumentoRepository repositorioDocumento;

        public ReglamentoService()
        {
            repositorioDocumento = new DocumentoRepository(new BotContext());
        }

        public bool Eliminar(object id)
        {
            repositorioDocumento.Eliminar(id);
            return true;
        }

        public bool Guardar(ReglamentoDto Reglamento)
        {
            Validar(Reglamento);

            if (Reglamento.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                DocumentoEntity documento = DocumentoEntity.Crear(TipoDocumentoEntity.Reglamento, Reglamento.DescripcionTitulo
                    , Reglamento.DescripcionResena, Reglamento.DescripcionReglamento, Reglamento.DescripcionUrl, Reglamento.UsuarioRegistro, null);
                repositorioDocumento.Crear(documento);
            }
            else if (Reglamento.EstadoObjeto == EstadoObjeto.Modificado)
            {
                DocumentoEntity documento = repositorioDocumento.Buscar(Reglamento.CodigoDocumento);
                documento.Modificar(Reglamento.DescripcionTitulo, Reglamento.DescripcionResena
                    , Reglamento.DescripcionReglamento, Reglamento.DescripcionUrl, Reglamento.UsuarioRegistro, Reglamento.IndicadorEstado, null);
                repositorioDocumento.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<ReglamentoDto> Obtener()
        {
            List<DocumentoEntity> documentos = repositorioDocumento.LeerXTipo(TipoDocumentoEntity.Reglamento).ToList();

            List<ReglamentoDto> Reglamentoes = documentos.Select(p => new ReglamentoDto
            {
                CodigoDocumento = p.CodigoDocumento,
                CodigoTipoDocumento = p.CodigoTipoDocumento,
                DescripcionContenido = p.DescripcionContenido,
                DescripcionReglamento = p.DescripcionReglamento,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return Reglamentoes;
        }

        private void Validar(ReglamentoDto Reglamento)
        {
            StringBuilder mensaje = new StringBuilder();

            if (Reglamento == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = DocumentoEntity.Validar(Reglamento.DescripcionTitulo, Reglamento.DescripcionResena
                    , Reglamento.DescripcionReglamento, Reglamento.DescripcionUrl);

                mensaje.Append(mensajeValidacion);
            }

            if (mensaje.Length > 0)
            {
                StringBuilder validacion = new StringBuilder();
                validacion.Append("Validaciones: ");
                validacion.Append(mensaje.ToString());
                throw new Exception(validacion.ToString());
            }
        }
    }
}
