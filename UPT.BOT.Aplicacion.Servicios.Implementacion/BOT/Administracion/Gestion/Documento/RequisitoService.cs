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
    public class RequisitoService : IRequisitoService
    {
        private readonly IDocumentoRepository repositorioDocumento;

        public RequisitoService()
        {
            repositorioDocumento = new DocumentoRepository(new BotContext());
        }

        public bool Eliminar(object id)
        {
            repositorioDocumento.Eliminar(id);
            return true;
        }

        public bool Guardar(RequisitoDto Requisito)
        {
            Validar(Requisito);

            if (Requisito.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                DocumentoEntity documento = DocumentoEntity.Crear(TipoDocumentoEntity.Requisito, Requisito.DescripcionTitulo
                    , Requisito.DescripcionResena, Requisito.DescripcionRequisito, Requisito.DescripcionUrl, Requisito.UsuarioRegistro, null);
                repositorioDocumento.Crear(documento);
            }
            else if (Requisito.EstadoObjeto == EstadoObjeto.Modificado)
            {
                DocumentoEntity documento = repositorioDocumento.Buscar(Requisito.CodigoDocumento);
                documento.Modificar(Requisito.DescripcionTitulo, Requisito.DescripcionResena
                    , Requisito.DescripcionRequisito, Requisito.DescripcionUrl, Requisito.UsuarioRegistro, Requisito.IndicadorEstado, null);
                repositorioDocumento.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<RequisitoDto> Obtener()
        {
            List<DocumentoEntity> documentos = repositorioDocumento.LeerXTipo(TipoDocumentoEntity.Requisito).ToList();

            List<RequisitoDto> Requisitoes = documentos.Select(p => new RequisitoDto
            {
                CodigoDocumento = p.CodigoDocumento,
                CodigoTipoDocumento = p.CodigoTipoDocumento,
                DescripcionContenido = p.DescripcionContenido,
                DescripcionRequisito = p.DescripcionRequisito,
                DescripcionResena = p.DescripcionResena,
                DescripcionTitulo = p.DescripcionTitulo,
                DescripcionUrl = p.DescripcionUrl,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                UsuarioRegistro = p.UsuarioRegistro
            }).ToList();

            return Requisitoes;
        }

        private void Validar(RequisitoDto Requisito)
        {
            StringBuilder mensaje = new StringBuilder();

            if (Requisito == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = DocumentoEntity.Validar(Requisito.DescripcionTitulo, Requisito.DescripcionResena
                    , Requisito.DescripcionRequisito, Requisito.DescripcionUrl);

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
