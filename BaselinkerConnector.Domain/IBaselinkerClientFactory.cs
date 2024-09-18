namespace BaselinkerConnector.Domain
{
    public interface IBaselinkerClientFactory
    {
        public HttpClient Client();
    }
}
