using GeoCoordinatePortable;

namespace RubSort.DataStorageSystem
{
    public class RecyclingPointDbo: EntityDbo
    {
        public string Name;
        public string Description;
        public string AddressCountry;
        public string AddressCity;
        public string AddressAddressLine;
        public GeoCoordinate GeoCoordinate; 
        public string ContactsEmail;
        public string ContactsTelephone;
        
    }
}