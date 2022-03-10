using Restaurante.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Repositories.Intefaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);

        Task<List<T>> GetAll(PaginationFilter filter);

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);
    }
}