namespace Restaurante.Application.Interfaces
{
    public interface IBaseApplicationService<T> where T : class
    {
        T GetById(int id);

        void Add(T entity);

        void Remove(int id);

        void Update(T entity);
    }
}