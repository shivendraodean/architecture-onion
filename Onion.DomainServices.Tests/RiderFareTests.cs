using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Onion.Core;
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

            var fareRepoMock = new Mock<IFareRepository>();
            var routeServiceMock = new Mock<IRouteService>();

            var start = new GeoCoordinate(1, 1);
            var end = new GeoCoordinate(2, 1);
            decimal distance = 5;
            fareRepoMock.Setup(repo => repo.GetFareModel(start)).Returns(fareModel);
            routeServiceMock.Setup(service => service.CalculateDistance(start, end)).Returns(distance);

            IRiderFareCalculator target = new RiderFareCalculator(routeServiceMock.Object, fareRepoMock.Object);

            var estimate = target.EstimateFare(start, end);

            Assert.AreEqual(14, estimate);
        }
    }
}
