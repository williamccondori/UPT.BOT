using System;

namespace UPT.BOT.Infraestructura.Datos.BOT.Shared
{
    public class BaseRepository
    {
        protected void Ejecutar(Action accion)
        {
            try
            {
                accion();
            }
            catch (Exception excepcion)
            {
                if (excepcion.InnerException != null)
                    throw new Exception(excepcion.InnerException.Message);
                throw new Exception(excepcion.Message);
            }
        }

        protected T Ejecutar<T>(Func<T> aoAccion)
        {
            try
            {
                return aoAccion();
            }
            catch (Exception excepcion)
            {
                if (excepcion.InnerException != null)
                    throw new Exception(excepcion.InnerException.Message);
                throw new Exception(excepcion.Message);
            }
        }
    }
}
