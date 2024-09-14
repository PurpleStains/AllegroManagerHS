using AllegroConnector.BuildingBlocks.Application.Data;
using AllegroConnector.BuildingBlocks.Infrastructure.Serialization;
using BaselinkerConnector.Application.Configuration.Commands;
using BaselinkerConnector.Application.Contracts;
using Dapper;
using Newtonsoft.Json;

namespace BaselinkerConnector.Infrastructure.Configuration.Processing.InternalCommands
{
    public class CommandsScheduler : ICommandsScheduler
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CommandsScheduler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task EnqueueAsync(ICommand command)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sqlInsert = "INSERT INTO [baselinker].[InternalCommands] ([Id], [EnqueueDate] , [Type], [Data]) VALUES " +
                                     "(@Id, @EnqueueDate, @Type, @Data)";

            await connection.ExecuteAsync(sqlInsert, new
            {
                command.Id,
                EnqueueDate = DateTime.UtcNow,
                Type = command.GetType().FullName,
                Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContractResolver()
                })
            });
        }

        public Task EnqueueAsync<T>(ICommand<T> command)
        {
            throw new NotImplementedException();
        }
    }
}
