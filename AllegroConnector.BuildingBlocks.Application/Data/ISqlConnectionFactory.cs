using System.Data;

namespace AllegroConnector.BuildingBlocks.Application.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
        IDbConnection CreateNewConnection();
        string GetConnectionString();
    }
}
