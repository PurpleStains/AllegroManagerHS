
using AllegroConnector.BuildingBlocks.Application.Events;
using AllegroConnector.BuildingBlocks.Infrastructure;
using AllegroConnector.BuildingBlocks.Infrastructure.DomainEventsDispatching;
using Autofac;
using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Application.Contracts;
using BaselinkerConnector.Infrastructure.Configuration.Processing.InternalCommands;
using CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Configuration.Processing;
using MediatR;

namespace BaselinkerConnector.Infrastructure.Configuration.Processing
{
    internal class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventsDispatcher>()
                .As<IDomainEventsDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DomainEventsAccessor>()
                .As<IDomainEventsAccessor>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandsScheduler>()
                .As<ICommandsScheduler>()
                .InstancePerLifetimeScope();

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerDecorator<>),
                typeof(IRequestHandler<>));

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerWithResultDecorator<,>),
                typeof(IRequestHandler<,>));

            //builder.RegisterGenericDecorator(
            //    typeof(ValidationCommandHandlerDecorator<>),
            //    typeof(ICommandHandler<>));

            //builder.RegisterGenericDecorator(
            //    typeof(ValidationCommandHandlerWithResultDecorator<,>),
            //    typeof(ICommandHandler<,>));

            //builder.RegisterGenericDecorator(
            //    typeof(LoggingCommandHandlerDecorator<>),
            //    typeof(IRequestHandler<>));

            builder.RegisterGenericDecorator(
                typeof(LoggingCommandHandlerWithResultDecorator<,>),
                typeof(IRequestHandler<,>));

            builder.RegisterGenericDecorator(
                typeof(DomainEventsDispatcherNotificationHandlerDecorator<>),
                typeof(INotificationHandler<>));

            builder.RegisterAssemblyTypes(typeof(IBaselinkerModule).Assembly)
                .AsClosedTypesOf(typeof(IDomainEventNotification<>))
                .InstancePerDependency()
                .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
