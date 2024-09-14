using BaselinkerConnector.Application.Contracts;
using System.Reflection;

namespace BaselinkerConnector.Infrastructure.Configuration.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(IBaselinkerModule).Assembly;
    }
}
