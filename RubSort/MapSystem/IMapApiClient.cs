using RubSort.RecyclingPointsSystem;

namespace RubSort.MapSystem
{
    public interface IMapApiClient
    {
        Map GetMap(MapContext context);
        
        RecyclingPoint GetInfo(RecyclingPoint recyclingPoint);
    }
}