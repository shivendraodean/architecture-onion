namespace Onion.Core.Fare
{
    public interface IRiderFareCalculator
    {
        decimal EstimateFare(FareModel model, decimal distance);
    }
}
