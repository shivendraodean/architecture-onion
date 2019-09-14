using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onion.Core.Fare;
using Onion.DomainServices.Fare;

namespace Onion.DomainServices.Tests
{
    [TestClass]
    public class RiderFareTests
    {
        [TestMethod]
        public void GivenAStandard5KmTrip_ThenEstimate14Dollars()
        {
            var fareModel = new FareModel()
            {
                Description = "Standard pricing",
                BookingFee = 1,
                Flagfall = 3,
                Tariff = 2,
            };

            IRiderFareCalculator target = new RiderFareCalculator();

            var distance = 5;
            var estimate = target.EstimateFare(fareModel, distance);

            Assert.AreEqual(14, estimate);
        }
    }
}
