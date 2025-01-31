using FlowerShop.DataAccess.Core.Entities.Interfaces;
using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.Repositories.AppRepository;

public class Repository<T>(FlowerShopStorageContext context) : IRepository<T>
    where T : class, IEntityBase
{
    private readonly DbSet<T> _entities = context.Set<T>();

    public Task<List<T>> GetAll()
    {
        return _entities.ToListAsync();
    }

    public Task<T> GetById(int id)
    {
        return _entities.SingleOrDefaultAsync(s => s.Id == id);
    }

    public Task Insert(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        _entities.Add(entity);
        return context.SaveChangesAsync();
    }

    public Task Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        return context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _entities.SingleOrDefaultAsync(x => x.Id == id);
        if (entity is not null) _entities.Remove(entity);
        await context.SaveChangesAsync();
    }
}
