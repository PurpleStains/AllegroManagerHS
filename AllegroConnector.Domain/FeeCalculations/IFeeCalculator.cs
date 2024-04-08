namespace AllegroConnector.Domain.FeeCalculations
{
    public interface IFeeCalculator<in T, out TResult>
    {
        TResult Calculate(T calculation);
    }
}
