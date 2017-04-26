using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace UPT.BOT.Infraestructura.Datos.BOT.Shared
{
    public class BaseRepository
    {
        protected void Ejecutar(Action aoAccion)
        {
            try
            {
                aoAccion();
            }
            catch (DbUpdateException loExepcion)
            {
                string lsMensaje = string.Empty;

                lsMensaje = string.Format("DbUpdateException error details {0}", loExepcion.InnerException.InnerException.Message);

                foreach (var loExepcionEntidad in loExepcion.Entries)
                    lsMensaje = lsMensaje + string.Format("Entity of type {0} in state {1} could not be updated", loExepcionEntidad.Entity.GetType().Name, loExepcionEntidad.State);

                throw new Exception(lsMensaje);
            }
            catch (DbEntityValidationException loExepcion)
            {
                string lsMensaje = string.Empty;

                foreach (var loExepcionEntidad in loExepcion.EntityValidationErrors)
                {
                    lsMensaje = lsMensaje + string.Format("Entity of type {0} in state {1} has the following validation errors:", loExepcionEntidad.Entry.Entity.GetType().Name, loExepcionEntidad.Entry.State);

                    foreach (var loExepcionPropiedad in loExepcionEntidad.ValidationErrors)
                        lsMensaje = lsMensaje + string.Format("- Property: {0}, Error: {1}", loExepcionPropiedad.PropertyName, loExepcionPropiedad.ErrorMessage);
                }

                throw new Exception(lsMensaje);
            }
            catch (ApplicationException loExepcion)
            {
                throw new ApplicationException(loExepcion.Message);
            }
            catch (Exception loExepcion)
            {
                throw new Exception(loExepcion.Message);
            }
        }

        protected T Ejecutar<T>(Func<T> aoAccion)
        {
            try
            {
                return aoAccion();
            }
            catch (DbUpdateException loExepcion)
            {
                string lsMensaje = string.Empty;

                lsMensaje = string.Format("DbUpdateException error details {0}", loExepcion.InnerException.InnerException.Message);

                foreach (var loExepcionEntidad in loExepcion.Entries)
                    lsMensaje = lsMensaje + string.Format("Entity of type {0} in state {1} could not be updated", loExepcionEntidad.Entity.GetType().Name, loExepcionEntidad.State);

                throw new Exception(lsMensaje);
            }
            catch (DbEntityValidationException loExepcion)
            {
                string lsMensaje = string.Empty;

                foreach (var loExepcionEntidad in loExepcion.EntityValidationErrors)
                {
                    lsMensaje = lsMensaje + string.Format("Entity of type {0} in state {1} has the following validation errors:", loExepcionEntidad.Entry.Entity.GetType().Name, loExepcionEntidad.Entry.State);

                    foreach (var loExepcionPropiedad in loExepcionEntidad.ValidationErrors)
                        lsMensaje = lsMensaje + string.Format("- Property: {0}, Error: {1}", loExepcionPropiedad.PropertyName, loExepcionPropiedad.ErrorMessage);
                }

                throw new Exception(lsMensaje);
            }
            catch (ApplicationException loExepcion)
            {
                throw new ApplicationException(loExepcion.Message);
            }
            catch (Exception loExepcion)
            {
                throw new Exception(loExepcion.Message);
            }
        }
    }
}
