namespace UPT.BOT.Dominio.Repositorios
{
    public interface IBaseOperacionRepository<T> : IBaseInsercionRepository<T>
    {
        void Modificar();
        void Eliminar(object id);
    }
}
