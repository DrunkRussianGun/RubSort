using System.Linq;
using RubSort.RecyclingPointsSystem;

namespace RubSort.MapSystem
{
    public class MapGetter
    {
        private readonly IMapApiClient mapApiClient;
        private readonly RecyclingPointProvider recyclingPointProvider;

        public MapGetter(
            IMapApiClient mapApiClient,
            RecyclingPointProvider recyclingPointProvider)
        {
            this.mapApiClient = mapApiClient;
            this.recyclingPointProvider = recyclingPointProvider;
        }

        public Map GetMap(MapContext context)
        {
            context.RecyclingPoints = recyclingPointProvider
                .GetRecyclingPoints()
                .Select(point =>
                {
                    // var receivedInfo = mapApiClient.GetInfo(point);
                    // return MergeRecyclingPointInfo(point, receivedInfo);
                    return point;
                })
                .Where(point => point.GeoCoordinate != null)
                .ToList();
            return mapApiClient.GetMap(context);
        }

        private static RecyclingPoint MergeRecyclingPointInfo(
            RecyclingPoint existingInfo,
            RecyclingPoint newInfo)
        {
            existingInfo.Address = newInfo.Address ?? existingInfo.Address;
            existingInfo.GeoCoordinate = newInfo.GeoCoordinate ?? existingInfo.GeoCoordinate;
            existingInfo.Contacts.Email = newInfo.Contacts.Email ?? existingInfo.Contacts.Email;
            existingInfo.Contacts.Telephone = newInfo.Contacts.Telephone ?? existingInfo.Contacts.Telephone;
            return existingInfo;
        }
    }
}