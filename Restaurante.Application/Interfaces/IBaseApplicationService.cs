using Restaurante.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurante.Application.Interfaces
{
    public interface IBaseApplicationService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync(PaginationFilter filter);

        Task AddAsync(T entity);

        Task RemoveAsync(int id);

        Task UpdateAsync(T entity);
    }
}