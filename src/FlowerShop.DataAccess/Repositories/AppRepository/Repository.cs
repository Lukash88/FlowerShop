using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlowerShop.DataAccess.Core.Entities.Interfaces;
using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.Repositories.AppRepository
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase
    {
        private readonly FlowerShopStorageContext context;
        private readonly DbSet<T> entities;

        public Repository(FlowerShopStorageContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }      

        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public Task Insert(T entity)
        {
            if(entity == null)
            {
                throw  new ArgumentNullException("entity");
            }

            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await entities.SingleOrDefaultAsync(x => x.Id == id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
