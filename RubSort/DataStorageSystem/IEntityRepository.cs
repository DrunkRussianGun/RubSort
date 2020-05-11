namespace RubSort.DataStorageSystem
{
    public interface IEntityRepository<T>
        where T : class
    {
        T[] Get();
        void Add(params T[] entities);
        void Update(params T[] entities);
        void Remove(params long[] ids);
    }
}