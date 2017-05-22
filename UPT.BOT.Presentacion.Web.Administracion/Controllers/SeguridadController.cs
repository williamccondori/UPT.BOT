using System;
using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.DTOs.Shared;
using UPT.BOT.Presentacion.Web.Acceso.Configuracion;
using UPT.BOT.Presentacion.Web.Administracion.Seguridad;
using UPT.BOT.Presentacion.Web.Administracion.Utilidades;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class SeguridadController : Controller
    {
        UsuarioProxy proxyUsuario;

        public SeguridadController()
        {
            proxyUsuario = new UsuarioProxy(VariableConfiguracion.RutaApi());
        }

        public ActionResult Login() => View();

        public ActionResult Validar(UsuarioDto usuario)
        {

            try
            {
                RespuestaDto<bool> resultado = proxyUsuario.Validar(usuario);

                bool permiso = resultado.Datos;

                if (permiso)
                {
                    Sesion.IniciarSesion(usuario.DescripcionUsuario, usuario.DescripcionPassword);

                    return RedirectToAction("Inicio", "Principal");
                }
                else
                {
                    MensajeError(resultado.Mensaje);

                    return RedirectToAction("Login", "Seguridad");
                }
            }
            catch (Exception excepcion)
            {
                MensajeError(excepcion.Message);

                return RedirectToAction("Login", "Seguridad");
            }
        }

        private void MensajeError(string mensaje) => TempData["MensajeError"] = mensaje;
    }
}