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

            return estimate;
        }
    }
}
