namespace Restaurante.Infrastructure.Repositories.Intefaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);
    }
}