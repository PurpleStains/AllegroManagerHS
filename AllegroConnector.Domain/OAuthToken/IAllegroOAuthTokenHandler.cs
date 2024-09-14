namespace AllegroConnector.Domain.OAuthToken
{
    public interface IAllegroOAuthTokenHandler
    {
        Task<string> GetToken();
    }
}
