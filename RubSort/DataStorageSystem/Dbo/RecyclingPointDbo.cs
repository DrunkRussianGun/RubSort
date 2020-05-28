using System.ComponentModel.DataAnnotations.Schema;
using GeoCoordinatePortable;

namespace RubSort.DataStorageSystem.Dbo
{
    [Table("RecyclingPoints")]
    public class RecyclingPointDbo : EntityDbo
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string AddressCountry { get; set; }
        
        public string AddressCity { get; set; }
        
        public string AddressAddressLine { get; set; }
        
        public GeoCoordinateDbo GeoCoordinate { get; set; }
        
        public string ContactsEmail { get; set; }
        
        public string ContactsTelephone { get; set; }
    }
}