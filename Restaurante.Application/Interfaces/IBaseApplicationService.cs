using Restaurante.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurante.Application.Interfaces
{
    public interface IBaseApplicationService<T> where T : class
    {
        T GetById(int id);

        Task<List<T>> GetAll(PaginationFilter filter);

        void Add(T entity);

        void Remove(int id);

        void Update(T entity);
    }
}