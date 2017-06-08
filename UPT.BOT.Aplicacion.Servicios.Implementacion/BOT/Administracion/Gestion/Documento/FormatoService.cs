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
    public class FormatoService : IFormatoService
    {
        private readonly IDocumentoRepository repositorioDocumento;

        public FormatoService()
        {
            repositorioDocumento = new DocumentoRepository(new BotContext());
        }

        public bool Eliminar(object id)
        {
            repositorioDocumento.Eliminar(id);
            return true;
        }

        public bool Guardar(FormatoDto formato)
        {
            Validar(formato);

            if (formato.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                DocumentoEntity documento = DocumentoEntity.Crear(TipoDocumentoEntity.Formato, formato.DescripcionTitulo
                    , formato.DescripcionResena, formato.DescripcionFormato, formato.DescripcionUrl, formato.UsuarioRegistro, null);
                repositorioDocumento.Crear(documento);
            }
            else if (formato.EstadoObjeto == EstadoObjeto.Modificado)
            {
                DocumentoEntity documento = repositorioDocumento.Buscar(formato.CodigoDocumento);
                documento.Modificar(formato.DescripcionTitulo, formato.DescripcionResena
                    , formato.DescripcionFormato, formato.DescripcionUrl, formato.UsuarioRegistro, formato.IndicadorEstado, null);
                repositorioDocumento.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<FormatoDto> Obtener()
        {
            List<DocumentoEntity> documentos = repositorioDocumento.LeerXTipo(TipoDocumentoEntity.Formato).ToList();

            List<FormatoDto> Formatoes = documentos.Select(p => new FormatoDto
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

            return Formatoes;
        }

        private void Validar(FormatoDto formato)
        {
            StringBuilder mensaje = new StringBuilder();

            if (formato == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = DocumentoEntity.Validar(formato.DescripcionTitulo, formato.DescripcionResena
                    , formato.DescripcionFormato, formato.DescripcionUrl);

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
