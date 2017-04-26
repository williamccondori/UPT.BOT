using System;
using System.Web;
using System.Web.SessionState;

namespace UPT.BOT.Presentacion.Web.Administracion.Seguridad
{
    public class Sesion
    {
        public static bool ValidarSesion()
        {
            HttpSessionState loSesion = HttpContext.Current.Session;

            string lsCodigoUsuario = (string)loSesion["sUsuario"];

            return string.IsNullOrEmpty(lsCodigoUsuario) ? false : true;
        }

        public static void IniciarSesion(string asCodigoUsuario, string asPassword)
        {
            HttpSessionState loSesion = HttpContext.Current.Session;

            loSesion["sUsuario"] = asCodigoUsuario;
            loSesion["sPassword"] = asPassword;
        }

        public static string Usuario()
        {
            HttpSessionState loSesion = HttpContext.Current.Session;

            string lsUsuario = (string)loSesion["sUsuario"];

            if (string.IsNullOrEmpty(lsUsuario))
            {
                throw new ApplicationException("La sesión del usuario ha terminado.");
            }
            else
            {
                return lsUsuario;
            }
        }
    }
}