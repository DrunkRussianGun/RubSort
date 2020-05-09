using System;
using RubSort.DataStorageSystem;

namespace RubSort.RecyclingPointsSystem
{
    public class RecyclingPointProvider
    {
        private IEntityRepository<RecyclingPointDbo> entityRepository;

        public RecyclingPointProvider(IEntityRepository<RecyclingPointDbo> entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        
        public RecyclingPoint[] GetRecyclingPoints()
        {
            //todo
            throw new NotImplementedException();
        }
    }
}