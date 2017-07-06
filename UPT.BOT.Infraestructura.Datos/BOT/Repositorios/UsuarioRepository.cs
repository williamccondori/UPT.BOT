using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.BOT.Repositorios
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly BotContext contextoBot;

        public UsuarioRepository(BotContext contextoBot)
        {
            this.contextoBot = contextoBot;
        }

        public UsuarioEntity Buscar(object id)
        {
            return Ejecutar(() =>
            {
                return contextoBot.Usuario.Find(id);
            });
        }

        public void Crear(UsuarioEntity entidad)
        {
            Ejecutar(() =>
            {
                contextoBot.Usuario.Add(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public void Eliminar(object id)
        {
            Ejecutar(() =>
            {
                UsuarioEntity entidad = contextoBot.Usuario.Find(id);
                contextoBot.Usuario.Remove(entidad);
                contextoBot.GuardarCambios();
            });
        }

        public IList<UsuarioEntity> Leer()
        {
            return Ejecutar(() =>
            {
                return contextoBot.Usuario.Where(p => p.IndicadorEstado == EstadoEntidad.Activo).OrderByDescending(p => p.FechaRegistro).ToList();
            });
        }

        public void Modificar()
        {
            Ejecutar(() =>
            {
                contextoBot.GuardarCambios();
            });
        }

        public bool ValidarAccesoSistema(string descripcionUsuario, string descripcionPassword)
        {
            return Ejecutar(() =>
            {
                //UsuarioEntity usuarioEncontrado = contextoBot.Usuario.FirstOrDefault(p => p.DescripcionUsuario == descripcionUsuario &&
                // p.DescripcionPassword == descripcionPassword);

                UsuarioEntity usuarioEncontrado = contextoBot.Usuario.FirstOrDefault();

                if (usuarioEncontrado == null)
                    throw new ApplicationException("No se encontró un usuario con los datos ingresados");

                if (usuarioEncontrado.IndicadorEstado == EstadoEntidad.Inactivo)
                    throw new ApplicationException("El usuario se encuentra inactivo");

                if (usuarioEncontrado.IndicadorHabilitado == EstadoEntidad.No)
                    throw new ApplicationException("El usuario se encuentra desabilitado");

                return true;
            });
        }
    }
}
