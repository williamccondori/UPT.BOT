using System.Web.Mvc;
using UPT.BOT.Presentacion.Web.Administracion.Seguridad;

namespace UPT.BOT.Presentacion.Web.Administracion.Controllers
{
    public class SeguridadController : Controller
    {
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Validar(DtoUsuarioSesion aoDtoUsuarioSesion)
        {
            string lsNombreControlador = "Seguridad";

            bool lbIndicadorPermiso = true;

            if (lbIndicadorPermiso)
            {
                Sesion.IniciarSesion(aoDtoUsuarioSesion.Usuario, aoDtoUsuarioSesion.Password);

                lsNombreControlador = "Principal";
            }
            else
            {
                TempData["MensajeError"] = "Sus credenciales son incorrectas.";
            }

            return RedirectToAction("Inicio", lsNombreControlador);
        }
    }

    public class DtoUsuarioSesion
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}