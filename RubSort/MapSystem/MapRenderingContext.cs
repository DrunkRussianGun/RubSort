using GeoCoordinatePortable;
using RubSort.RecyclingPointsSystem;

namespace RubSort.MapSystem
{
    public class MapRenderingContext
    {
        GeoCoordinate InitialPoint;
        int Zoom;
        RecyclingPoint[] RecyclingPoints;
    }
}