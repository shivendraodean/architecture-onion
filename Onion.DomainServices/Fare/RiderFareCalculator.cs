using Onion.Core;
using Onion.Core.Fare;

namespace Onion.DomainServices.Fare
{
    public class RiderFareCalculator : IRiderFareCalculator
    {
        private IRouteService routeService;
        private IFareRepository fareRepository;

        public RiderFareCalculator(IRouteService routeService, IFareRepository fareRepository)
        {
            this.routeService = routeService;
            this.fareRepository = fareRepository;
        }

        public decimal EstimateFare(GeoCoordinate start, GeoCoordinate end)
        {
            FareModel model = fareRepository.GetFareModel(start);
            decimal distance = routeService.CalculateDistance(start, end);

            decimal estimate = 0;
            estimate += model.BookingFee;
            estimate += model.Flagfall;
            estimate += (model.Tariff * distance);

            estimate = ApplyAirportLevy(estimate, model.AirportLevy, start, end); 

            return estimate;
        }

        private decimal ApplyAirportLevy(decimal fare, decimal airportLevy, GeoCoordinate start, GeoCoordinate end)
        {
            bool isAirportTrip = routeService.InAirportZone(start, end);

            return isAirportTrip
                ? fare += airportLevy
                : fare;
        }
    }
}
