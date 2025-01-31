using FlowerShop.DataAccess.Core.Entities.Interfaces;

namespace FlowerShop.DataAccess.Repositories.AppRepository;

public interface IRepository<T> where T : IEntityBase
{
    Task<List<T>> GetAll();

    Task<T> GetById(int id);

    Task Insert(T entity);

    Task Update(T entity);

    Task Delete(int id);
}