namespace UPT.BOT.Dominio.Repositorios
{
    public interface IBaseInsercionRepository<T>
    {
        void Crear(T entidad);
    }
}
