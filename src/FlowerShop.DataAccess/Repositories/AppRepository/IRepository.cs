using System.Collections.Generic;
using System.Threading.Tasks;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.DataAccess.Repositories.AppRepository
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task Insert(T entity);

        Task Update(T entity);

        Task Delete(int id);
    }
}
