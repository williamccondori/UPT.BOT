using System.Web.Mvc;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Seguridad;
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
            proxyUsuario = new UsuarioProxy(
                VariableConfiguracion.RutaApi()
                , VariableConfiguracion.VersionApi()
                , VariableConfiguracion.ServicioApi());
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Validar(DtoUsuarioSesion aoDtoUsuarioSesion)
        {

            RespuestaDto<object> loResultado = proxyUsuario.Verificar(new SesionDto
            {
                Usuario = aoDtoUsuarioSesion.Usuario,
                Password = aoDtoUsuarioSesion.Password
            });

            bool lbIndicadorPermiso = (bool)loResultado.Datos;

            if (lbIndicadorPermiso)
            {
                Sesion.IniciarSesion(aoDtoUsuarioSesion.Usuario, aoDtoUsuarioSesion.Password);

                return RedirectToAction("Inicio", "Principal");
            }
            else
            {
                TempData["MensajeError"] = loResultado.Mensaje;

                return RedirectToAction("Login", "Seguridad");
            }
        }
    }

    public class DtoUsuarioSesion
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}