using GeoCoordinatePortable;
using RubSort.RecyclingPointsSystem;

namespace RubSort.MapSystem
{
    public class MapRenderingContext
    {
        public GeoCoordinate InitialPoint { get; set; }
        
        public double Zoom { get; set; }
        
        public RecyclingPoint[] RecyclingPoints { get; set; }
    }
}