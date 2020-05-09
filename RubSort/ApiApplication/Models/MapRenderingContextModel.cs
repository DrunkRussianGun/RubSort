using System;
using GeoCoordinatePortable;
using RubSort.Core.Results;
using RubSort.MapSystem;

namespace RubSort.ApiApplication.Models
{
    public class MapRenderingContextModel
    {
        public GeoCoordinate InitialPoint { get; set; }
        
        public double Zoom { get; set; }

        public ValidationResult Validate()
        {
            throw new NotImplementedException();
        }

        public ValidationResult<MapRenderingContext> ToDomainModel()
        {
            var validationResult = Validate();
            
            throw new NotImplementedException();
        }
    }
}