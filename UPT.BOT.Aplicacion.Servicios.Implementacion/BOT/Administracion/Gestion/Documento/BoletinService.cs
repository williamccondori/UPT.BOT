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
    public class BoletinService : IBoletinService
    {
        private readonly IDocumentoRepository repositorioDocumento;

        public BoletinService()
        {
            repositorioDocumento = new DocumentoRepository(new BotContext());
        }

        public bool Eliminar(object id)
        {
            repositorioDocumento.Eliminar(id);
            return true;
        }

        public bool Guardar(BoletinDto boletin)
        {
            Validar(boletin);

            if (boletin.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                DocumentoEntity documento = DocumentoEntity.Crear(TipoDocumentoEntity.Boletin, boletin.DescripcionTitulo
                    , boletin.DescripcionResena, boletin.DescripcionFormato, boletin.DescripcionUrl, boletin.UsuarioRegistro, null);
                repositorioDocumento.Crear(documento);
            }
            else if (boletin.EstadoObjeto == EstadoObjeto.Modificado)
            {
                DocumentoEntity documento = repositorioDocumento.Buscar(boletin.CodigoDocumento);
                documento.Modificar(boletin.DescripcionTitulo, boletin.DescripcionResena
                    , boletin.DescripcionFormato, boletin.DescripcionUrl, boletin.UsuarioRegistro, boletin.IndicadorEstado, null);
                repositorioDocumento.Modificar();
            }
            else
                throw new Exception("Acción inválida");

            return true;

        }

        public IList<BoletinDto> Obtener()
        {
            List<DocumentoEntity> documentos = repositorioDocumento.LeerXTipo(TipoDocumentoEntity.Boletin).ToList();

            List<BoletinDto> Boletines = documentos.Select(p => new BoletinDto
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

            return Boletines;
        }

        private void Validar(BoletinDto boletin)
        {
            StringBuilder mensaje = new StringBuilder();

            if (boletin == null)
                mensaje.Append("No se encuentan los datos necesarios para el proceso.");
            else
            {
                string mensajeValidacion = DocumentoEntity.Validar(boletin.DescripcionTitulo, boletin.DescripcionResena
                    , boletin.DescripcionFormato, boletin.DescripcionUrl);

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
