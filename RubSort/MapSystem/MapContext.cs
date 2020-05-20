using System.Collections.Generic;
using GeoCoordinatePortable;
using RubSort.RecyclingPointsSystem;

namespace RubSort.MapSystem
{
    public class MapContext
    {
        public GeoCoordinate InitialPoint { get; set; }
        
        public double Zoom { get; set; }
        
        public ICollection<RecyclingPoint> RecyclingPoints { get; set; }
    }
}