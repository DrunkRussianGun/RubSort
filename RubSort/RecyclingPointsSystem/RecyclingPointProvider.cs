using System.Linq;
using RubSort.DataStorageSystem;
using RubSort.DataStorageSystem.Dbo;

namespace RubSort.RecyclingPointsSystem
{
    public class RecyclingPointProvider
    {
        private readonly IEntityRepository<RecyclingPointDbo> entityRepository;

        public RecyclingPointProvider(IEntityRepository<RecyclingPointDbo> entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        
        public RecyclingPoint[] GetRecyclingPoints()
        {
            return entityRepository.Get()
                .Select(rp => new RecyclingPoint()
                {
                    Name = rp.Name,
                    Description = rp.Description,
                    Address = new Address()
                    {
                        AddressLine = rp.AddressAddressLine, City = rp.AddressCity, Country = rp.AddressCountry
                    },
                    Contacts = new Contacts() {Email = rp.ContactsEmail, Telephone = rp.ContactsTelephone},
                    GeoCoordinate = rp.GeoCoordinate
                })
                .ToArray();
        }
    }
}