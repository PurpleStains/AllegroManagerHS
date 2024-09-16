using AllegroConnector.BuildingBlocks.Application.Data;
using AllegroConnector.BuildingBlocks.Infrastructure.InternalCommands;
using AllegroConnector.BuildingBlocks.Infrastructure.Serialization;
using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Application.Contracts;
using Dapper;
using Newtonsoft.Json;

namespace BaselinkerConnector.Infrastructure.Configuration.Processing.InternalCommands
{
    public class CommandsScheduler(
        ISqlConnectionFactory sqlConnectionFactory,
        IInternalCommandsMapper internalCommandsMapper
        ) : ICommandsScheduler
    {

        public async Task EnqueueAsync(ICommand command)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();

            const string sqlInsert = "INSERT INTO [baselinker].[InternalCommands] ([Id], [EnqueueDate] , [Type], [Data]) VALUES " +
                                     "(@Id, @EnqueueDate, @Type, @Data)";

            await connection.ExecuteAsync(sqlInsert, new
            {
                command.Id,
                EnqueueDate = DateTime.UtcNow,
                Type = internalCommandsMapper.GetName(command.GetType()),
                Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContractResolver()
                })
            });
        }

        public async Task EnqueueAsync<T>(ICommand<T> command)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();

            const string sqlInsert = "INSERT INTO [baselinker].[InternalCommands] ([Id], [EnqueueDate] , [Type], [Data]) VALUES " +
                                     "(@Id, @EnqueueDate, @Type, @Data)";

            await connection.ExecuteAsync(sqlInsert, new
            {
                command.Id,
                EnqueueDate = DateTime.UtcNow,
                Type = internalCommandsMapper.GetName(command.GetType()),
                Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContractResolver()
                })
            });
        }
    }
}
