﻿using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Asistente.Documento;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Asistente.Documento
{
    public class FormatoService : IFormatoService
    {
        private readonly IDocumentoRepository repositorioDocumento;

        public FormatoService()
        {
            repositorioDocumento = new DocumentoRepository(new BotContext());
        }

        public IList<FormatoDto> Obtener()
        {
            IEnumerable<DocumentoEntity> listaDocumento = repositorioDocumento.LeerXTipo(TipoDocumentoEntity.Boletin).Take(5);

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