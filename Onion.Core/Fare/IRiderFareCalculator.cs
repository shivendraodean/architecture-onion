namespace Onion.Core.Fare
{
    public interface IRiderFareCalculator
    {
        decimal EstimateFare(GeoCoordinate start, GeoCoordinate end);
    }
}
