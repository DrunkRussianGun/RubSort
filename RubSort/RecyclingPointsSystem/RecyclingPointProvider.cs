using System;
using DataStorageSystem;

namespace RecyclingPointsSystem
{
    public class RecyclingPointProvider
    {
        private IEntityRepository<RecyclingPointDbo> _entityRepository;

        public RecyclingPointProvider(IEntityRepository<RecyclingPointDbo> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        
        public RecyclingPoint[] GetRecyclingPoints()
        {
            //todo
            throw new NotImplementedException();
        }
    }
}