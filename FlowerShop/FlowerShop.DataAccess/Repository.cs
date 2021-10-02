using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly FlowerShopContext context;
        private DbSet<T> entities;

        public Repository(FlowerShopContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(x => x.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if(entity == null)
            {
                throw  new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            context.SaveChanges();
        }
    }
}
