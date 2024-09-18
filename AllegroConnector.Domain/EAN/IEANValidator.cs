namespace AllegroConnector.Domain.EAN
{
    public interface IEANValidator
    {
        bool IsValidEAN(string ean);
    }
}
