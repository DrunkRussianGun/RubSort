using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RubSort.DataStorageSystem
{
    public class SqlEntityRepository<T> : IEntityRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> set;
        
        public SqlEntityRepository(ApplicationDbContext context)
        {
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