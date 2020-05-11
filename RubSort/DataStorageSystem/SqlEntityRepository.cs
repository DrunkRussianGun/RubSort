using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace RubSort.DataStorageSystem
{
    public class SqlEntityRepository<T> : IEntityRepository<T>
        where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> set;
        
        public SqlEntityRepository(DbContext context)
        {
            context.Database.EnsureCreated();
            
            this.context = context;
            set = context.Set<T>();
        }

        public T[] Get()
        {
            return set.AsNoTracking().ToArray();
        }

        public void Add(params T[] entities)
        {
            set.AddRange(entities);
            context.SaveChanges();
        }

        public void Update(params T[] entities)
        {
            set.UpdateRange(entities);
            context.SaveChanges();
        }

        public void Remove(params long[] ids)
        {
            var entitiesToRemove = ids
                .Select(id => set.Find(id));
            set.RemoveRange(entitiesToRemove);
            context.SaveChanges();
        }
    }
}