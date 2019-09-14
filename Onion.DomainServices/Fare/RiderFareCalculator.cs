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

            decimal estimate = ApplyBaseFare(model);
            estimate = ApplyTariff(estimate, model.Tariff, start, end);
            estimate = ApplyAirportLevy(estimate, model.AirportLevy, start, end); 

            return estimate;
        }

        private decimal ApplyBaseFare(FareModel model)
        {
            return model.BookingFee + model.Flagfall;
        }

        private decimal ApplyTariff(decimal fare, decimal tariff, GeoCoordinate start, GeoCoordinate end)
        {
            decimal distance = routeService.CalculateDistance(start, end);

            return fare + tariff * distance;
        }

        private decimal ApplyAirportLevy(decimal fare, decimal airportLevy, GeoCoordinate start, GeoCoordinate end)
        {
            bool isAirportTrip = routeService.InAirportZone(start, end);
            decimal airportFare = fare + airportLevy;

            return isAirportTrip ? airportFare : fare;
        }
    }
}
