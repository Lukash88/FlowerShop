using FlowerShop.DataAccess.Core.Entities.Interfaces;
using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.Repositories.AppRepository
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase
    {
        private readonly FlowerShopStorageContext _context;
        private readonly DbSet<T> _entities;

        public Repository(FlowerShopStorageContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }      

        public Task<List<T>> GetAll()
        {
            return _entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _entities.SingleOrDefaultAsync(s => s.Id is id);
        }

        public Task Insert(T entity)
        {
            if(entity is null)
            {
                throw  new ArgumentNullException("entity");
            }

            _entities.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("entity");
            }

            return _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await _entities.SingleOrDefaultAsync(x => x.Id is id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}