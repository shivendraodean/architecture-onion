using Onion.Core;
using Onion.Core.Fare;
using Onion.DomainServices.Fare;

namespace Onion.ApplicationServices.Fare
{
    public class FareRepository : IFareRepository
    {
        public FareModel GetFareModel(GeoCoordinate coordinate)
        {
            /*  Details of retrieving the Model is obscurred for the sake of brevity.
                We would have used the coordinate parameter to figure out appropriate fare models to use,
                typically retrieved from a database or similar. */

            var fareModel = new FareModel()
            {
                Description = "Standard pricing",
                BookingFee = 1,
                Flagfall = 3,
                Tariff = 2,
            };

            return fareModel;
        }
    }
}
