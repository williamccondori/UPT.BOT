using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Configuracion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository goUsuarioRepository;

        public UsuarioService()
        {
            goUsuarioRepository = new UsuarioRepository(new BotContext());
        }

        public List<UsuarioConsultaDto> Obtener()
        {
            List<UsuarioEntity> listaUsuario = goUsuarioRepository.Leer()
                .OrderByDescending(p => p.FechaRegistro)
                .ToList();

            return listaUsuario.Select(p => new UsuarioConsultaDto
            {
                CodigoUsuario = p.CodigoUsuario,
                IndicadorHabilitado = p.IndicadorHabilitado == "S" ? true : false,
                DescripcionResena = p.DescripcionResena,
                DescripcionImagen = p.DescripcionImagen,
                DescripcionUsuario = p.DescripcionUsuario,
                DescripcionEmail = p.DescripcionEmail,
                DescripcionApellido = p.DescripcionApellido,
                DescripcionNombre = p.DescripcionNombre,
                IndicadorEstado = p.IndicadorEstado,
                FechaRegistro = p.FechaRegistro,
                EstadoObjeto = EstadoObjeto.SinCambios
            }).ToList();
        }

        public bool Eliminar(long algId)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(UsuarioRegistroDto aoUsuario)
        {
            if (aoUsuario.EstadoObjeto == EstadoObjeto.Nuevo)
            {
                UsuarioEntity loPublicacion = UsuarioEntity.Crear(
                    aoUsuario.DescripcionNombre
                    , aoUsuario.DescripcionApellido
                    , aoUsuario.DescripcionEmail
                    , aoUsuario.DescripcionUsuario
                    , aoUsuario.DescripcionPassword
                    , aoUsuario.DescripcionImagen
                    , aoUsuario.DescripcionResena
                    , aoUsuario.IndicadorHabilitado ? "S" : "N"
                   , aoUsuario.Usuario);

                goUsuarioRepository.Crear(loPublicacion);

                return true;
            }
            else if (aoUsuario.EstadoObjeto == EstadoObjeto.Modificado)
            {
                UsuarioEntity loUsuario = goUsuarioRepository.Buscar(aoUsuario.CodigoUsuario);

                loUsuario.Modificar(
                    aoUsuario.DescripcionNombre
                    , aoUsuario.DescripcionApellido
                    , aoUsuario.DescripcionEmail
                    , aoUsuario.DescripcionUsuario
                    , aoUsuario.DescripcionPassword ?? loUsuario.DescripcionPassword
                    , aoUsuario.DescripcionImagen
                    , aoUsuario.DescripcionResena
                    , aoUsuario.IndicadorHabilitado ? "S" : "N"
                    , aoUsuario.Usuario);

                goUsuarioRepository.Modificar(loUsuario);

                return true;
            }
            else
            {
                throw new ApplicationException("La opción seleccionada no es válida");
            }
        }

        public bool Verificar(string asUsuario, string asPassword)
        {
            UsuarioEntity loUsuario = goUsuarioRepository.Buscar(asUsuario);

            if (loUsuario == null)
            {
                throw new ApplicationException("Ingrese un nombre de usuario válido.");
            }

            if (loUsuario.DescripcionPassword == asPassword)
            {
                if (loUsuario.IndicadorHabilitado == "N")
                {
                    throw new ApplicationException("El usuario se encuentra inhabilitado.");
                }
            }
            else
            {
                throw new ApplicationException("La contraseña es incorrecta.");
            }

            return true;
        }
    }
}
