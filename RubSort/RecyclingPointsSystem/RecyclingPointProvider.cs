using System.Linq;
using GeoCoordinatePortable;
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
                .Select(point => new RecyclingPoint
                {
                    Name = point.Name,
                    Description = point.Description,
                    Address = new Address
                    {
                        AddressLine = point.AddressAddressLine, City = point.AddressCity, Country = point.AddressCountry
                    },
                    Contacts = new Contacts {Email = point.ContactsEmail, Telephone = point.ContactsTelephone},
                    GeoCoordinate = point.GeoCoordinate?.Latitude != null && point.GeoCoordinate.Longitude != null
                        ? new GeoCoordinate(
                            point.GeoCoordinate.Latitude.Value,
                            point.GeoCoordinate.Longitude.Value)
                        : null
                })
                .ToArray();
        }
    }
}