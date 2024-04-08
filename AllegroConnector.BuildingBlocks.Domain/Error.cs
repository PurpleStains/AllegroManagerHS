namespace AllegroConnector.BuildingBlocks.Domain
{
    public sealed record Error(string Code, string? Message = null);
}
