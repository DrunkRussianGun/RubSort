using GeoCoordinatePortable;

namespace RubSort.RecyclingPointsSystem
{
    public class RecyclingPoint
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public Address Address { get; set; }
        
        public GeoCoordinate GeoCoordinate { get; set; }
        
        public Contacts Contacts { get; set; }
    }
}