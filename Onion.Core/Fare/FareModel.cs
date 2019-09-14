namespace Onion.Core.Fare
{
    public class FareModel
    {
        public string Description { get; set; }
        public decimal Flagfall { get; set; }
        public decimal Tariff { get; set; }
        public decimal BookingFee { get; set; }
        public decimal SoilingFee { get; set; }
        public decimal AirportLevy { get; set; }
        public decimal RiderCancellationFee { get; set; }
        public decimal DriverCancellationFee { get; set; }
    }
}
