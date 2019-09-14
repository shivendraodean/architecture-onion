using Onion.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DomainServices.Fare
{
    public interface IRouteService
    {
        decimal CalculateDistance(GeoCoordinate start, GeoCoordinate end);

        bool InAirportZone(GeoCoordinate start, GeoCoordinate end);
    }
}
