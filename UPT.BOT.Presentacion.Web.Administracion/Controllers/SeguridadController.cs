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
            proxyUsuario = new UsuarioProxy(VariableConfiguracion.RutaApi(), string.Empty);
        }

        public ActionResult Login() => View();

        public ActionResult Validar(UsuarioDto usuario)
        {

            try
            {
                Response<bool> resultado = proxyUsuario.ValidarAccesoSistema(usuario);
                if (!resultado.Estado)
                    return MostrarErrorLogin(resultado.Mensaje);
                
                if (resultado.Datos)
                    return Ingresar(usuario);
                else
                    throw new Exception("El usuario no puede ingresar al sistema");
            }
            catch (Exception excepcion)
            {
                return MostrarErrorLogin(excepcion.Message);
            }
        }

        private void MensajeError(string mensaje)
        {
            TempData["MensajeError"] = mensaje;
        }

        private ActionResult MostrarErrorLogin(string mensaje)
        {
            MensajeError(mensaje);
            return RedirectToAction("Login", "Seguridad");
        }

        private ActionResult Ingresar(UsuarioDto usuario)
        {
            Sesion.IniciarSesion(usuario.DescripcionUsuario, usuario.DescripcionPassword);
            return RedirectToAction("Inicio", "Principal");
        }
    }
}