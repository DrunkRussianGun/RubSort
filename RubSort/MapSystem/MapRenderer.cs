using System;

namespace MapSystem
{
    public class MapRenderer
    {
        private OrganizationInfoProvider _organizationInfoProvider;
        private MapApiClient _mapApiClient;

        public MapRenderer(OrganizationInfoProvider organizationInfoProvider,
            MapApiClient mapApiClient)
        {
            _organizationInfoProvider = organizationInfoProvider;
            _mapApiClient = mapApiClient;
        }

        public RenderedMap Render(MapRenderingContext context)
        {
            //todo
            throw new NotImplementedException();
        }
            
    }
}