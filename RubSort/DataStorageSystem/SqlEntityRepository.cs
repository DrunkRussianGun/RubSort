using RubSort.Core;

namespace RubSort.DataStorageSystem
{
    public class SqlEntityRepository<T> : IEntityRepository<T>
    {
        public SqlEntityRepository(ISettingsManager settingsManager)
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