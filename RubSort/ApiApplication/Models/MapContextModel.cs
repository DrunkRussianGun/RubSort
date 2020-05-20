using System;
using GeoCoordinatePortable;
using RubSort.Core.Results;
using RubSort.MapSystem;

namespace RubSort.ApiApplication.Models
{
    public class MapContextModel
    {
        public GeoCoordinate InitialPoint { get; set; }
        
        public double Zoom { get; set; }

        public ValidationResult Validate()
        {
            throw new NotImplementedException();
        }

        public MapContext ToDomainModel()
        {
            return new MapContext
            {
                InitialPoint = InitialPoint,
                Zoom = Zoom
            };
        }
    }
}