using Onion.Core.Fare;

namespace Onion.DomainServices.Fare
{
    public class RiderFareCalculator : IRiderFareCalculator
    {
        public decimal EstimateFare(FareModel model, decimal distance)
        {
            decimal estimate = 0;
            estimate += model.BookingFee;
            estimate += model.Flagfall;
            estimate += (model.Tariff * distance);

            return estimate;
        }
    }
}
