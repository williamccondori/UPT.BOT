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

        public bool Guardar(ReglamentoDto reglamento)
        {
            Validar(reglamento);

            if (reglamento.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                DocumentoEntity documento = DocumentoEntity.Crear(TipoDocumentoEntity.Reglamento, reglamento.DescripcionTitulo
                    , reglamento.DescripcionResena, reglamento.DescripcionFormato, reglamento.DescripcionUrl, reglamento.UsuarioRegistro, null);
                repositorioDocumento.Crear(documento);
            }
            else if (reglamento.EstadoObjeto == EstadoObjeto.Modificado)
            {
                DocumentoEntity documento = repositorioDocumento.Buscar(reglamento.CodigoDocumento);
                documento.Modificar(reglamento.DescripcionTitulo, reglamento.DescripcionResena
                    , reglamento.DescripcionFormato, reglamento.DescripcionUrl, reglamento.UsuarioRegistro, reglamento.IndicadorEstado, null);
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
                DescripcionFormato = p.DescripcionFormato,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return Reglamentoes;
        }

        private void Validar(ReglamentoDto reglamento)
        {
            StringBuilder mensaje = new StringBuilder();

            if (reglamento == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = DocumentoEntity.Validar(reglamento.DescripcionTitulo, reglamento.DescripcionResena
                    , reglamento.DescripcionFormato, reglamento.DescripcionUrl);

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
