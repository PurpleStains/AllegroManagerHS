using AllegroConnector.BuildingBlocks.Application.Data;
using AllegroConnector.BuildingBlocks.Infrastructure;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace BaselinkerConnector.Infrastructure.Configuration.DataAccess
{
    internal class DataAccessModule : Module
    {
        readonly string _databaseConnectionString;
        readonly ILoggerFactory _loggerFactory;

        internal DataAccessModule(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<BaselinkerContext>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);

                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new BaselinkerContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();


            var infrastructureAssembly = typeof(BaselinkerContext).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
