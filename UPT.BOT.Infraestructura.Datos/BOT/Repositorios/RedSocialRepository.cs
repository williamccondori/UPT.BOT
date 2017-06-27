﻿using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class RedSocialRepository : BaseRepository, IRedSocialRepository
    {
        private readonly BotContext contexto;

        public RedSocialRepository(BotContext contexto)
        {
            this.contexto = contexto;
        }

        public RedSocialEntity Buscar(object id)
        {
            throw new NotImplementedException();
        }

        public void Crear(RedSocialEntity entidad)
        {
            Ejecutar(() =>
            {
                contexto.RedSocial.Add(entidad);
                contexto.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            throw new NotImplementedException();
        }

        public IList<RedSocialEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contexto.RedSocial.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
