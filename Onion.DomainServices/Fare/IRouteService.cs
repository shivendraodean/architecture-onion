using Onion.Core;

namespace Onion.DomainServices.Fare
{
    public interface IRouteService
    {
        decimal CalculateDistance(GeoCoordinate start, GeoCoordinate end);

        bool InAirportZone(GeoCoordinate start, GeoCoordinate end);
    }
}
