using Onion.Core;
using Onion.DomainServices.Fare;
using System;

namespace Onion.ApplicationServices.Route
{
    public class RouteService : IRouteService
    {
        public decimal CalculateDistance(GeoCoordinate start, GeoCoordinate end)
        {
            /*  Distance calculation is obscured for the sake of brevity.
                Typically this would involve geospatial and mathematical algorithms,
                and/or the use of an external library such as Google Maps */

            return 10;
        }

        public bool InAirportZone(GeoCoordinate start, GeoCoordinate end)
        {
            return false;
        }
    }
}
