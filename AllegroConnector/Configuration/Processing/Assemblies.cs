using AllegroConnector.Application.Contracts;
using System.Reflection;

namespace AllegroConnector.Infrastructure.Configuration.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(IAllegroModule).Assembly;
    }
}
