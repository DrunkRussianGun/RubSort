using System;
using System.Linq;
using RubSort.DataStorageSystem;

namespace RubSort.RecyclingPointsSystem
{
    public class RecyclingPointProvider
    {
        private readonly IEntityRepository<RecyclingPointDbo> _entityRepository;

        public RecyclingPointProvider(IEntityRepository<RecyclingPointDbo> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        
        public RecyclingPoint[] GetRecyclingPoints()
        {
            return _entityRepository.Get()
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