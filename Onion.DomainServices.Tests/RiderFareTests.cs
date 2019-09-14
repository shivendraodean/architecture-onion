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
        private Mock<IFareRepository> fareRepoMock;
        private Mock<IRouteService> routeServiceMock;

        private FareModel fareModel;

        [TestInitialize]
        public void Init()
        {
            fareRepoMock = new Mock<IFareRepository>();
            routeServiceMock = new Mock<IRouteService>();

            fareModel = new FareModel()
            {
                Description = "Standard pricing",
                BookingFee = 1,
                Flagfall = 3,
                Tariff = 2,
                AirportLevy = 5
            };

            fareRepoMock.Setup(repo => repo.GetFareModel(It.IsAny<GeoCoordinate>())).Returns(fareModel);
        }

        [TestMethod]
        public void GivenAStandard5KmTrip_ThenEstimate14Dollars()
        {
            var start = new GeoCoordinate(1, 1);
            var end = new GeoCoordinate(2, 2);
            decimal distance = 5;
            routeServiceMock.Setup(service => service.CalculateDistance(start, end)).Returns(distance);
            IRiderFareCalculator target = new RiderFareCalculator(routeServiceMock.Object, fareRepoMock.Object);

            var estimate = target.EstimateFare(start, end);

            Assert.AreEqual(14, estimate);
        }

        [TestMethod]
        public void GivenAnAirportTrip_ThenEstimate19Dollars()
        {
            var start = new GeoCoordinate(3, 3);
            var end = new GeoCoordinate(4, 4);
            decimal distance = 5;
            routeServiceMock.Setup(service => service.CalculateDistance(start, end)).Returns(distance);
            routeServiceMock.Setup(service => service.InAirportZone(start, end)).Returns(true);
            IRiderFareCalculator target = new RiderFareCalculator(routeServiceMock.Object, fareRepoMock.Object);

            var estimate = target.EstimateFare(start, end);

            Assert.AreEqual(19, estimate);
        }
    }
}
