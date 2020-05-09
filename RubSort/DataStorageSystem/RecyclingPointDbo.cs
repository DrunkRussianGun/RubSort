using GeoCoordinatePortable;

namespace RubSort.DataStorageSystem
{
    public class RecyclingPointDbo : EntityDbo
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string AddressCountry { get; set; }
        
        public string AddressCity { get; set; }
        
        public string AddressAddressLine { get; set; }
        
        public GeoCoordinate GeoCoordinate { get; set; }
        
        public string ContactsEmail { get; set; }
        
        public string ContactsTelephone { get; set; }
    }
}