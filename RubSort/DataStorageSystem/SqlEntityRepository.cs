using Microsoft.Extensions.Configuration;

namespace RubSort.DataStorageSystem
{
    public class SqlEntityRepository<T> : IEntityRepository<T>
    {
        public SqlEntityRepository(IConfiguration configuration)
        {
            //todo
        }

        public T[] Get()
        {
            throw new System.NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(long value)
        {
            throw new System.NotImplementedException();
        }
    }
}