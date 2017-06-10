using System.Data.Entity;
using UPT.BOT.Dominio.Entidades.Shared;

namespace UPT.BOT.Infraestructura.Datos.Utilidades
{
    public class EntityStateHelper
    {
        public static EntityState ConvertirAEntityState(EstadoObjeto aoEstadoObjeto)
        {
            switch (aoEstadoObjeto)
            {
                case EstadoObjeto.SinCambios:
                    {
                        return EntityState.Unchanged;
                    }
                case EstadoObjeto.Nuevo:
                    {
                        return EntityState.Added;
                    }
                case EstadoObjeto.Modificado:
                    {
                        return EntityState.Modified;
                    }
                case EstadoObjeto.Borrado:
                    {
                        return EntityState.Deleted;
                    }
                default:
                    {
                        return EntityState.Unchanged;
                    }
            }
        }
    }
}
