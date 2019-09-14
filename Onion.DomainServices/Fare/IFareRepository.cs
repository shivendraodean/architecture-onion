using Onion.Core;
using Onion.Core.Fare;

namespace Onion.DomainServices.Fare
{
    public interface IFareRepository
    {
        FareModel GetFareModel(GeoCoordinate start);
    }
}
