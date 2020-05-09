using System;

namespace RubSort.MapSystem
{
    public class MapRenderer
    {
        private OrganizationInfoProvider organizationInfoProvider;
        private MapApiClient mapApiClient;

        public MapRenderer(
            OrganizationInfoProvider organizationInfoProvider,
            MapApiClient mapApiClient)
        {
            this.organizationInfoProvider = organizationInfoProvider;
            this.mapApiClient = mapApiClient;
        }

        public RenderedMap Render(MapRenderingContext context)
        {
            //todo
            throw new NotImplementedException();
        }
            
    }
}