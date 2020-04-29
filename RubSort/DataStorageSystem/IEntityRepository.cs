using System;
using System.Dynamic;

namespace DataStorageSystem
{
    public interface IEntityRepository<T>
    {
        T[] Get();
        void Add(T entity);
        void Update(T entity);
        void Remove(long value);
    }
}