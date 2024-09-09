namespace BaselinkerConnector.Domain
{
    public interface IBaselinkerClient
    {
        public Task<string> Products();
    }
}
